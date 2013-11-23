using System;
using TriangleProblem.Entieties;

namespace TriangleProblem.Utils.Input
{
    public class FileParser : IParser
    {
        private String FilePath { get; set; }

        public FileParser(String filePath)
        {
            FilePath = filePath;
        }

        public Graph Parse()
        {
            throw new NotImplementedException("FileParser.Parse() not implemented");

            Graph graph = new Graph();

            using (FileInput input = new FileInput(FilePath))
            {
                String line;
                while ((line = input.ReadLine()) != null)
                {
                    // TODO
                }
            }

            return graph;
        }
    }
}
