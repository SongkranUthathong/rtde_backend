using Ur_Rtde;
using Mycode;
using System.Threading.Tasks;
using System.Text.Json;
public class BackgroundRTED{
    static RtdeClient rtdeOject;
    static UniversalRobot_Outputs UrOutputs = new UniversalRobot_Outputs();
    
    private static string _ipadd = "127.0.0.1";
    private static bool _status = false;
    public String IPAddress{
        get {return _ipadd;}
    }
    public bool Status{
        get{return _status;}
    }
    public BackgroundRTED(){

    rtdeOject = new RtdeClient();
    Console.WriteLine("Constructor Read!!!");
    }
    public async Task<int> MyAsyncMethod()
    {
        // Simulating an asynchronous operation that returns an integer after some delay
        await Task.Delay(300); // This delays execution for 2000 milliseconds (2 seconds)
        return 42;
    }

    public async Task<string> rtdeConnect(string ip){
        try{
            if(_status){
                                var conenction = new ConnectionJson{
                status = _status,
                ip = _ipadd
            };
            string jsonString = JsonSerializer.Serialize(conenction);
            return jsonString;
                }
            _status = rtdeOject.Connect(ip, 2);
            int result = await MyAsyncMethod();
            Console.WriteLine(_status);
            if (_status)
            {
                rtdeOject.Setup_Ur_Outputs(UrOutputs, 100);
                rtdeOject.OnDataReceive += Ur10_OnDataReceive;
                rtdeOject.Ur_ControlStart();

                _ipadd =ip;
            var conenction = new ConnectionJson{
                status = _status,
                ip = _ipadd
            };
            string conString = JsonSerializer.Serialize(conenction);
            return conString;
            }else{
                return "";
            }
            
        }catch(Exception ex){
            Console.WriteLine(ex);
            return null;
        }
    }

    public async Task<string> rtdeDisConnect(){
        try{
            // rtdeOject.Disconnect();
            rtdeOject.OnDataReceive -=  Ur10_OnDataReceive;
            int result = await MyAsyncMethod();
            _status = rtdeOject.Disconnect();  
                var conenction = new ConnectionJson{
                status = _status,
                ip = _ipadd
            };
             string jsonString = JsonSerializer.Serialize(conenction);
            return jsonString;
        }catch(Exception ex){
            Console.WriteLine(ex);
            return "";
        }
    }
    public String getConnection(){
        try{
            var conenction = new ConnectionJson{
                status = _status,
                ip = _ipadd
            };
             string jsonString = JsonSerializer.Serialize(conenction);
            return jsonString;
        }catch(Exception ex){
            Console.WriteLine(ex);
            return "";
        }
    }
    public String act_Steaming(){
        try{
            var preformance = new SteamingJson{
                actual_q = UrOutputs.actual_q,
                target_q = UrOutputs.target_q,
                actual_qd = UrOutputs.actual_qd,
                target_qd = UrOutputs.target_qd,
                actual_current = UrOutputs.actual_current,
                target_current = UrOutputs.target_current,
                joint_temperatures = UrOutputs.joint_temperatures,
                actual_joint_voltage = UrOutputs.actual_joint_voltage,
                speed_scaling = UrOutputs.speed_scaling
                
            };
             string jsonString = JsonSerializer.Serialize(preformance);
            return jsonString;
        }catch(Exception er){
            Console.WriteLine(er);
            return null;
        }
    }
    public String act_Preformance(){
        try{
            var preformance = new PreformanceJson{
                robot_status_bits = UrOutputs.robot_status_bits,
                runtime_state = UrOutputs.runtime_state,
                safety_status_bits = UrOutputs.safety_status_bits,
                actual_main_voltage = UrOutputs.actual_main_voltage,
                actual_robot_voltage = UrOutputs.actual_robot_voltage,
                actual_robot_current = UrOutputs.actual_robot_current
            };
             string jsonString = JsonSerializer.Serialize(preformance);
            return jsonString;
        }catch(Exception er){
            Console.WriteLine(er);
            return null;
        }
    }
    private void Ur10_OnDataReceive(object? sender, EventArgs e)
        {

        // double r2d = (180 / Math.PI);
        // Console.WriteLine("[" + (UrOutputs.actual_q[0] * r2d).ToString("0.00") + ","
        //    + (UrOutputs.actual_q[1] * r2d).ToString("0.00") + ","
        //    + (UrOutputs.actual_q[2] * r2d).ToString("0.00") + ","
        //    + (UrOutputs.actual_q[3] * r2d).ToString("0.00") + ","
        //    + (UrOutputs.actual_q[4] * r2d).ToString("0.00") + ","
        //    + (UrOutputs.actual_q[5] * r2d).ToString("0.00") + ","
        //    + "]");
    }
}

    public class PreformanceJson
    {
        public UInt32 robot_status_bits { get; set; }
        public UInt32 runtime_state { get; set; }
        public UInt32 safety_status_bits { get; set; }
        public double actual_main_voltage { get; set; }
        public double actual_robot_voltage { get; set; }
        public double actual_robot_current { get; set; }
    }
    public class SteamingJson
    {
        public double[] actual_q { get; set; } = new double[6];
        public double[] target_q { get; set; }= new double[6];
        public double[] actual_qd { get; set; }= new double[6];
        public double[] target_qd { get; set; }= new double[6];
        public double[] actual_current { get; set; }= new double[6];
        public double[] target_current { get; set; }= new double[6];
        public double[] joint_temperatures { get; set; }= new double[6];
        public double[] actual_joint_voltage { get; set; }= new double[6];
        public double speed_scaling{ get; set; }
    }
    public class ConnectionJson{
        public bool status { get; set; }
        public string ip { get; set; }
    }