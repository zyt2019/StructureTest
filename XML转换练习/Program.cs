using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XML转换练习
{
    class Program
    {

        public enum DynamicType
        {
            DynamicTorqueCurve,
            DynamicEngineSetup,
            DynamicDifferentialSetup,
            DynamicTransmissionSetup,
            DynamicGearSetup,
            DynamicSteeringCurve,
            DynamicVehicleSetup,
            DynamicVehicleInput,
            DynamicTireBasic,
            DynamicTireSetup,
            DynamicTireSuspension,
            DynamicTireBrakes

        }
        static void Main(string[] args)
        {
            Console.WriteLine((int)DynamicType.DynamicDifferentialSetup);
            Console.ReadKey();

        }
    }
    public static class Tools {
        public static string ToXML(this SimTaskObject simTask)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(simTask.GetType());
                using (MemoryStream ms = new MemoryStream())
                {
                    xs.Serialize(ms, simTask);
                    return System.Text.Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            catch { return string.Empty; }

        }
    }
    [Serializable]
    [XmlRoot("SimTask")]
    public class SimTaskObject
    {
        public string MyProperty { get; set; }
    }
}
