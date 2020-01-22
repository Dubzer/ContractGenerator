namespace ContractGenerator
{
    public class TemplateStorage
    {       
        public byte[] TemplateBytes { get; }

        public TemplateStorage(string path) => 
            TemplateBytes = System.IO.File.ReadAllBytes("template.docx");
    }
}