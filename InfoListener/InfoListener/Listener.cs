using System;
using MySerializer;

namespace InfoListener
{
    class Listener
    {
        static string buffer = string.Empty;

        public static DateTime lastupdate = DateTime.Now;
        public static void Read<T>(T info, string readFilePath) where T : Information
        {

            while (true)
            {
                try
                {
                    if (lastupdate.AddSeconds(3) < DateTime.Now)
                        if (buffer != info.DoDeserialization(readFilePath).Status)
                        {
                            buffer = info.DoDeserialization(readFilePath).Status;
                            Console.WriteLine(buffer);
                            lastupdate = DateTime.Now;
                        }
                }
                catch
                {
                    System.Threading.Thread.Sleep(5 * 1000); 
                }
            }
        }
    }
}
