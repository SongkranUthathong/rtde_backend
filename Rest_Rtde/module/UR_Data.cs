/*

See :
https://www.universal-robots.com/how-tos-and-faqs/how-to/ur-how-tos/real-time-data-exchange-rtde-guide-22229/ 
 
BOOL : bool
UINT8 : byte
UINT32 : uint
UINT64 : ulong
INT32 : int
DOUBLE : double
VECTOR3D : double[]
VECTOR6D : double []
VECTOR6INT32 : int[]
VECTOR6UINT32 : uint[]
  
TODO and not TODO : do not declare public fields with other types & creates the array with the right size

*/
using System;

namespace Mycode
{

    [Serializable]
    public class UniversalRobot_Outputs
    {

        // Preformance Data
        public UInt32 robot_status_bits;
        public UInt32 runtime_state;
        public UInt32 safety_status_bits;
        public double actual_main_voltage;
        public double actual_robot_voltage;
        public double actual_robot_current;

        // Steaming Data
        public double[] actual_q = new double[6];

        public double[] actual_qd = new double[6];

        public double[] actual_current = new double[6];

        public double[] joint_temperatures = new double[6];
        public double[] actual_joint_voltage = new double[6];

        public double speed_scaling;

        
    }

    [Serializable]
    public class UniversalRobot_Inputs
    {
        public byte tool_digital_output_mask;
        public byte tool_digital_output;
        public double input_double_register_24;
    }

}