using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDataBase.BL
{
    public class Parser
    {
        private StreamReader _reader = null;

        public Parser() { }

        public void Parse(string filePath)
        {
            try
            {
                StreamReader _reader = new StreamReader(filePath);
                string currentLine = _reader.ReadLine();
                while(currentLine != null)
                {
                    string[] sailesInfo = currentLine.Split(';');
                    Console.WriteLine(string.Join(" ", sailesInfo));
                    currentLine = _reader.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (_reader != null)
                {
                    _reader.Close();
                }
            }
        }
    }
}
