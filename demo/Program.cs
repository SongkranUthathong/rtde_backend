using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MongoDB.Driver;
using Ur_Rtde;
using Mycode;
using MongoDB.Bson;

namespace dataMongoDB_Offline
{
    class Program
    {
        // Communication RTDE Port
        static RtdeClient rtdeURE10;
        static UniversalRobot_Outputs UrOutputs = new UniversalRobot_Outputs();
        // Database Mongo Variable
        private static MongoClient client { get; set; }
        private static IMongoCollection<DocumentDataBase> collection1;
        private static string MongoConnection = "mongodb://localhost:27017";
        private static string MongoDatabase = "ur5e";
        private static string MongoCollection = "move_2point"; 


        static void Main(string[] args)
        {

            rtdeConnect();
            


            while (true)
            {
                if (Console.ReadKey(true).KeyChar == 'q')
                {
                    return;
                }
                else { }

            }
        }
        static void rtdeConnect()
        {
            try
            {
                string ip = "192.168.1.10";
                rtdeURE10 = new RtdeClient();
                Console.Write("Plasse Enter IP Address UR Robot: ");
                ip = Console.ReadLine();
                bool status = rtdeURE10.Connect(ip, 2);
                if (status)
                {
                    Console.WriteLine("Connect Success!!");
                    MongoDbConnect();
                    rtdeURE10.Setup_Ur_Outputs(UrOutputs, 100);
                    rtdeURE10.OnDataReceive += new EventHandler(Ur10_OnDataReceive);
                    rtdeURE10.Ur_ControlStart();
                    return;
                }
                else { Console.WriteLine("Connect fail...");}
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        static void MongoDbConnect()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                var database = client.GetDatabase(MongoDatabase);
                collection1 = database.GetCollection<DocumentDataBase>(MongoCollection);
                Console.WriteLine("Database name Connect : "+ database.DatabaseNamespace);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }

        private static void Ur10_OnDataReceive(object sender, EventArgs e)
        {
            try
            {
                #region Close
                //double r2d = (180 / Math.PI);

                //Console.WriteLine("[" + (UrOutputs.actual_q[0] * r2d).ToString("0.00") + ","
                //    + (UrOutputs.actual_q[1] * r2d).ToString("0.00") + ","
                //    + (UrOutputs.actual_q[2] * r2d).ToString("0.00") + ","
                //    + (UrOutputs.actual_q[3] * r2d).ToString("0.00") + ","
                //    + (UrOutputs.actual_q[4] * r2d).ToString("0.00") + ","
                //    + (UrOutputs.actual_q[5] * r2d).ToString("0.00") + ","
                //    + "]");
                //Console.WriteLine("[" + (UrOutputs.actual_q[0] * r2d).ToString("0.00") + ","
                //    + (UrOutputs.joint_temperatures[1]).ToString("0.00") + ","
                //    + (UrOutputs.joint_temperatures[2]).ToString("0.00") + ","
                //    + (UrOutputs.joint_temperatures[3]).ToString("0.00") + ","
                //    + (UrOutputs.joint_temperatures[4]).ToString("0.00") + ","
                //    + (UrOutputs.joint_temperatures[5]).ToString("0.00") + ","
                //    + "]");
                //Console.WriteLine("[" + (UrOutputs.actual_q[0] * r2d).ToString("0.00") + ","
                //    + (UrOutputs.actual_current[1]).ToString("0.00") + ","
                //    + (UrOutputs.actual_current[2]).ToString("0.00") + ","
                //    + (UrOutputs.actual_current[3]).ToString("0.00") + ","
                //    + (UrOutputs.actual_current[4]).ToString("0.00") + ","
                //    + (UrOutputs.actual_current[5]).ToString("0.00") + ","
                //    + "]");
                //Console.WriteLine("==================================================================");
                #endregion
                InsertLog(UrOutputs.actual_q, UrOutputs.joint_temperatures, UrOutputs.actual_current);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void InsertLog(double[] jq,double[] jt, double[] jc)
        {
            try
            {
                DocumentDataBase _document = new DocumentDataBase
                {
                    dataTime = DateTime.Now,
                    joint_rote = jq,
                    joint_temp = jt,
                    joint_current = jc
                };
                collection1.InsertOne(_document);
                Console.WriteLine("DataLog Time >> " + _document.dataTime);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }

}
