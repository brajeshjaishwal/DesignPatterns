using System;
using BinaryFormatter;

namespace DesignPatterns.Intermediate
{
    /*
     * This pattern allows an object to create customized objects without knowing their class or any details of how to create them. 
     * 
     * This can be achieved by
     * cloning (shallow or deep, based on requirement), 
     * copy constructor or
     * serialization/deserialization approach
     */
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
