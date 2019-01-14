using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.SqlClient;
using Dapper;
using System.IO;

namespace StackTraceYonetimi
{

    class Program
    {
        static SqlConnection con;
        static void Main(string[] args)
        {
            uygulama();
            Console.ReadKey();

        }
        public static void uygulama()
        {


            try
            {
                string str = "qwe";
                int i = Convert.ToInt32(str);

            }
            catch (Exception ex)
            {
                con = new SqlConnection("Data Source=SEM-BILGISAYAR;Initial Catalog=test;Persist Security Info=True;User ID=test2;Password=test2");
                // hatanın satır numarasına ulasmak için true değeri verilir
                StackTrace stack = new StackTrace(true);

                foreach (StackFrame frame in stack.GetFrames())
                {
                    if (!string.IsNullOrEmpty(frame.GetFileName()))
                    {
                        string gelen = frame.GetFileName().ToString();

                        //Path.GetFileName() adres sadelestiriyo

                        con.Execute("Insert Into HataLoglari(DosyaAdi,MethodAdi,LineNumber,ColumnNumber,message)Values(@DosyaAdi,@MathodAdi,@LineNumber,@ColumnNumber,@message)", new[] { new { @DosyaAdi =Path.GetFileName(frame.GetFileName()),//.Split('\\').Last()
                            @MathodAdi = frame.GetMethod().ToString() ,
                            @LineNumber =frame.GetFileLineNumber().ToString() ,
                            @ColumnNumber = frame.GetFileColumnNumber().ToString(),
                            @message = ex.Message} });
                        Console.WriteLine($"Dosya Adi : {Path.GetFileName(frame.GetFileName())}");
                        Console.WriteLine($"Line Number : {frame.GetFileLineNumber()}");
                        Console.WriteLine($"Column Number : {frame.GetFileLineNumber()}");
                        Console.WriteLine($"Method Name : {frame.GetMethod()}");
                       
                        //header.Trim( new Char[] { ' ', '*', '.' } )

                    }
                }
            }
        }
    }
}
