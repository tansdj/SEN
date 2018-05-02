using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    class FileHandler
    {
        private FileStream stream;
        private StreamReader reader;
        private StreamWriter writer;
        private string filePathPrime;

        public FileHandler(string filePathParam)
        {
            this.filePathPrime = filePathParam;
        }

        public void WriteToTxt(List<string> rawData)
        {
            try
            {
                if (File.Exists(filePathPrime))
                {
                    stream = new FileStream(this.filePathPrime, FileMode.Append, FileAccess.Write);
                    writer = new StreamWriter(stream);

                    foreach (string item in rawData)
                    {
                        writer.WriteLine(item);
                        writer.Flush();
                    }
                }
                else
                {
                    stream = new FileStream(this.filePathPrime, FileMode.Create, FileAccess.Write);
                    writer = new StreamWriter(stream);

                    foreach (string item in rawData)
                    {
                        writer.WriteLine(item);
                        writer.Flush();
                    }
                }

            }
            catch (FileNotFoundException)
            {
                FileHandler errorCatching = new FileHandler("FileError.csv");
                errorCatching.WriteToTxt(new List<string>() { string.Format("The mentioned file {0} was not found. TimeStamp:{1}", this.filePathPrime, DateTime.UtcNow.ToShortDateString()) });
            }
            catch (DirectoryNotFoundException)
            {
                FileHandler errorCatching = new FileHandler("FileError.csv");
                errorCatching.WriteToTxt(new List<string>() { string.Format("The mentioned directory {0} was not found. TimeStamp:{1}", this.filePathPrime, DateTime.UtcNow.ToShortDateString()) });
            }
            catch (IOException)
            {
                FileHandler errorCatching = new FileHandler("FileError.csv");
                errorCatching.WriteToTxt(new List<string>() { string.Format("A critical error was encountered while accessing file {0}. TimeStamp:{1}", this.filePathPrime, DateTime.UtcNow.ToShortDateString()) });
            }
            finally
            {
                writer.Close();
                stream.Close();
            }
        }

        public List<string> ReadFromTxt()
        {
            List<string> rawData = new List<string>();

            try
            {
                stream = new FileStream(this.filePathPrime, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(stream);

                while (!reader.EndOfStream)
                {
                    rawData.Add(reader.ReadLine());
                }
            }
            catch (FileNotFoundException)
            {
                FileHandler errorCatching = new FileHandler("FileError.csv");
                errorCatching.WriteToTxt(new List<string>() { string.Format("The mentioned file {0} was not found. TimeStamp:{1}", this.filePathPrime, DateTime.UtcNow.ToShortDateString()) });
            }
            catch (DirectoryNotFoundException)
            {
                FileHandler errorCatching = new FileHandler("FileError.csv");
                errorCatching.WriteToTxt(new List<string>() { string.Format("The mentioned directory {0} was not found. TimeStamp:{1}", this.filePathPrime, DateTime.UtcNow.ToShortDateString()) });
            }
            catch (IOException)
            {
                FileHandler errorCatching = new FileHandler("FileError.csv");
                errorCatching.WriteToTxt(new List<string>() { string.Format("A critical error was encountered while accessing file {0}. TimeStamp:{1}", this.filePathPrime, DateTime.UtcNow.ToShortDateString()) });
            }
            finally
            {
                reader.Close();
                stream.Close();
            }
            return rawData;
        }
    }
}
