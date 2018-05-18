using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Beginner
{
    /*
     As the defination goes:
     A factory is the location of a concrete class in the code at which objects are constructed.

     The intent in employing the pattern is to insulate the creation of objects from their usage and to create families of related objects without having to depend on their concrete classes.
    
     We chose this pattern because we wanted to have a single access point for instance creation for a family of classes.
     */

    public interface ICollectionManagerFactory
    {
        ICollectionManager GetCollectionManager(DeviceSubGroup type);
    }
    /// <summary>
    /// Implementation of Factory - Used to create objects
    /// </summary>
    public class CollectionManagerFactory : ICollectionManagerFactory
    {
        public ICollectionManager GetCollectionManager(DeviceSubGroup type)
        {
            ICollectionManager cmm = new SimpleCollectionManager();
            switch (type)
            {
                case DeviceSubGroup.OpenbedCollector:
                    return new OpenbedCollectionManager(cmm);
                case DeviceSubGroup.ClosedbedCollector:
                    return new ClosedbedCollectionManager(cmm);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}