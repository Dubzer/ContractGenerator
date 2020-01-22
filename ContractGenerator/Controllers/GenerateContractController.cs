﻿using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TemplateEngine.Docx;

namespace ContractGenerator.Controllers
{
    [Route("/api/v1/generate_contract")]
    [ApiController]
    public class GenerateContractController : ControllerBase
    {
        private TemplateStorage _templateStorage;

        public GenerateContractController(TemplateStorage templateStorage)
        {
            _templateStorage = templateStorage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var asdasd = HttpContext.Request.Query;
            IContentItem[] fillItems = HttpContext.Request.Query
                .Select(kvp => new FieldContent(kvp.Key, kvp.Value))
                .Cast<IContentItem>().ToArray();
            
            var valuesToFill = new Content(fillItems);
            
            var stream = new MemoryStream();
            stream.Write(_templateStorage.TemplateBytes);
            
            using var output = new TemplateProcessor(stream);
            output.FillContent(valuesToFill).SaveChanges();

            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
        }
    }
}