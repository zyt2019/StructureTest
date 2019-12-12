using System;
using System.IO;
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
            SimTaskObject simTask = new SimTaskObject() { MyProperty = "我的属性" };
            string sTemp = Tools.ToXML(simTask);
            Console.WriteLine(sTemp);
            Console.ReadKey();

        }
    }
    public static class Tools
    {
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
        [XmlElement(ElementName = "aaa")]
        public string MyProperty { get; set; }
    }
}
