using System;

namespace DesignPatterns.Intermediate
{
    /*
     * Template Method lets subclasses redefine certain methods of a class without letting them,
     *  to change the class's structure.
     */
    public abstract class OperationTemplate
    {
        public void PerformOperation()
        {
            PerformStep1();
            PerformStep2();
        }
        public abstract void PerformStep1();

        public abstract void PerformStep2();
    }

    public class Operation1 : OperationTemplate
    {
        public override void PerformStep1()
        {
            //redefine step 1
            Console.WriteLine("Operation1.Step1");
        }

        public override void PerformStep2()
        {
            //redefine step 2
            Console.WriteLine("Operation1.Step2");
        }
    }

    public class Operation2 : OperationTemplate
    {
        public override void PerformStep1()
        {
            //redefine step 1
            Console.WriteLine("Operation2.Step1");
        }

        public override void PerformStep2()
        {
            //redefine step 2
            Console.WriteLine("Operation2.Step2");
        }
    }
}
