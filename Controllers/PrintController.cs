using DocRaptor.Api;
using DocRaptor.Client;
using DocRaptor.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintController : Controller
    {
        public PrintController(IDataProvider provider)
        {
            Provider = provider;
        }

        public IDataProvider Provider { get; }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            //var countries = Countries;
            var countries = await Provider.GetAll();
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            return new OkObjectResult(countries);
        }

        // GET api/values/5
        [HttpGet("{code}")]
        public async Task<ActionResult> Get(string code)
        {
            var result = await Provider.Get(code);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Access-Control-Allow-Credentials", "true");

            return new OkObjectResult(result);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PrintDetail print)
        {
            try
            {
                Configuration.Default.Username = "4Xb9iRfAYvDay7E0hu4U";
                var docraptor = new DocApi();

                var princeOptions = new PrinceOptions
                {
                    Baseurl =  print.BaseUrl
                };

                var doc = new Doc(
                  Test: print.Test,                                                    
                  DocumentContent: print.Content,                                                                      
                  Name:  print.Name,                              
                  DocumentType: Doc.DocumentTypeEnum.Pdf
                );
                doc.PrinceOptions = princeOptions;

                byte[] create_response = await docraptor.CreateDocAsync(doc);
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                Response.Headers.Add("Access-Control-Allow-Credentials", "true");

                return File(create_response, "application/pdf");
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message);
            }
        }
    }
}