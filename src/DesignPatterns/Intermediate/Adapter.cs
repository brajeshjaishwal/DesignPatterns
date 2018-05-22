using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesignPatterns.Intermediate
{
    /* 
    Definition: Convert the interface of a class into another interface clients expect. 
                Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.


    */

    //Adaptee class
    public class RawPumpStatus
    {
        public string Flow;//
        public string APercent, BPercent;//
    }

    //Adapter class
    public class Converter
    {
        public static ProcessedPumpStatus ConvertPumpStatus(RawPumpStatus status)
        {
            ProcessedPumpStatus _temp = new ProcessedPumpStatus();
            double.TryParse(status.Flow, out _temp.Flow);
            _temp.Running = _temp.Flow > 0;
            double APercent, BPercent;
            double.TryParse(status.APercent, out APercent);
            double.TryParse(status.BPercent, out BPercent);

            _temp.AFlow = (APercent / 100) * _temp.Flow;
            _temp.BFlow = (BPercent / 100) * _temp.Flow;
            return _temp;
        }
    }

    //Target class
    public class ProcessedPumpStatus
    {
        public bool Running;
        public double Flow, AFlow, BFlow;
    }
    public class Adapter
    {
    }
}
