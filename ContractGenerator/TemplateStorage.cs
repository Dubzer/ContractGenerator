using System.IO;

namespace ContractGenerator
{
    public class TemplateStorage
    {
        public TemplateStorage(string path) => TemplateBytes = File.ReadAllBytes("template.docx");

        public byte[] TemplateBytes { get; }
    }
}