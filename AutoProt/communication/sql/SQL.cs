using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using Serilog;

namespace AutoProt
{
    public class SQL : IDisposable
    {
        private MySqlConnection connection;
        private string database;
        private string table;
        private bool disposed = false;

        public SQL(string server, string database, string table, string uid, string password)
        {
            Initialize(server, database, table, uid, password);
        }

        private void Initialize(string server, string database, string table, string uid, string encryptedpassword)
        {
            this.database = database;
            this.table = table;
            string connectionString;
            try
            {
                string password = Crypto.DecryptString(encryptedpassword, "secretSqlPass");
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                    database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
                this.connection = new MySqlConnection(connectionString);
            }
            catch
            {
                Log.Warning("SQL Initializing failed, possible problems with password");
            }
            
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Log.Warning("SQL OpenConnection failed with this message: " + ex.Message);
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Log.Warning("SQL CloseConnection failed with this message: " + ex.Message);
                return false;
            }
        }
        public void CreateTable(string table, List<Tuple<string, Type>> types)
        {
            StringBuilder createTableCommand = new StringBuilder();
            createTableCommand.Append("CREATE TABLE `" + table + "` (	`ID` INT(11) NOT NULL AUTO_INCREMENT,");
            foreach (Tuple<string, Type> item in types)
            {
                createTableCommand.Append("`").Append(ToPascalCase(item.Item1)).Append("` ");
                if (item.Item2.Equals(typeof(string)))
                {
                    createTableCommand.Append("VARCHAR(255)");
                }
                else if (item.Item2.Equals(typeof(int)))
                {
                    createTableCommand.Append("INT(11)");
                }
                else if (item.Item2.Equals(typeof(double)))
                {
                    createTableCommand.Append("FLOAT");
                }
                else if (item.Item2.Equals(typeof(DateTime)))
                {
                    createTableCommand.Append("DATETIME");
                }
                else
                {
                    createTableCommand.Append("VARCHAR(50)");
                    Log.Warning("WOW, something really funky happened with the formats");
                }
                createTableCommand.Append(" NULL DEFAULT NULL,");

            }
            createTableCommand.Append("PRIMARY KEY (`ID`), UNIQUE INDEX `ID` (`ID`) ) COMMENT='First attempt at making an sql table' COLLATE='utf8_general_ci' ENGINE=InnoDB AUTO_INCREMENT=1 ;");
            Insert(createTableCommand.ToString());
        }
        public void AddColumnsToTable(string table, List<Tuple<string, Type>> types)
        {
            StringBuilder createTableCommand = new StringBuilder();
            createTableCommand.Append("ALTER TABLE `" + table + "`");
            List <string> colNames = GetColumnNames();
            bool first = true;
            foreach (Tuple<string, Type> item in types)
            {
                string newName = ToPascalCase(item.Item1);
                if (!colNames.Contains(newName))
                {
                    if (first)
                    {
                        createTableCommand.Append(" ADD ");
                        first = false;
                    }
                    else
                    {
                        createTableCommand.Append(", ADD ");
                    }
                    createTableCommand.Append(newName);
                    if (item.Item2.Equals(typeof(string)))
                    {

                        createTableCommand.Append(" VARCHAR(255) NULL DEFAULT NULL");
                    }
                    else if (item.Item2.Equals(typeof(int)))
                    {
                        createTableCommand.Append(" INT(11) NULL DEFAULT NULL");
                    }
                    else if (item.Item2.Equals(typeof(double)))
                    {
                        createTableCommand.Append(" FLOAT NULL DEFAULT NULL");
                    }
                    else if (item.Item2.Equals(typeof(DateTime)))
                    {
                        createTableCommand.Append(" DATETIME NULL DEFAULT NULL");
                    }
                    else
                    {
                        createTableCommand.Append(" VARCHAR(50) NULL DEFAULT NULL");
                        Log.Warning("WOW, something really funky happened with the formats");
                    }
                }
            }
            createTableCommand.Append(";");
            string newCommand = createTableCommand.ToString();
            Insert(newCommand);
            Log.Information("Executed this: " + createTableCommand.ToString());//add what the sql server said
        }


        public bool TestConnection()
        {
            bool success = false;
            List<string> dbheader = new List<string>();
            dbheader = GetColumnNames();
            if (dbheader != null)
            {
                success = true;
            }
            return success;
        }
        private List<string> GetColumnNames()
        {
            List<string> dbHeaders = new List<string>();
            bool testClose = false;
            bool testOpen = OpenConnection();
            if (testOpen)
            {
                string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + database + "' AND TABLE_NAME='" + table + "'";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    dbHeaders.Add(dataReader[0].ToString());
                }
                dataReader.Close();
                testClose = CloseConnection();

            }
            if (testOpen & testClose)
            {
                //progress.Report("SQL connection seems OK!");
                return dbHeaders;
            }
            else
            {
                return null;
            }

        }

        private string ToPascalCase(string name)
        {
            string newName = string.Join("", name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Substring(0, 1).ToUpper() + s.Substring(1)).ToArray());
            //return Regex.Replace(newName, @"[@&'/(\\s)<>#\.\-°]", "");
            return Regex.Replace(newName, @"[^A-Za-z0-9]", "");
        }

        public void Insert(string query)
        {
            CommonInsert(query);
        }

        public void Insert(List<string> names, List<string> values)
        {
            string query = "INSERT INTO " + this.table + "(" + String.Join(",",names.Select(x => ToPascalCase(x))) + ") VALUES('" + String.Join("','", values) + "')";
            CommonInsert(query);
        }
        private void CommonInsert(string query)
        {
            if (IsComplete(query))
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Log.Warning("SQL Insert failed due to: " + ex.Message);
                        Log.Warning("SQL Insert failure command: " + query);
                    }
                    //close connection
                    this.CloseConnection();
                }
            }
            else
            {
                //progress.Report("SQL Insert failed due to unknown reasons");
            }
        }
        /*
        private void CommonInsert(string query, IProgress<string> progress)
        {
            if (IsComplete(query))
            {
                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        progress.Report("SQL Insert failed due to: " + ex.Message);
                        progress.Report("SQL Insert failure command: " + query);
                    }
                    //close connection
                    this.CloseConnection();
                }
            }
            else
            {
                progress.Report("SQL Insert failed due to unknown reasons");
            }
        }
        */

        //temporary hack here, need to make it more general i.e. return a table or similar and take the SQL query as input. Need error handling.
        //another possibility is to make multiple sql queries?
        public void GetTime(int[] intervalsInDays, string instrument, string instrumentNumber, out List<double> usagePercent, out List<double> msUsagePercent, out List<double> nonQcMsUsagePercent)
        {
            //variables initialization
            List<double> totalusagetime = new List<double>();
            List<double> totalmstime = new List<double>();
            List<double> totalnonqcmstime = new List<double>();
            //open connection
            if (this.OpenConnection() == true)
            {
                //building query
                StringBuilder newSqlCommand = new StringBuilder();
                foreach (int i in intervalsInDays)
                {
                    newSqlCommand.Append("SELECT SampleType as SAMPLETYPE, SUM(MSTimeInMinutes) AS MSTIME, SUM(LCTimeInMinutes) AS LCTIME FROM ");
                    newSqlCommand.Append(this.table);
                    newSqlCommand.Append(" WHERE MSStart BETWEEN NOW() - INTERVAL ");
                    newSqlCommand.Append(i);
                    newSqlCommand.Append(" DAY AND NOW() AND MSInstrument = '");
                    newSqlCommand.Append(instrument);
                    newSqlCommand.Append("' AND MSInstrumentNumber = '");
                    newSqlCommand.Append(instrumentNumber);
                    newSqlCommand.Append("' GROUP BY SampleType WITH ROLLUP;");
                }
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(newSqlCommand.ToString(), connection);

                //Execute command
                using (var rdr = cmd.ExecuteReader())
                {
                    do
                    {
                        double time = 0.0;
                        double mstime = 0.0;
                        double qcmstime = 0.0;

                        while (rdr.Read())
                        {
                            string sampletype = Convert.ToString(rdr["SAMPLETYPE"]);
                            if (sampletype.Equals("QC"))
                            {
                                qcmstime = Convert.ToDouble(rdr["MSTIME"]);
                            }
                            else if (sampletype.Equals(""))
                            {
                                mstime = Convert.ToDouble(rdr["MSTIME"]);
                                time = mstime + Convert.ToDouble(rdr["LCTIME"]);
                            }
                        }
                        totalusagetime.Add(time);
                        totalmstime.Add(mstime);
                        totalnonqcmstime.Add(mstime-qcmstime);
                    }
                    while (rdr.NextResult());
                }
                //close connection
                this.CloseConnection();
            }
            else
            {
                foreach (int i in intervalsInDays)
                {
                    totalusagetime.Add(0.0);
                    totalmstime.Add(0.0);
                    totalnonqcmstime.Add(0.0);
                }
            }
            usagePercent = totalusagetime;
            msUsagePercent = totalmstime;
            nonQcMsUsagePercent = totalnonqcmstime;
        }

        private bool IsComplete(string query)
        {
            if (query != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (connection != null)
                    {
                        connection.Dispose();

                    }
                }
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
