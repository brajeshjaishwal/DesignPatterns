using BinaryFormatter;
using System;


namespace DesignPatterns.Beginner
{
    public static class CloneManager
    {
        public static T DeepCopy<T>(this T t)
        {
            var formatter = new BinaryConverter();
            byte [] raw = formatter.Serialize(t);
            return formatter.Deserialize<T>(raw);
        }
    }

    [Serializable]
    public class Address
    {
        public string [] Names = new string[]{"first", "second"};
        public string PinCode = "302029";
        
        public Address() {}
    }
}
