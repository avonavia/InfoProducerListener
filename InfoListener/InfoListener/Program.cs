using ConfigReader;
using MySerializer;

namespace InfoListener
{
    class Program
    {
        static void Main()
        {
            Information info = new Information();

            Common infoFromConfig = Common.getInstance().DoDeserialization(Common.getInstance().ConfigPath);

            string filePath = infoFromConfig.FilePath + infoFromConfig.FileName;

            Listener.Read(info, filePath);
        }
    }
}
