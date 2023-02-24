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
                var xml = XmlHelper.LoadXml(file);

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml.NameTable);

                foreach (XmlAttribute attr in xml.DocumentElement.Attributes)
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

                var dataCFDI = CFDI(xml, nsmgr);

                return Ok(dataCFDI);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        private static Emisor CFDI(XmlDocument xml, XmlNamespaceManager nsmgr)
        {
            // Ejecutar la consulta XPath y crear el objeto Emisor
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Emisor", nsmgr);
            var emisor = nodeList
                .Cast<XmlNode>()
                .Select(node => new Emisor
                {
                    Rfc = node.Attributes["Rfc"].Value,
                    Nombre = node.Attributes["Nombre"].Value,
                    RegimenFiscal = Convert.ToInt32(node.Attributes["RegimenFiscal"].Value)
                })
                .FirstOrDefault();

            if (emisor == null)
            {
                throw new Exception("No se encontró el nodo Emisor en el archivo XML.");
            }

            return emisor;
        }


    }
}
