using ConfigReader;

namespace InfoProducer
{
    class Program
    {
        static void Main()
        {
            string path = Common.getInstance().ConfigPath;
            Producer.Write(path);
        }
    }
}
