using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Beginner
{
    /*
     * Definition: This pattern allows behavior to be added to an individual object, either statically or dynamically, without affecting the behavior of other objects from the same class.
     * 
     * We used this pattern to decorate device status class's objects to carry added information to the UI side, while they are passed as it is in data writer module.
     */

    public enum DeviceSubGroup { OpenbedCollector, ClosedbedCollector }

    public interface ICollectionManager
    {
        void Start();
        void Stop();
    }

    public class SimpleCollectionManager : ICollectionManager
    {
        public void Start()
        {
            // to do
        }

        public void Stop()
        {
            // to do
        }
    }
    /// <summary>
    /// abstract decorator
    /// </summary>
    public abstract class CollectionManager : ICollectionManager
    {
        protected ICollectionManager _icm;

        public CollectionManager(ICollectionManager icm)
        {
            _icm = icm;
        }

        public void Start()
        {
            _icm.Start();
        }

        public void Stop()
        {
            _icm.Stop();
        }
    }

    public class OpenbedCollectionManager : CollectionManager
    {
        public OpenbedCollectionManager(ICollectionManager idm) : base(idm) { }

        public new void Start()
        {
            base.Start();
            //add open system specific implementation
        }

        public new void Stop()
        {
            base.Stop();
            //add open system specific implementation
        }
    }

    public class ClosedbedCollectionManager : CollectionManager
    {
        public ClosedbedCollectionManager(ICollectionManager idm) : base(idm) { }

        public new void Start()
        {
            base.Start();
            //add open system specific implementation
        }

        public new void Stop()
        {
            base.Stop();
            //add open system specific implementation
        }
    }
}
