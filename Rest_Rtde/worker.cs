using Ur_Rtde;
using Mycode;
public class BackgroundRTED{
    static RtdeClient rtdeOject;
    static UniversalRobot_Outputs UrOutputs = new UniversalRobot_Outputs();

    public BackgroundRTED(){
    rtdeOject = new RtdeClient();
    Console.WriteLine("Constructor Read!!!");
    }
    public bool rtdeConnect(string ip){
        try{
            
            bool status = rtdeOject.Connect(ip, 2);
            Console.WriteLine(status);
            if (status)
            {
                rtdeOject.Setup_Ur_Outputs(UrOutputs, 100);
                rtdeOject.OnDataReceive += Ur10_OnDataReceive;
                rtdeOject.Ur_ControlStart();
                return true;
            }else{
                return false;
            }
            
        }catch(Exception ex){
            Console.WriteLine(ex);
            return false;
        }
    }

    public bool rtdeDisConnect(){
        try{
             rtdeOject.OnDataReceive -=  Ur10_OnDataReceive;
            rtdeOject.Disconnect();     
            return false;   
        }catch(Exception ex){
            Console.WriteLine(ex);
            return false;
        }
    }

    public double[] actJoint(){
        try{
            return UrOutputs.actual_q;
        }catch(Exception er){
            Console.WriteLine(er);
            return [];
        }
    }

    private void Ur10_OnDataReceive(object? sender, EventArgs e)
        {
        double r2d = (180 / Math.PI);
        Console.WriteLine("[" + (UrOutputs.actual_q[0] * r2d).ToString("0.00") + ","
           + (UrOutputs.actual_q[1] * r2d).ToString("0.00") + ","
           + (UrOutputs.actual_q[2] * r2d).ToString("0.00") + ","
           + (UrOutputs.actual_q[3] * r2d).ToString("0.00") + ","
           + (UrOutputs.actual_q[4] * r2d).ToString("0.00") + ","
           + (UrOutputs.actual_q[5] * r2d).ToString("0.00") + ","
           + "]");
    }
}