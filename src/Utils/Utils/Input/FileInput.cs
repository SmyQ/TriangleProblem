using System;
using System.IO;

namespace Utils.Input
{
    public class FileInput : IInput, IDisposable
    {
        private String _filePath;
        private StreamReader _fileStream;

        public FileInput(String filePath)
        {
            _filePath = filePath;
        }

        public String FilePath
        {
            get { return _filePath; }
        }

        public StreamReader FileStream
        {
            get
            {
                return _fileStream ?? (_fileStream = new StreamReader(FilePath));
            }
        }

        public String ReadLine()
        {
            return FileStream.ReadLine();
        }

        public void Dispose()
        {
            _fileStream.Dispose();
        }
    }
}
