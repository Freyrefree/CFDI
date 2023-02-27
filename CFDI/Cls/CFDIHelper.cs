using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace CFDI.Cls
{
    public class CFDIHelper
    {
        public static XmlDocument xml;
        public static XmlNamespaceManager nsgmr;

        public static Emisor CFDI_Emisor()
        {
            // Ejecutar la consulta XPath y crear el objeto Emisor
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Emisor", nsgmr);
            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Emisor
                {
                    Rfc = node.Attributes["Rfc"].Value,
                    Nombre = node.Attributes["Nombre"].Value,
                    RegimenFiscal = Convert.ToInt32(node.Attributes["RegimenFiscal"].Value)
                })
                .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró el nodo Emisor en el archivo XML.");
            }

            return data;
        }

        public static Receptor CFDI_Receptor()
        {
            // Ejecutar la consulta XPath y crear el objeto Emisor
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Receptor", nsgmr);
            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Receptor
                {
                    Rfc = node.Attributes["Rfc"].Value,
                    Nombre = node.Attributes["Nombre"].Value,
                    UsoCFDI = node.Attributes["UsoCFDI"].Value,
                    DomicilioFiscalReceptor = Convert.ToInt32(node.Attributes["DomicilioFiscalReceptor"].Value),
                    RegimenFiscalReceptor = Convert.ToInt32(node.Attributes["RegimenFiscalReceptor"].Value)
                })
                .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró el nodo Receptor en el archivo XML.");
            }

            return data;
        }
    }
}
