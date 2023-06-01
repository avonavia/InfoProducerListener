using MySerializer;
using ConfigReader;
using System;

namespace InfoProducer
{
    class Producer
    {
        public static DateTime lastupdate = DateTime.Now;
        public static void Write(string configPath)
        {
            Common common = Common.getInstance();
            Common infoFromConfig = common.DoDeserialization(configPath);

            string filePath = infoFromConfig.FilePath + infoFromConfig.FileName;


            while (true)
            {
                try
                {
                    if (lastupdate.AddSeconds(10) < DateTime.Now)
                    {
                        Random rnd = new Random();
                        int rNum = rnd.Next(0, 90);
                        Information info = new Information();
                        string status = "status" + rNum.ToString();
                        info.Status = status;
                        info.DoSerialization(filePath);
                        lastupdate = DateTime.Now;
                        Console.WriteLine($"Status changed to {status}");
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
