using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesignPatterns;

namespace TestClass
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DeviceManagerSingleton dm = DeviceManagerSingleton.Instance;
            IDeviceFactory adcf = AbstractDeviceCreationFactory.Instance;
            ICollectionManagerFactory icmf = new CollectionManagerFactory();
            ICollectionManager obcm = icmf.GetCollectionManager(DeviceSubGroup.OpenbedCollector);
            ICollectionManager cbcm = icmf.GetCollectionManager(DeviceSubGroup.ClosedbedCollector);
        }
    }
}
