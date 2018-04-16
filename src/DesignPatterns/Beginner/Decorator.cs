using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns
{
    /*
     * Definition: This pattern allows behavior to be added to an individual object, either statically or dynamically, without affecting the behavior of other objects from the same class.
     * 
     * We used this pattern to decorate device status class's objects to carry added information to the UI side, while they are passed as it is in data writer module.
     */
    public class DeviceConnectionState { }

    /// <summary>
    /// This class is from 3rd party library that we cannot modify
    /// </summary>
    public class DeviceStatus
    {
        public bool Running;
        public DeviceConnectionState ConnectionState;
        public bool Alarm;
        public string AlarmMsg;
        public bool Warning;
        public string WarningMsg;
    }   
    /// <summary>
    /// This class is from 3rd part library that we cannot modify
    /// </summary>
    public class PumpStatus : DeviceStatus
    {
        public double Flow;
        public double Pressure;
    }

    /*
     * Decorate pump status class to hold more customized features
     */
    public class DecoratedPumpStatus
    {
        public DeviceStatus _status;
        public bool FlowEquilibrated; //in case of pump flow should be withing the range
    }
}
