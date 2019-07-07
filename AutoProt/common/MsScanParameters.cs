using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProt
{
    public class MsScanParameters
    {
        public double signalToNoiseThreshold;
        public List<double> ms1Targets;
        public List<short> chargeOfms1Targets;
        public double[] ms1adducts;
        public double ms1massError;
        public List<double> ms2Targets;
        public double ms2massError;


        public MsScanParameters(SettingsForAnalysis settingName)
        {
            signalToNoiseThreshold = settingName.StoNthreshold;
            ms1massError = 10; //ppm error for matching ms
            ms2massError = 10; //ppm error for matching ms

            ms1Targets = new List<double>
            {
                    327.20135,
                    371.227565,
                    459.279995,
                    591.35864,
                    767.4635,
                    309.24242,
                    353.268635,
                    441.321065,
                    573.39971,
                    749.50457,
                    339.25299,
                    383.279205,
                    471.331635,
                    603.41028,
                    779.51514,
                    381.29753,
                    425.323745,
                    513.376175,
                    645.45482,
                    821.55968,
                    367.28188,
                    411.308095,
                    499.360525,
                    631.43917,
                    807.54403
                    //464.25036,
                    //582.31897,
                    //722.32465
            };
            chargeOfms1Targets = new List<short>
                    {
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1,
                        1//,
                        //2,
                        //2,
                        //2
                    };
            //Int16[] polymerIndex = new Int16[25] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            //Int16[] ms1TargetIndex = new Int16[3] { 25, 26, 27 };
            ms1adducts = new double[7]
                    {17.026549, 21.981943, 32.026213, 37.946941, 37.955882, 41.026547, 52.911464};

            //double[] tmtTargets = new double[10] { 500.0, 501.0, 502.0, 503.0, 504.0, 505.0, 506.0, 507.0, 508.0, 509.0 };
            //double[] tmtIntensity = new double[tmtTargets.Length];
            //double[] ms2Targets = new double[3] { 600.0, 601.0, 602.0 };
            //double[] ms2Intensity = new double[ms2Targets.Length];
            /*ms2Targets =
                    new List<double>
                    {
                        126.127725,
                        127.124760,
                        127.131079,
                        128.128114,
                        128.134433,
                        129.131468,
                        129.137787,
                        130.134822,
                        130.141141,
                        131.138176,
                        651.346052153,
                        951.478187153,
                        1167.494641153
                    };*/

        }
    }
}
