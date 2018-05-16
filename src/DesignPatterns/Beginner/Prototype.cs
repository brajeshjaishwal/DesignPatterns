using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
namespace DesignPatterns
{
    public static class CloneManager
    {
        public static T DeepCopy<T>(this T t)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, t);
            stream.Seek(0, SeekOrigin.Begin);
            T ret = (T) formatter.Deserialize(stream);
            stream.Close();
            return ret;
        }
    }

    public class Address
    {
        public string [] Names = new string[]{"first", "second"};
        public string PinCode = "302029";
    }

    public class Demo
    {
        public static Main(string [] args)
        {
            Address add = new Address();
            Address add2 = add.DeepCopy();
        }
    }
}
