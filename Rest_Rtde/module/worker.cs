using Ur_Rtde;
using Mycode;
using System.Diagnostics;
using System;
using System.Threading.Tasks;
using System.Text.Json;
public class BackgroundRTED
{
    Thread t1;
    Thread t2;
    public static RtdeClient st1RtdeClient;
    public static RtdeClient st2RtdeClient;
    public static RtdeClient st3RtdeClient;
    public static RtdeClient st4RtdeClient;
    public static RtdeClient st5RtdeClient;
    static UniversalRobot_Outputs st1UrOutputs = new UniversalRobot_Outputs();
    static UniversalRobot_Outputs st2UrOutputs = new UniversalRobot_Outputs();
    static UniversalRobot_Outputs st3UrOutputs = new UniversalRobot_Outputs();
    static UniversalRobot_Outputs st4UrOutputs = new UniversalRobot_Outputs();
    static UniversalRobot_Outputs st5UrOutputs = new UniversalRobot_Outputs();

    private SteamingJson st1Steam;
    private SteamingJson st2Steam;
    private SteamingJson st3Steam;
    private SteamingJson st4Steam;
    private SteamingJson st5Steam;

    private PreformanceJson st1Preformance;
    private PreformanceJson st2Preformance;
    private PreformanceJson st3Preformance;
    private PreformanceJson st4Preformance;
    private PreformanceJson st5Preformance;

    private ForceTorqueJson st1ForceTorque;
    private ForceTorqueJson st2ForceTorque;
    private ForceTorqueJson st3ForceTorque;
    private ForceTorqueJson st4ForceTorque;
    private ForceTorqueJson st5ForceTorque;

    public BackgroundRTED()
    {
        try{
            st1RtdeClient = new RtdeClient();
            st2RtdeClient = new RtdeClient();
            st3RtdeClient = new RtdeClient();
            st4RtdeClient = new RtdeClient();
            st5RtdeClient = new RtdeClient();

            st1Steam = new SteamingJson{
                actual_q = st1UrOutputs.actual_q,
                actual_qd = st1UrOutputs.actual_qd,
                actual_current = st1UrOutputs.actual_current,
                joint_temperatures = st1UrOutputs.joint_temperatures,
                actual_joint_voltage = st1UrOutputs.actual_joint_voltage,
                speed_scaling = st1UrOutputs.speed_scaling
            };
            st2Steam = new SteamingJson{
                actual_q = st2UrOutputs.actual_q,
                actual_qd = st2UrOutputs.actual_qd,
                actual_current = st2UrOutputs.actual_current,
                joint_temperatures = st2UrOutputs.joint_temperatures,
                actual_joint_voltage = st2UrOutputs.actual_joint_voltage,
                speed_scaling = st2UrOutputs.speed_scaling
            };
            st3Steam = new SteamingJson{
                actual_q = st3UrOutputs.actual_q,
                actual_qd = st3UrOutputs.actual_qd,
                actual_current = st3UrOutputs.actual_current,
                joint_temperatures = st3UrOutputs.joint_temperatures,
                actual_joint_voltage = st3UrOutputs.actual_joint_voltage,
                speed_scaling = st3UrOutputs.speed_scaling
            };
            st4Steam = new SteamingJson{
                actual_q = st4UrOutputs.actual_q,
                actual_qd = st4UrOutputs.actual_qd,
                actual_current = st4UrOutputs.actual_current,
                joint_temperatures = st1UrOutputs.joint_temperatures,
                actual_joint_voltage = st1UrOutputs.actual_joint_voltage,
                speed_scaling = st4UrOutputs.speed_scaling
            };
            st5Steam = new SteamingJson{
                actual_q = st5UrOutputs.actual_q,
                actual_qd = st5UrOutputs.actual_qd,
                actual_current = st5UrOutputs.actual_current,
                joint_temperatures = st5UrOutputs.joint_temperatures,
                actual_joint_voltage = st5UrOutputs.actual_joint_voltage,
                speed_scaling = st5UrOutputs.speed_scaling
            };

            st1Preformance = new PreformanceJson{
                robot_status_bits = st1UrOutputs.robot_status_bits,
                runtime_state = st1UrOutputs.runtime_state,
                safety_status_bits = st1UrOutputs.safety_status_bits,
                actual_robot_voltage = st1UrOutputs.actual_robot_voltage,
                actual_robot_current = st1UrOutputs.actual_robot_current,      
                speed_scaling = st1UrOutputs.speed_scaling    
            };
            st2Preformance = new PreformanceJson{
                robot_status_bits = st2UrOutputs.robot_status_bits,
                runtime_state = st2UrOutputs.runtime_state,
                safety_status_bits = st2UrOutputs.safety_status_bits,
                actual_robot_voltage = st2UrOutputs.actual_robot_voltage,
                actual_robot_current = st2UrOutputs.actual_robot_current,      
                speed_scaling = st2UrOutputs.speed_scaling    
            };
            st3Preformance = new PreformanceJson{
                robot_status_bits = st3UrOutputs.robot_status_bits,
                runtime_state = st3UrOutputs.runtime_state,
                safety_status_bits = st3UrOutputs.safety_status_bits,
                actual_robot_voltage = st3UrOutputs.actual_robot_voltage,
                actual_robot_current = st3UrOutputs.actual_robot_current,  
                speed_scaling = st3UrOutputs.speed_scaling
            };
            st4Preformance = new PreformanceJson{
                robot_status_bits = st4UrOutputs.robot_status_bits,
                runtime_state = st4UrOutputs.runtime_state,
                safety_status_bits = st4UrOutputs.safety_status_bits,
                actual_robot_voltage = st4UrOutputs.actual_robot_voltage,
                actual_robot_current = st4UrOutputs.actual_robot_current,
                speed_scaling = st4UrOutputs.speed_scaling          
            };
            st5Preformance = new PreformanceJson{
                robot_status_bits = st5UrOutputs.robot_status_bits,
                runtime_state = st5UrOutputs.runtime_state,
                safety_status_bits = st5UrOutputs.safety_status_bits,
                actual_robot_voltage = st5UrOutputs.actual_robot_voltage,
                actual_robot_current = st5UrOutputs.actual_robot_current,
                speed_scaling = st5UrOutputs.speed_scaling
            };

            
            st1ForceTorque = new ForceTorqueJson{
                actual_TCP_force = st1UrOutputs.actual_TCP_force,
                tcp_force_scalar = st1UrOutputs.tcp_force_scalar,
                speed_scaling = st1UrOutputs.speed_scaling
            };
            st2ForceTorque = new ForceTorqueJson{
                actual_TCP_force = st2UrOutputs.actual_TCP_force,
                tcp_force_scalar = st2UrOutputs.tcp_force_scalar,
                speed_scaling = st2UrOutputs.speed_scaling
            };
            st3ForceTorque = new ForceTorqueJson{
                actual_TCP_force = st3UrOutputs.actual_TCP_force,
                tcp_force_scalar = st3UrOutputs.tcp_force_scalar,
                speed_scaling = st3UrOutputs.speed_scaling
            };
            st4ForceTorque = new ForceTorqueJson{
                actual_TCP_force = st4UrOutputs.actual_TCP_force,
                tcp_force_scalar = st4UrOutputs.tcp_force_scalar,
                speed_scaling = st4UrOutputs.speed_scaling
            };
            st5ForceTorque = new ForceTorqueJson{
                actual_TCP_force = st5UrOutputs.actual_TCP_force,
                tcp_force_scalar = st5UrOutputs.tcp_force_scalar,
                speed_scaling = st5UrOutputs.speed_scaling
            };
            



            LogMesg("Application","RTDE Server Steaming Start...");
            t1 = new Thread(new ThreadStart(Thread1));
            t1.Start();
            t2 = new Thread(new ThreadStart(Thread2));
            t2.Start();

        }catch(Exception ex){
            LogError("sysyem",ex.ToString());
        }

    }
        static void RunNodeScript(string nodePath, string scriptPath)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = nodePath;
                process.StartInfo.Arguments = scriptPath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                Console.WriteLine(output);

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
        private async void Thread2(){
            try{
                                    string nodePath = "node"; // Replace this with the path to your Node.js executable if it's not in the system PATH
            string scriptPath = "E:/MY_WORKSPACE/JOB/AAE/Thai_Metalex/2023/thesis_fontend/server.js"; // Replace this with the path to your Node.js script

            RunNodeScript(nodePath, scriptPath);
            }catch(Exception ex){

            }
        }
    private async void Thread1(){
        
        try{

            while(true){


                
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("+-----------------------------------------------------------+");
            Console.WriteLine("\t\tStart & Stop RTDE\n S1 is Start RTDE Station1 | E1 is End RTDE Station1 | ls show status");
            string userCommand = Console.ReadLine();

            if(userCommand.ToUpper() == "S1"){station1Connect(_st1IP);
            }

            else if(userCommand.ToUpper() == "E1"){station1Discconect();}

            else if(userCommand.ToUpper() == "S2"){station2Connect(_st2IP);}

            else if(userCommand.ToUpper() == "E2"){station2Discconect();}

            else if(userCommand.ToUpper() == "S3"){station3Connect(_st3IP);}

            else if(userCommand.ToUpper() == "E3"){station3Discconect();}

            else if(userCommand.ToUpper() == "S4"){station4Connect(_st4IP);}

            else if(userCommand.ToUpper() == "E4"){station4Discconect();}

            else if(userCommand.ToUpper() == "S5")
            {
                    station5Connect(_st5IP);    
            }

            else if(userCommand.ToUpper() == "E5"){station5Discconect();}
            else if(userCommand.ToUpper() == "SA")
            {
                station1Connect(_st1IP);
                station2Connect(_st2IP);
                station3Connect(_st3IP);
                station4Connect(_st4IP);
                station5Connect(_st5IP);

                StationStatus();
            }
        else if(userCommand.ToUpper() == "EA")
            {
               await station1Discconect();
               await station2Discconect();
               await station3Discconect();
               await station4Discconect();
               await station5Discconect();

                StationStatus();
            }
            else if(userCommand.ToUpper() == "LS")
            {
                StationStatus();
            }
           
            else{LogWarn("User","Not Command");}

            // Console.Clear();
            LogMesg("User",userCommand);
            // Console.WriteLine("+-----------------------------------------------------------+");
            //Reconnection

            Thread.Sleep(100);
            }

        }catch(Exception ex){
            LogError("System",ex.ToString());
        }
    }

        public async Task<int> MyAsyncMethod()
    {
        // Simulating an asynchronous operation that returns an integer after some delay
        await Task.Delay(500); // This delays execution for 2000 milliseconds (2 seconds)
        return 42;
    }


    #region  |----------------[ Static variable & property ]--------------------|


    // Statatic
    private static string _st1IP = "192.168.1.111";
    private static string _st2IP = "192.168.1.112";
    private static string _st3IP = "192.168.1.113";
    private static string _st4IP = "192.168.1.114";
    private static string _st5IP = "192.168.47.128";
    private static bool _st1Status = false;
    private static bool _st2Status = false;
    private static bool _st3Status = false;
    private static bool _st4Status = false;
    private static bool _st5Status = false;

    // property public
    public String ST1Address{get { return _st1IP; }}
    public String ST2Address{get { return _st2IP; }}
    public String ST3Address{get { return _st3IP; }}
    public String ST4Address{get { return _st4IP; }}
    public String ST5Address{get { return _st5IP; }}
    public bool ST1Status{get { return _st1Status; }}
    public bool ST2Status{get { return _st2Status; }}
    public bool ST3Status{get { return _st3Status; }}
    public bool ST4Status{get { return _st4Status; }}
    public bool ST5Status{get { return _st5Status; }}

    #endregion

    #region |----------------[ Log Console ]--------------------|
    private void LogError(string station,string msg)
    {
    Console.ForegroundColor = ConsoleColor.Red; 
    string head = "LOG-Error [" + DateTime.Now.ToString() +"]\t" ;
    string title = station +" : \b ";
    string body = msg;
    string show = head + title + body;
    Console.WriteLine(show);
    }
    private void LogMesg(string station,string msg)
    {
    Console.ForegroundColor = ConsoleColor.Green; 
    string head = "LOG-Message [" + DateTime.Now.ToString() +"]\t" ;
    string title = station +" : \b ";
    string body = msg;
    string show = head + title + body;
    Console.WriteLine(show);
    }
    private void LogWarn(string station,string msg)
    {
    Console.ForegroundColor = ConsoleColor.Yellow; 
    string head = "LOG-Warning [" + DateTime.Now.ToString() +"]\t" ;
    string title = station +" : \b ";
    string body = msg;
    string show = head + title + body;
    Console.WriteLine(show);
    }
    
    private void StationStatus(){
                        Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("|---------- RTDE STATUS --------|");
                Console.WriteLine(
                    "\tStation 1 (Screwing)\t["+_st1IP +"] ==>  " + _st1Status + "\n"+
                    "\tStation 2 (Assembly)\t["+_st2IP +"] ==>  " + _st2Status + "\n"+
                    "\tStation 3 (Inspection)\t["+_st3IP +"] ==>  " + _st3Status + "\n"+
                    "\tStation 4 (Palletizer)\t["+_st4IP +"] ==>  " + _st4Status + "\n"+
                    "\tStation 5 (MiR)\t["+_st5IP +"] ==>  " + _st5Status
                );
    }
    #endregion


    #region |----------------[ Station 1 : API Service ]--------------------|

    // Server App API
    public async Task<string> station1Connect(string ip)
    {
    try
    {
    if (_st1Status)
    {
        LogWarn("Station 1 ","RTDE is running !");
        var connection = new ConnectionJson{status = _st1Status,ip = _st1IP};
        string jsonString = JsonSerializer.Serialize(connection);
        return jsonString;
    }

    _st1IP = ip;

    _st1Status = st1RtdeClient.Connect(_st1IP, 2);
    int result = await MyAsyncMethod();
    if (_st1Status)
    {
        st1RtdeClient.Setup_Ur_Outputs(st1UrOutputs, 100);
        st1RtdeClient.OnDataReceive += Station1_OnDataReceive;
        st1RtdeClient.Ur_ControlStart();

        var connection = new ConnectionJson{status = _st1Status,ip = _st1IP};
        string jsonString = JsonSerializer.Serialize(connection);
        LogMesg("Station 1 ","RTDE Steaming Start....");
        return jsonString;
    }
    else
    {
        _st1Status = false;
    var connection = new ConnectionJson{status = _st1Status,ip = _st1IP};
    string jsonString = JsonSerializer.Serialize(connection);
    LogWarn("Station 1 ","Can't Start RTDE Steaming!");
    return jsonString;
    }
    }
    catch (Exception ex)
    {
    LogError("Station 1",ex.ToString());
       _st1Status = false;
    var connection = new ConnectionJson{status = _st1Status,ip = _st1IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    }
    public async Task<string> station1Discconect(){
    try
    {
    st1RtdeClient.OnDataReceive -= Station1_OnDataReceive;
    int result = await MyAsyncMethod();
    _st1Status = st1RtdeClient.Disconnect();
    var connection = new ConnectionJson{status = _st1Status,ip = _st1IP};
    string jsonString = JsonSerializer.Serialize(connection);
    LogMesg("Station 1 ","RTDE Steaming End....");
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 1",ex.ToString());
    _st1Status = false;
    var connection = new ConnectionJson{status = _st1Status,ip = _st1IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    }

    // Web Application API
    public String getStation1Connection()
    {
    try
    {
    var connection = new ConnectionJson{status = _st1Status,ip = _st1IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 1",ex.ToString());
    return ex.ToString();
    }
    }
    public String station1Steam()
    {
    try
    {
    st1Steam.actual_q = st1UrOutputs.actual_q;
    st1Steam.actual_qd = st1UrOutputs.actual_qd;
    st1Steam.actual_current = st1UrOutputs.actual_current;
    st1Steam.joint_temperatures = st1UrOutputs.joint_temperatures;
    st1Steam.actual_joint_voltage = st1UrOutputs.actual_joint_voltage;
    st1Steam.speed_scaling = st1UrOutputs.speed_scaling;
    string jsonString = JsonSerializer.Serialize(st1Steam);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 1",ex.ToString());
    string jsonString = JsonSerializer.Serialize(st1Steam);
    return jsonString;
    }
    }
    public String station1Preformance()
    {
    try
    {
    st1Preformance.robot_status_bits = st1UrOutputs.robot_status_bits;
    st1Preformance.runtime_state = st1UrOutputs.runtime_state;
    st1Preformance.safety_status_bits = st1UrOutputs.safety_status_bits;
    st1Preformance.actual_robot_voltage = st1UrOutputs.actual_robot_voltage;
    st1Preformance.actual_robot_current = st1UrOutputs.actual_robot_current;
    st1Preformance.speed_scaling = st1UrOutputs.speed_scaling;
    string jsonString = JsonSerializer.Serialize(st1Preformance);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 1",ex.ToString());
    string jsonString = JsonSerializer.Serialize(st1Preformance);
    return jsonString;
    }
    }
    
    public String station1ForceTorque(){
        try{
            st1ForceTorque.actual_TCP_force = st1UrOutputs.actual_TCP_force;
            st1ForceTorque.tcp_force_scalar = st1UrOutputs.tcp_force_scalar;
            st1ForceTorque.speed_scaling = st1UrOutputs.speed_scaling;
            string jsonString = JsonSerializer.Serialize(st1ForceTorque);
        return jsonString;
        }catch(Exception ex){
            LogError("Station 1",ex.ToString());
            string jsonString = JsonSerializer.Serialize(st1ForceTorque);
            return jsonString;
        }
    }
    
    #endregion

    #region |----------------[ Station 2 : API Service ]--------------------|

    // Server App API
    public async Task<string> station2Connect(string ip)
    {
    try
    {
    if (_st2Status)
    {
        LogWarn("Station 2 ","RTDE is running !");
        var connection = new ConnectionJson{status = _st2Status,ip = _st2IP};
        string jsonString = JsonSerializer.Serialize(connection);
        return jsonString;
    }

    _st2IP = ip;

    _st2Status = st2RtdeClient.Connect(_st2IP, 2);
    int result = await MyAsyncMethod();
    if (_st2Status)
    {
        st2RtdeClient.Setup_Ur_Outputs(st2UrOutputs, 100);
        st2RtdeClient.OnDataReceive += Station2_OnDataReceive;
        st2RtdeClient.Ur_ControlStart();

        var connection = new ConnectionJson{status = _st2Status,ip = _st2IP};
        string jsonString = JsonSerializer.Serialize(connection);
        LogMesg("Station 2 ","RTDE Steaming Start....");
        return jsonString;
    }
    else
    {
        _st1Status = false;
    var connection = new ConnectionJson{status = _st1Status,ip = _st2IP};
    string jsonString = JsonSerializer.Serialize(connection);
    LogWarn("Station 2 ","Can't Start RTDE Steaming!");
    return jsonString;
    }
    }
    catch (Exception ex)
    {
    LogError("Station 2",ex.ToString());
    _st1Status = false;
    var connection = new ConnectionJson{status = _st1Status,ip = _st2IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    }
    public async Task<string> station2Discconect(){
    try
    {
    st2RtdeClient.OnDataReceive -= Station2_OnDataReceive;
    int result = await MyAsyncMethod();
    _st2Status = st2RtdeClient.Disconnect();
    var connection = new ConnectionJson{status = _st2Status,ip = _st2IP};
    string jsonString = JsonSerializer.Serialize(connection);
    LogMesg("Station 2 ","RTDE Steaming End....");
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 2",ex.ToString());
    _st2Status = false;
    var connection = new ConnectionJson{status = _st2Status,ip = _st2IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    }



    // Web Application API
    public String getStation2Connection()
    {
    try
    {
    var connection = new ConnectionJson{status = _st2Status,ip = _st2IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 2",ex.ToString());
    return ex.ToString();
    }
    }
    public String station2Steam()
    {
    try
    {
    st2Steam.actual_q = st2UrOutputs.actual_q;
    st2Steam.actual_qd = st2UrOutputs.actual_qd;
    st2Steam.actual_current = st2UrOutputs.actual_current;
    st2Steam.joint_temperatures = st2UrOutputs.joint_temperatures;
    st2Steam.actual_joint_voltage = st2UrOutputs.actual_joint_voltage;
    st2Steam.speed_scaling = st2UrOutputs.speed_scaling;
    string jsonString = JsonSerializer.Serialize(st2Steam);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 2",ex.ToString());
    string jsonString = JsonSerializer.Serialize(st2Steam);
    return jsonString;
    }
    }
    public String station2Preformance()
    {
    try
    {
    st2Preformance.robot_status_bits = st2UrOutputs.robot_status_bits;
    st2Preformance.runtime_state = st2UrOutputs.runtime_state;
    st2Preformance.safety_status_bits = st2UrOutputs.safety_status_bits;
    st2Preformance.actual_robot_voltage = st2UrOutputs.actual_robot_voltage;
    st2Preformance.actual_robot_current = st2UrOutputs.actual_robot_current;
    st2Preformance.speed_scaling = st2UrOutputs.speed_scaling;
    string jsonString = JsonSerializer.Serialize(st2Preformance);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 2",ex.ToString());
    string jsonString = JsonSerializer.Serialize(st2Preformance);
    return jsonString;
    }
    }
        public String station2ForceTorque(){
        try{
            st2ForceTorque.actual_TCP_force = st2UrOutputs.actual_TCP_force;
            st2ForceTorque.tcp_force_scalar = st2UrOutputs.tcp_force_scalar;
            st2ForceTorque.speed_scaling = st2UrOutputs.speed_scaling;
            string jsonString = JsonSerializer.Serialize(st2ForceTorque);
        return jsonString;
        }catch(Exception ex){
            LogError("Station 1",ex.ToString());
            string jsonString = JsonSerializer.Serialize(st2ForceTorque);
            return jsonString;
        }
    }
    
    #endregion

    #region |----------------[ Station 3 : API Service ]--------------------|

    // Server App API
    public async Task<string> station3Connect(string ip)
    {
    try
    {
    if (_st3Status)
    {
        LogWarn("Station 3 ","RTDE is running !");
        var connection = new ConnectionJson{status = _st3Status,ip = _st3IP};
        string jsonString = JsonSerializer.Serialize(connection);
        return jsonString;
    }

    _st3IP = ip;

    _st3Status = st3RtdeClient.Connect(_st3IP, 2);
    int result = await MyAsyncMethod();
    if (_st3Status)
    {
        st3RtdeClient.Setup_Ur_Outputs(st3UrOutputs, 100);
        st3RtdeClient.OnDataReceive += Station3_OnDataReceive;
        st3RtdeClient.Ur_ControlStart();

        var connection = new ConnectionJson{status = _st3Status,ip = _st3IP};
        string jsonString = JsonSerializer.Serialize(connection);
        LogMesg("Station 3 ","RTDE Steaming Start....");
        return jsonString;
    }
    else
    {
    _st3Status = false;
    var connection = new ConnectionJson{status = _st3Status,ip = _st3IP};
    string jsonString = JsonSerializer.Serialize(connection);
    LogWarn("Station 3 ","Can't Start RTDE Steaming!");
    return jsonString;
    }
    }
    catch (Exception ex)
    {
    LogError("Station 3",ex.ToString());
    _st3Status = false;
    var connection = new ConnectionJson{status = _st3Status,ip = _st3IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    }



    public async Task<string> station3Discconect(){
    try
    {
    st3RtdeClient.OnDataReceive -= Station3_OnDataReceive;
    int result = await MyAsyncMethod();
    _st3Status = st3RtdeClient.Disconnect();
    var connection = new ConnectionJson{status = _st3Status,ip = _st3IP};
    string jsonString = JsonSerializer.Serialize(connection);
    LogMesg("Station 3 ","RTDE Steaming End....");
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 3",ex.ToString());
    _st3Status = false;
    var connection = new ConnectionJson{status = _st3Status,ip = _st3IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    }



    // Web Application API
    public String getStation3Connection()
    {
    try
    {
    var connection = new ConnectionJson{status = _st3Status,ip = _st3IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 3",ex.ToString());
    return ex.ToString();
    }
    }
    public String station3Steam()
    {
    try
    {
    st3Steam.actual_q = st3UrOutputs.actual_q;
    st3Steam.actual_qd = st3UrOutputs.actual_qd;
    st3Steam.actual_current = st3UrOutputs.actual_current;
    st3Steam.joint_temperatures = st3UrOutputs.joint_temperatures;
    st3Steam.actual_joint_voltage = st3UrOutputs.actual_joint_voltage;
    st3Steam.speed_scaling = st3UrOutputs.speed_scaling;
    string jsonString = JsonSerializer.Serialize(st3Steam);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 3",ex.ToString());
    string jsonString = JsonSerializer.Serialize(st3Steam);
    return jsonString;
    }
    }
    public String station3Preformance()
    {
    try
    {
    st3Preformance.robot_status_bits = st3UrOutputs.robot_status_bits;
    st3Preformance.runtime_state = st3UrOutputs.runtime_state;
    st3Preformance.safety_status_bits = st3UrOutputs.safety_status_bits;
    st3Preformance.actual_robot_voltage = st3UrOutputs.actual_robot_voltage;
    st3Preformance.actual_robot_current = st3UrOutputs.actual_robot_current;
    st3Preformance.speed_scaling = st3UrOutputs.speed_scaling;
    string jsonString = JsonSerializer.Serialize(st3Preformance);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 3",ex.ToString());
    string jsonString = JsonSerializer.Serialize(st3Preformance);
    return jsonString;
    }
    }


        public String station3ForceTorque(){
        try{
            st3ForceTorque.actual_TCP_force = st3UrOutputs.actual_TCP_force;
            st3ForceTorque.tcp_force_scalar = st3UrOutputs.tcp_force_scalar;
            st3ForceTorque.speed_scaling = st3UrOutputs.speed_scaling;
            string jsonString = JsonSerializer.Serialize(st3ForceTorque);
        return jsonString;
        }catch(Exception ex){
            LogError("Station 1",ex.ToString());
            string jsonString = JsonSerializer.Serialize(st3ForceTorque);
            return jsonString;
        }
    }
    
    #endregion

    #region |----------------[ Station 4 : API Service ]--------------------|

    // Server App API
    public async Task<string> station4Connect(string ip)
    {
    try
    {
    if (_st4Status)
    {
        LogWarn("Station 4 ","RTDE is running !");
        var connection = new ConnectionJson{status = _st4Status,ip = _st4IP};
        string jsonString = JsonSerializer.Serialize(connection);
        return jsonString;
    }

    _st4IP = ip;

    _st4Status = st4RtdeClient.Connect(_st4IP, 2);
    int result = await MyAsyncMethod();
    if (_st4Status)
    {
        st4RtdeClient.Setup_Ur_Outputs(st4UrOutputs, 100);
        st4RtdeClient.OnDataReceive += Station4_OnDataReceive;
        st4RtdeClient.Ur_ControlStart();

        var connection = new ConnectionJson{status = _st4Status,ip = _st4IP};
        string jsonString = JsonSerializer.Serialize(connection);
        LogMesg("Station 4 ","RTDE Steaming Start....");
        return jsonString;
    }
    else
    {
        _st4Status = false;
    var connection = new ConnectionJson{status = _st4Status,ip = _st4IP};
    string jsonString = JsonSerializer.Serialize(connection);
    LogWarn("Station 4 ","Can't Start RTDE Steaming!");
    return jsonString;
    }
    }
    catch (Exception ex)
    {
    LogError("Station 4",ex.ToString());
    _st4Status = false;
    var connection = new ConnectionJson{status = _st4Status,ip = _st4IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    }



    public async Task<string> station4Discconect(){
    try
    {
    st4RtdeClient.OnDataReceive -= Station4_OnDataReceive;
    int result = await MyAsyncMethod();
    _st4Status = st4RtdeClient.Disconnect();
    var connection = new ConnectionJson{status = _st4Status,ip = _st4IP};
    string jsonString = JsonSerializer.Serialize(connection);
    LogMesg("Station 4 ","RTDE Steaming End....");
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 4",ex.ToString());
        _st4Status = false;
    var connection = new ConnectionJson{status = _st4Status,ip = _st4IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    }



    // Web Application API
    public String getStation4Connection()
    {
    try
    {
    var connection = new ConnectionJson{status = _st4Status,ip = _st4IP};
    string jsonString = JsonSerializer.Serialize(connection);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 4",ex.ToString());
    return ex.ToString();
    }
    }
    public String station4Steam()
    {
    try
    {
    st4Steam.actual_q = st4UrOutputs.actual_q;
    st4Steam.actual_qd = st4UrOutputs.actual_qd;
    st4Steam.actual_current = st4UrOutputs.actual_current;
    st4Steam.joint_temperatures = st4UrOutputs.joint_temperatures;
    st4Steam.actual_joint_voltage = st4UrOutputs.actual_joint_voltage;
    st4Steam.speed_scaling = st4UrOutputs.speed_scaling;
    string jsonString = JsonSerializer.Serialize(st4Steam);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 4",ex.ToString());
    string jsonString = JsonSerializer.Serialize(st4Steam);
    return jsonString;
    }
    }
    public String station4Preformance()
    {
    try
    {
    st4Preformance.robot_status_bits = st4UrOutputs.robot_status_bits;
    st4Preformance.runtime_state = st4UrOutputs.runtime_state;
    st4Preformance.safety_status_bits = st4UrOutputs.safety_status_bits;
    st4Preformance.actual_robot_voltage = st4UrOutputs.actual_robot_voltage;
    st4Preformance.actual_robot_current = st4UrOutputs.actual_robot_current;
    st4Preformance.speed_scaling = st4UrOutputs.speed_scaling;
    string jsonString = JsonSerializer.Serialize(st4Preformance);
    return jsonString;
    }
    catch (Exception ex)
    {
    LogError("Station 4",ex.ToString());
    string jsonString = JsonSerializer.Serialize(st4Preformance);
    return jsonString;
    }
    }

        public String station4ForceTorque(){
        try{
            st4ForceTorque.actual_TCP_force = st4UrOutputs.actual_TCP_force;
            st4ForceTorque.tcp_force_scalar = st4UrOutputs.tcp_force_scalar;
            st4ForceTorque.speed_scaling = st4UrOutputs.speed_scaling;
            string jsonString = JsonSerializer.Serialize(st4ForceTorque);
        return jsonString;
        }catch(Exception ex){
            LogError("Station 1",ex.ToString());
            string jsonString = JsonSerializer.Serialize(st4ForceTorque);
            return jsonString;
        }
    }

    
    #endregion

    #region |----------------[ Station 5 : API Service ]--------------------|

    // Server App API
    public async Task<string> station5Connect(string ip)
    {
        try
        {
            if (_st5Status)
            {
                LogWarn("Station 5 ","RTDE is running !");
                var connection = new ConnectionJson{status = _st5Status,ip = _st5IP};
                string jsonString = JsonSerializer.Serialize(connection);
                return jsonString;
            }
            
            _st5IP = ip;

            _st5Status = st5RtdeClient.Connect(_st5IP, 2);
            int result = await MyAsyncMethod();
            if (_st5Status)
            {
                st5RtdeClient.Setup_Ur_Outputs(st5UrOutputs, 100);
                st5RtdeClient.OnDataReceive += Station5_OnDataReceive;
                st5RtdeClient.OnSockClosed += Station5_OnSockClosed;
                st5RtdeClient.Ur_ControlStart();

                var connection = new ConnectionJson{status = _st5Status,ip = _st5IP};
                string jsonString = JsonSerializer.Serialize(connection);
                LogMesg("Station 5 ","RTDE Steaming Start....");
                return jsonString;
            }
            else
            {
                _st5Status = false;
            var connection = new ConnectionJson{status = _st5Status,ip = _st5IP};
            string jsonString = JsonSerializer.Serialize(connection);
            LogWarn("Station 5 ","Can't Start RTDE Steaming!");
            return jsonString;
            }
        }
        catch (Exception ex)
            {
            LogError("Station 5",ex.ToString());
            _st5Status = false;
            var connection = new ConnectionJson{status = _st5Status,ip = _st5IP};
            string jsonString = JsonSerializer.Serialize(connection);
            return jsonString;
        }
    }

    private void Station5_OnSockClosed(object? sender, EventArgs e)
    {
        Console.WriteLine("AAAAADDD");

    }

    public async Task<string> station5Discconect(){
        try
        {
            st5RtdeClient.OnDataReceive -= Station5_OnDataReceive;
            int result = await MyAsyncMethod();
            _st5Status = st5RtdeClient.Disconnect();
            var connection = new ConnectionJson{status = _st5Status,ip = _st5IP};
            string jsonString = JsonSerializer.Serialize(connection);
            LogMesg("Station 5 ","RTDE Steaming End....");
            return jsonString;
        }
        catch (Exception ex)
        {
            LogError("Station 5",ex.ToString());
            _st5Status = false;
            var connection = new ConnectionJson{status = _st5Status,ip = _st5IP};
            string jsonString = JsonSerializer.Serialize(connection);
            return jsonString;
        }
    }


    // Web Application API
    public String getStation5Connection()
    {
        try
        {
            var connection = new ConnectionJson{status = _st5Status,ip = _st5IP};
            string jsonString = JsonSerializer.Serialize(connection);
            return jsonString;
        }
        catch (Exception ex)
        {
            LogError("Station 5",ex.ToString());
            return ex.ToString();
        }
    }   public String station5Steam()
    {
        try
        {
            st5Steam.actual_q = st5UrOutputs.actual_q;
            st5Steam.actual_qd = st5UrOutputs.actual_qd;
            st5Steam.actual_current = st5UrOutputs.actual_current;
            st5Steam.joint_temperatures = st5UrOutputs.joint_temperatures;
            st5Steam.actual_joint_voltage = st5UrOutputs.actual_joint_voltage;
            st5Steam.speed_scaling = st5UrOutputs.speed_scaling;
            string jsonString = JsonSerializer.Serialize(st5Steam);
            return jsonString;
        }
        catch (Exception ex)
        {
            LogError("Station 5",ex.ToString());
            string jsonString = JsonSerializer.Serialize(st5Steam);
            return jsonString;
        }
    }
    public String station5Preformance()
    {
        try
            {
            st5Preformance.robot_status_bits = st5UrOutputs.robot_status_bits;
            st5Preformance.runtime_state = st5UrOutputs.runtime_state;
            st5Preformance.safety_status_bits = st5UrOutputs.safety_status_bits;
            st5Preformance.actual_robot_voltage = st5UrOutputs.actual_robot_voltage;
            st5Preformance.actual_robot_current = st5UrOutputs.actual_robot_current;
            st5Preformance.speed_scaling = st5UrOutputs.speed_scaling;
            string jsonString = JsonSerializer.Serialize(st5Preformance);
            return jsonString;
        }
        catch (Exception ex)
        {
            LogError("Station 5",ex.ToString());
            string jsonString = JsonSerializer.Serialize(st5Preformance);
            return jsonString;
        }
    }
    
        public String station5ForceTorque(){
        try{
            st5ForceTorque.actual_TCP_force = st5UrOutputs.actual_TCP_force;
            st5ForceTorque.tcp_force_scalar = st5UrOutputs.tcp_force_scalar;
            st5ForceTorque.speed_scaling = st5UrOutputs.speed_scaling;
            string jsonString = JsonSerializer.Serialize(st5ForceTorque);
        return jsonString;
        }catch(Exception ex){
            LogError("Station 1",ex.ToString());
            string jsonString = JsonSerializer.Serialize(st5ForceTorque);
            return jsonString;
        }
    }
   
   private double[] Stationtimestamp(){
    double[] _timestmp = new double[6];
    try{
        _timestmp = [st1UrOutputs.timestamp,st2UrOutputs.timestamp,st3UrOutputs.timestamp,st5UrOutputs.timestamp];
        return _timestmp;
    }
    catch(Exception ex){
        return _timestmp;
    }
   }
   
   
    #endregion
    
    private void Station1_OnDataReceive(object? sender, EventArgs e)
    {
    //
    }
    private void Station2_OnDataReceive(object? sender, EventArgs e)
        {
    throw new NotImplementedException();
    }
        private void Station3_OnDataReceive(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

        private void Station4_OnDataReceive(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
        private void Station5_OnDataReceive(object? sender, EventArgs e)
    {
        // Console.WriteLine(st5UrOutputs.Equals(st5UrOutputs));
        // _st5Status = st5UrOutputs.Equals(st5UrOutputs);
    }

}


#region Json Strcuture Data Class
public class PreformanceJson
{
    public uint robot_status_bits { get; set; }
    public uint runtime_state { get; set; }
    public uint safety_status_bits { get; set; }
    public double actual_robot_voltage { get; set; }
    public double actual_robot_current { get; set; }
    public double speed_scaling { get; set; }
}
public class SteamingJson
{
    public double[] actual_q { get; set; } = new double[6];
    public double[] actual_qd { get; set; } = new double[6];
    public double[] actual_current { get; set; } = new double[6];
    public double[] joint_temperatures { get; set; } = new double[6];
    public double[] actual_joint_voltage { get; set; } = new double[6];
    public double speed_scaling { get; set; }
}
public class ForceTorqueJson{
    
    public double[] actual_TCP_force { get; set; } = new double[6];
    public double tcp_force_scalar { get; set; }
    public double speed_scaling { get; set; }
}
public class ConnectionJson
{
    public bool status { get; set; }
    public string ip { get; set; }
}
#endregion