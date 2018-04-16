using System;

namespace DesignPatterns
{
    /*
     We chose this pattern because,
     1. we want to have a unique instance throughout the application with state (device states) loaded once (initial).
     2. we want to have device initialization once (initial).
     3. we want to have single and global access point.
     */
    public sealed class DeviceManagerSingleton
    {
        private static volatile Lazy<DeviceManagerSingleton> _instance = new Lazy<DeviceManagerSingleton>(() => new DeviceManagerSingleton(), true);
        public static DeviceManagerSingleton Instance => _instance.Value;

        private DeviceManagerSingleton() { /* to do*/ }

        /*
         * remaining code
         */
    }
}
