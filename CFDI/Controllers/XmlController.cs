using CFDI.Cls;
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
        public ActionResult ParseXml([FromForm(Name = "file")] IFormFile file)
        {

            try
            {
                CFDIHelper ObjCFDI = new CFDIHelper();

                CFDIHelper.xml = XmlHelper.LoadXml(file);
                CFDIHelper.nsgmr = XmlHelper.XMLNamespaces(CFDIHelper.xml, file);

                var dataEmisor = CFDIHelper.CFDI_Emisor();
                var dataReceptor = CFDIHelper.CFDI_Receptor();
                var dataConceptos = CFDIHelper.CFDI_Conceptos();


                var CFDI = new Comprobante
                {
                    Emisor = dataEmisor,
                    Receptor = dataReceptor,
                    Conceptos = dataConceptos
                   
                };

                return Ok(CFDI);


                //return Ok(dataEmisor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }





        //private static Emisor CFDI(XmlDocument xml, XmlNamespaceManager nsmgr)
        //{
        //    // Ejecutar la consulta XPath y crear el objeto Emisor
        //    var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Emisor", nsmgr);
        //    var emisor = nodeList
        //        .Cast<XmlNode>()
        //        .Select(node => new Emisor
        //        {
        //            Rfc = node.Attributes["Rfc"].Value,
        //            Nombre = node.Attributes["Nombre"].Value,
        //            RegimenFiscal = Convert.ToInt32(node.Attributes["RegimenFiscal"].Value)
        //        })
        //        .FirstOrDefault();

        //    if (emisor == null)
        //    {
        //        throw new Exception("No se encontró el nodo Emisor en el archivo XML.");
        //    }

        //    return emisor;
        //}


    }
}
