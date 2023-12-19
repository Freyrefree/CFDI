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

        public static Comprobante CFDI_Comprobante()
        {
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante", nsgmr);

            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Comprobante
                {

                    Version = node.Attributes["Version"].Value,
                    Serie = node.Attributes["Serie"].Value,
                    Folio = Convert.ToInt32(node.Attributes["Folio"].Value),
                    Fecha = DateTime.Parse(node.Attributes["Fecha"].Value),
                    FormaPago = Convert.ToInt32(node.Attributes["FormaPago"].Value),
                    CondicionesDePago = node.Attributes["CondicionesDePago"].Value,
                    SubTotal = Convert.ToDouble(node.Attributes["SubTotal"].Value),
                    Moneda = node.Attributes["Moneda"].Value,
                    TipoCambio = Convert.ToDouble(node.Attributes["TipoCambio"].Value),
                    Total = Convert.ToDouble(node.Attributes["Total"].Value),
                    TipoDeComprobante = node.Attributes["TipoDeComprobante"].Value,
                    MetodoPago = node.Attributes["MetodoPago"].Value,
                    LugarExpedicion = Convert.ToInt32(node.Attributes["LugarExpedicion"].Value),
                    Exportacion = Convert.ToInt32(node.Attributes["Exportacion"].Value),
                    NoCertificado = node.Attributes["NoCertificado"].Value,
                    Certificado = node.Attributes["Certificado"].Value,
                    Sello = node.Attributes["Sello"].Value

                })
                .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró el nodo Complemento en el archivo XML.");
            }

            return data;
        }

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
                    Cantidad = Convert.ToDouble(node.Attributes["Cantidad"].Value),
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

        public static Impuestos CFDI_Impuestos()
        {
            // Ejecutar la consulta XPath y crear el objeto Emisor
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Impuestos", nsgmr);

            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Impuestos
                {
                    TotalImpuestosTrasladados = Convert.ToDouble(node.Attributes["TotalImpuestosTrasladados"]?.Value ?? "0"),

                    Traslados = new Traslados
                    {
                        Traslado = new Traslado
                        {
                            Base = Convert.ToDouble(node.SelectSingleNode("//cfdi:Comprobante/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Base"]?.Value ?? "0"),
                            Impuesto = Convert.ToInt32(node.SelectSingleNode("//cfdi:Comprobante/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Impuesto"]?.Value ?? "0"),
                            TipoFactor = node.SelectSingleNode("//cfdi:Comprobante/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["TipoFactor"]?.Value,
                            TasaOCuota = Convert.ToDouble(node.SelectSingleNode("//cfdi:Comprobante/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["TasaOCuota"]?.Value ?? "0"),
                            Importe = Convert.ToDouble(node.SelectSingleNode("//cfdi:Comprobante/cfdi:Impuestos/cfdi:Traslados/cfdi:Traslado", nsgmr)?.Attributes["Importe"]?.Value ?? "0")
                        }
                    }
                })
                .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró el nodo Impuestos en el archivo XML.");
            }

            return data;
        }

        public static Complemento CFDI_Complemento()
        {
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Complemento", nsgmr);

            var data = nodeList
                .Cast<XmlNode>()
                .Select(node => new Complemento
                {
                    TimbreFiscalDigital = new TimbreFiscalDigital
                    {
                        Version = node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["Version"]?.Value ?? "1900-01-01",
                        UUID = node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["UUID"]?.Value,
                        FechaTimbrado = DateTime.Parse(node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["FechaTimbrado"]?.Value ?? "1900-01-01T00:00:00"),
                        RfcProvCertif = node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["RfcProvCertif"]?.Value,
                        SelloCFD = node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["SelloCFD"]?.Value,
                        NoCertificadoSAT = double.Parse(node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["NoCertificadoSAT"]?.Value ?? "0"),
                        SelloSAT = node.SelectSingleNode("//tfd:TimbreFiscalDigital", nsgmr)?.Attributes["SelloSAT"]?.Value,

                    }
                })
                .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró el nodo Complemento en el archivo XML.");
            }

            return data;
        }

        public static Addenda Addenda()
        {

            try
            {
                var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante", nsgmr);
                var data = nodeList
                    .Cast<XmlNode>()
                    .Select(node => new Addenda
                    {
                        RequestForPayment = new RequestForPayment
                        {
                            OrderIdentification = new OrderIdentification
                            {
                                ReferenceIdentification = xml.SelectSingleNode("//requestForPayment/orderIdentification/referenceIdentification", nsgmr)?.InnerText,

                            }
                        }
                    })
                    .FirstOrDefault();

                if (data == null)
                {
                    throw new Exception("No se encontró el nodo Addenda en el archivo XML.");
                }

                return data;
            }
            catch (Exception ex)
            {

                return null; // O devuelve un valor predeterminado, dependiendo de tus necesidades.
            }
        }

        public static ComercioExterior CFDI_ComercioExterior()
        {
            // Ejecutar la consulta XPath y crear el objeto ComercioExterior
            var nodeList = XmlHelper.SelectNodes(xml, "//cfdi:Comprobante/cfdi:Complemento/cce11:ComercioExterior", nsgmr);

            var data = nodeList
                    .Cast<XmlNode>()
                    .Select(node => new ComercioExterior
                    {
                        // Otras propiedades de ComercioExterior

                        Mercancias = node.SelectNodes("cce11:Mercancias", nsgmr)
                            .Cast<XmlNode>()
                            .Select(mercanciaNode => new Mercancias
                            {
                                Mercancia = new Mercancia
                                {
                                    NoIdentificacion = node.SelectSingleNode("//cce11:Mercancia", nsgmr)?.Attributes["NoIdentificacion"]?.Value ?? "",
                                    FraccionArancelaria = node.SelectSingleNode("//cce11:Mercancia", nsgmr)?.Attributes["FraccionArancelaria"]?.Value ?? "",
                                    CantidadAduana = double.Parse(node.SelectSingleNode("//cce11:Mercancia", nsgmr)?.Attributes["CantidadAduana"]?.Value ?? "0"),
                                    UnidadAduana = node.SelectSingleNode("//cce11:Mercancia", nsgmr)?.Attributes["UnidadAduana"]?.Value ?? "",
                                    ValorUnitarioAduana = double.Parse(node.SelectSingleNode("//cce11:Mercancia", nsgmr)?.Attributes["ValorUnitarioAduana"]?.Value ?? "0"),
                                    ValorDolares = double.Parse(node.SelectSingleNode("//cce11:Mercancia", nsgmr)?.Attributes["ValorDolares"]?.Value ?? "0"),

                                }
                            })
                            .FirstOrDefault()
                    })
                    .FirstOrDefault();

            if (data == null)
            {
                throw new Exception("No se encontró el nodo ComercioExterior en el archivo XML.");
            }

            return data;
        }






    }
}
