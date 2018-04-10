using System;

namespace DesignPatterns
{
    /*
     We chose this pattern because,
     1. we want to have a unique instance throughout the application with state (device states) loaded once (initial).
     2. we want to have device initialization once (initial).
     3. we want to have single and global access point.
     */
    public sealed class DeviceManager
    {
        private static volatile Lazy<DeviceManager> _instance = new Lazy<DeviceManager>(() => new DeviceManager(), true);
        public static DeviceManager Instance => _instance.Value;

        private DeviceManager() { /* to do*/ }

        /*
         * remaining code
         */
    }
}
