using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace CFDI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class XmlController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}


        [HttpPost]
        public ActionResult<XmlModel> ParseXml([FromForm(Name = "file")] IFormFile file)
        {
            try
            {
                // Leer el archivo XML
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(file.OpenReadStream());

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);

                foreach (XmlAttribute attr in xmlDocument.DocumentElement.Attributes)
                {
                    if (attr.Name.StartsWith("xmlns"))
                    {
                        string prefix = string.Empty;
                        if (attr.Name.Contains(":"))
                        {
                            prefix = attr.Name.Split(':')[1];
                        }
                        nsmgr.AddNamespace(prefix, attr.Value);
                    }
                }

                //nsmgr.AddNamespace("c", nsmgr.LookupNamespace("cfdi"));
                //nsmgr.AddNamespace("t", nsmgr.LookupNamespace("tfd"));

                // Obtener los valores de cada nodo del XML

                //XmlNodeList nodeList = xmlDocument.SelectNodes("//cfdi:Comprobante//cfdi:Emisor", nsmgr);

                //var modelEmisor = new Emisor
                //{
                //    Rfc = xmlDocument.SelectSingleNode("//cfdi:Comprobante//cfdi:Emisor//Rfc").InnerText,
                //    Nombre = xmlDocument.SelectSingleNode("//cfdi:Comprobante//cfdi:Emisor//Nombre").InnerText
                //};

                //return Ok(modelEmisor);

                var modelEmisor = new Emisor();

                // Ejecutar la consulta XPath
                XmlNodeList nodeList = xmlDocument.SelectNodes("//cfdi:Comprobante/cfdi:Emisor", nsmgr);

                // Obtener los valores de los nodos seleccionados
                foreach (XmlNode node in nodeList)
                {
                    // Obtener el valor del atributo "rfc"
                    modelEmisor.Rfc = node.Attributes["Rfc"].Value;

                    // Obtener el valor del atributo "nombre"                   
                    modelEmisor.Nombre = node.Attributes["Nombre"].Value;

                    // Obtener el valor del atributo "regimenFiscal"                    
                    modelEmisor.RegimenFiscal = Convert.ToInt32(node.Attributes["RegimenFiscal"].Value);
                }

                return Ok(modelEmisor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
