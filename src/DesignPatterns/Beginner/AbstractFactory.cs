using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * The abstract factory pattern provides a way to encapsulate a group of individual factories that have a common theme without specifying their concrete classes.
 * 
 * The intent in employing this pattern makes it possible to interchange concrete implementations without changing the code that uses them, even at runtime.
 * We chose to use this pattern in our project because we wanted the switch creation/instantiation of device classes dynamically.
 */
namespace DesignPatterns.Beginner
{
    /// <summary>
    /// Different technologies to create device object
    /// </summary>
    public enum DeviceCreationTechnologies { WCF, DotNetRemoting }
    /// <summary>
    /// Interface to device factory
    /// </summary>
    public interface IDeviceFactory
    {
        I_Device CreateDeviceInstance();
        Generic_Method_Panel_Configurator CreateDeviceMethodPanelInstance();
        Generic_Device_Configurator CreateDeviceConfigPanelInstance();
    }
    /// <summary>
    /// Device creation based on WCF
    /// </summary>
    public class DeviceWCFCreator : IDeviceFactory
    {
        public I_Device CreateDeviceInstance()
        {
            throw new NotImplementedException();
        }
        public Generic_Method_Panel_Configurator CreateDeviceMethodPanelInstance()
        {
            throw new NotImplementedException();
        }
        public Generic_Device_Configurator CreateDeviceConfigPanelInstance()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Device creation based on .net remoting
    /// </summary>
    public class DeviceDotNetRemotingCreator : IDeviceFactory
    {
        public I_Device CreateDeviceInstance()
        {
            throw new NotImplementedException();
        }
        public Generic_Method_Panel_Configurator CreateDeviceMethodPanelInstance()
        {
            throw new NotImplementedException();
        }
        public Generic_Device_Configurator CreateDeviceConfigPanelInstance()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Factory to create devices
    /// </summary>
    public class AbstractDeviceCreationFactory : IDeviceFactory
    {
        public IDeviceFactory _deviceFactory;
        private static readonly Lazy<IDeviceFactory> _instance = new Lazy<IDeviceFactory>(() => new AbstractDeviceCreationFactory(DeviceCreationTechnologies.DotNetRemoting));
        public static IDeviceFactory Instance { get { return _instance.Value; } }

        AbstractDeviceCreationFactory(DeviceCreationTechnologies tech)
        {
            try
            {
                switch (tech)
                {
                    case DeviceCreationTechnologies.WCF:
                        _deviceFactory = new DeviceWCFCreator();
                        break;
                    case DeviceCreationTechnologies.DotNetRemoting:
                        _deviceFactory = new DeviceDotNetRemotingCreator();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public I_Device CreateDeviceInstance() => _deviceFactory.CreateDeviceInstance();
        public Generic_Method_Panel_Configurator CreateDeviceMethodPanelInstance() => _deviceFactory.CreateDeviceMethodPanelInstance();
        public Generic_Device_Configurator CreateDeviceConfigPanelInstance() => _deviceFactory.CreateDeviceConfigPanelInstance();
    }



    //required definitions
    public interface I_Device { }
    public interface Generic_Method_Panel_Configurator { }
    public interface Generic_Device_Configurator { }
    public interface DeviceRegistrySettingsInfo { }
}
