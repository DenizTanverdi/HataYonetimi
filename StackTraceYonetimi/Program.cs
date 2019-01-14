using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace StackTraceYonetimi
{
    class Program
    {
        static void Main(string[] args)
        {
            uygulama();
            Console.ReadKey();

        }
        public static void uygulama() {


            try
            {
                string str = "qwe";
                int i = Convert.ToInt32(str);

            }
            catch (Exception)
            {
                // hatanın satır numarasına ulasmak için true değeri verilir
                StackTrace stack = new StackTrace(true);

                foreach (StackFrame frame in stack.GetFrames())
                {
                    if (!string.IsNullOrEmpty(frame.GetFileName()))
                    {
                        Console.WriteLine($"Dosya Adi : {frame.GetFileName()}");
                        Console.WriteLine($"Line Number : {frame.GetFileLineNumber()}");
                        Console.WriteLine($"Column Number : {frame.GetFileColumnNumber()}");
                        Console.WriteLine($"Method Name : {frame.GetMethod()}");



                    }
                }
            }
        }
    }
}
