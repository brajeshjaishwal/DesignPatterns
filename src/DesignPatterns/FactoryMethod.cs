using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*
     As the defination goes:
     A factory is the location of a concrete class in the code at which objects are constructed.

     The intent in employing the pattern is to insulate the creation of objects from their usage and to create families of related objects without having to depend on their concrete classes.
    
     We chose this pattern because we wanted to have a single access point for instance creation for a family of classes.
     */

    public interface ICollectionManager
    {
        void StartCollection();
        void StopCollection();
    }

    /*
     * Collection manager concrete class handling operations based on open bed system
     */
    public class OpenbedCollectionManager : ICollectionManager
    {
        public void StartCollection()
        {
            // do stuffs related with open bed
        }
        public void StopCollection()
        {
            // do stuffs related with closed bed
        }
    }

    /*
     * Collection manager concrete class handling operations based on closed bed system
     */
    public class ClosebedCollectionManager : ICollectionManager
    {
        public void StartCollection()
        {
            // do stuffs related with closed bed
        }
        public void StopCollection()
        {
            // do stuffs related with closed bed
        }
    }

    public enum DeviceSubGroup { OpenbedCollector, ClosedbedCollector }

    public interface ICollectionMangerFactory
    {
        ICollectionManager GetCollectionManager(DeviceSubGroup type);
    }
    /// <summary>
    /// Implementation of Factory - Used to create objects
    /// </summary>
    public class CollectionMangerFactory : ICollectionMangerFactory
    {
        public ICollectionManager GetCollectionManager(DeviceSubGroup type)
        {
            switch (type)
            {
                case DeviceSubGroup.OpenbedCollector:
                    return new OpenbedCollectionManager();
                case DeviceSubGroup.ClosedbedCollector:
                    return new ClosebedCollectionManager();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}