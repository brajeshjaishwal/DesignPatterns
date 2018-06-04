using System;

namespace DesignPatterns.Intermediate
{
    /*
     * This patterns talk about the ease in changing strategies at runtime

       Here staragies are treated as concrete classes but used by way of 
       abstraction, that makes it possible to replace them by others at ease
     */

     public class Log {
         //thiw will be exported and written on the disk in various format
     }

     public interface IExportStrategy
     {
         void Export(Log l);
     }

     public class ExportToCSV : IExportStrategy {
         public void Export(Log l)
         {
            //processing done on instance of Log to export to CSV format
            //and written on disk in form of a file
         }
     }

     public class ExportToWord : IExportStrategy {
         public void Export(Log l)
         {
            //processing done on instance of Log to export to CSV format
            //and written on disk in form of a file
         }
     }

     public class Exporter<ES> where ES:IExportStrategy, new ()
     {
         IExportStrategy es = new ES();
         void Export(Log l)
         {
            es.Export(l);
         }
     }
}
