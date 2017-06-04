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
                _reader = new StreamReader(filePath);
                string currentLine = _reader.ReadLine();

                Console.WriteLine("File name: {0}", Path.GetFileName(filePath));
                while (currentLine != null)
                {
                    string[] sailesInfo = currentLine.Split(';');
                    Console.WriteLine(string.Join(" ", sailesInfo));
                    currentLine = _reader.ReadLine();
                }
                Console.WriteLine("\n");
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
