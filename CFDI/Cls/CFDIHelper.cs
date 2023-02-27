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

        public static Conceptos CFDI_Conceptos()
        {
            // Ejecutar la consulta XPath y crear el objeto Conceptos
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto", nsgmr);
            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Concepto
                {
                    ClaveProdServ = Convert.ToInt32(node.Attributes["ClaveProdServ"].Value),
                    NoIdentificacion = Convert.ToInt32(node.Attributes["NoIdentificacion"].Value),
                    Cantidad = DateTime.Parse(node.Attributes["Cantidad"].Value),
                    ClaveUnidad = node.Attributes["ClaveUnidad"].Value,
                    Descripcion = node.Attributes["Descripcion"].Value,
                    ValorUnitario = Convert.ToDouble(node.Attributes["ValorUnitario"].Value),
                    Importe = Convert.ToDouble(node.Attributes["Importe"].Value),
                    Unidad = node.Attributes["Unidad"].Value,
                    ObjetoImp = Convert.ToInt32(node.Attributes["ObjetoImp"].Value),
                    Impuestos = new Impuestos
                    {
                        Traslados = new Traslados
                        {
                            Traslado = new Traslado
                            {
                                Base = Convert.ToDouble(node.SelectSingleNode("cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Base"]?.Value ?? "0"),
                                Impuesto = Convert.ToInt32(node.SelectSingleNode("cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Impuesto"]?.Value ?? "0"),
                                TipoFactor = node.SelectSingleNode("cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["TipoFactor"]?.Value,
                                TasaOCuota = Convert.ToDouble(node.SelectSingleNode("cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["TasaOCuota"]?.Value ?? "0"),
                                Importe = Convert.ToDouble(node.SelectSingleNode("cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Importe"]?.Value ?? "0")
                            }
                        }
                    }
                })
                .ToList();

            if (data.Count == 0)
            {
                throw new Exception("No se encontraron nodos Concepto en el archivo XML.");
            }

            var conceptos = new Conceptos
            {
                Concepto = data
            };

            return conceptos;
        }


    }
}
