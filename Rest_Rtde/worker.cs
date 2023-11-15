using Ur_Rtde;
using Mycode;
using System.Threading.Tasks;
public class BackgroundRTED{
    static RtdeClient rtdeOject;
    static UniversalRobot_Outputs UrOutputs = new UniversalRobot_Outputs();
    
    private bool status = false;
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

    public async Task<bool> rtdeConnect(string ip){
        try{
            if(status){return status;}
            status = rtdeOject.Connect(ip, 2);
            int result = await MyAsyncMethod();
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

    public async Task<bool> rtdeDisConnect(){
        try{
            // rtdeOject.Disconnect();
            rtdeOject.OnDataReceive -=  Ur10_OnDataReceive;
            int result = await MyAsyncMethod();
            status = rtdeOject.Disconnect();  
            //  Console.WriteLine(Ur10_OnDataReceive)
                
            return false;   
        }catch(Exception ex){
            Console.WriteLine(ex);
            return false;
        }
    }
        public bool rtdeDisConnect_ex(){
        try{
            //  rtdeOject.OnDataReceive -=  Ur10_OnDataReceive;
            //  Console.WriteLine(Ur10_OnDataReceive)
               
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