using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CFDI
{
    public class XmlModel
    {




    }



	// using System.Xml.Serialization;
	// XmlSerializer serializer = new XmlSerializer(typeof(Comprobante));
	// using (StringReader reader = new StringReader(xml))
	// {
	//    var test = (Comprobante)serializer.Deserialize(reader);
	// }

	[XmlRoot(ElementName = "Emisor")]
	public class Emisor
	{

		[XmlAttribute(AttributeName = "Rfc")]
		public string Rfc { get; set; }

		[XmlAttribute(AttributeName = "Nombre")]
		public string Nombre { get; set; }

		[XmlAttribute(AttributeName = "RegimenFiscal")]
		public int RegimenFiscal { get; set; }
	}

	[XmlRoot(ElementName = "Receptor")]
	public class Receptor
	{

		[XmlAttribute(AttributeName = "Rfc")]
		public string Rfc { get; set; }

		[XmlAttribute(AttributeName = "Nombre")]
		public string Nombre { get; set; }

		[XmlAttribute(AttributeName = "UsoCFDI")]
		public string UsoCFDI { get; set; }

		[XmlAttribute(AttributeName = "DomicilioFiscalReceptor")]
		public int DomicilioFiscalReceptor { get; set; }

		[XmlAttribute(AttributeName = "RegimenFiscalReceptor")]
		public int RegimenFiscalReceptor { get; set; }
	}

	[XmlRoot(ElementName = "Traslado")]
	public class Traslado
	{

		[XmlAttribute(AttributeName = "Base")]
		public double Base { get; set; }

		[XmlAttribute(AttributeName = "Impuesto")]
		public int Impuesto { get; set; }

		[XmlAttribute(AttributeName = "TipoFactor")]
		public string TipoFactor { get; set; }

		[XmlAttribute(AttributeName = "TasaOCuota")]
		public double TasaOCuota { get; set; }

		[XmlAttribute(AttributeName = "Importe")]
		public DateTime Importe { get; set; }
	}

	[XmlRoot(ElementName = "Traslados")]
	public class Traslados
	{

		[XmlElement(ElementName = "Traslado")]
		public Traslado Traslado { get; set; }
	}

	[XmlRoot(ElementName = "Impuestos")]
	public class Impuestos
	{

		[XmlElement(ElementName = "Traslados")]
		public Traslados Traslados { get; set; }

		[XmlAttribute(AttributeName = "TotalImpuestosTrasladados")]
		public DateTime TotalImpuestosTrasladados { get; set; }
	}

	[XmlRoot(ElementName = "Concepto")]
	public class Concepto
	{

		[XmlElement(ElementName = "Impuestos")]
		public Impuestos Impuestos { get; set; }

		[XmlAttribute(AttributeName = "ClaveProdServ")]
		public int ClaveProdServ { get; set; }

		[XmlAttribute(AttributeName = "NoIdentificacion")]
		public int NoIdentificacion { get; set; }

		[XmlAttribute(AttributeName = "Cantidad")]
		public DateTime Cantidad { get; set; }

		[XmlAttribute(AttributeName = "ClaveUnidad")]
		public string ClaveUnidad { get; set; }

		[XmlAttribute(AttributeName = "Descripcion")]
		public string Descripcion { get; set; }

		[XmlAttribute(AttributeName = "ValorUnitario")]
		public double ValorUnitario { get; set; }

		[XmlAttribute(AttributeName = "Importe")]
		public double Importe { get; set; }

		[XmlAttribute(AttributeName = "Unidad")]
		public string Unidad { get; set; }

		[XmlAttribute(AttributeName = "ObjetoImp")]
		public int ObjetoImp { get; set; }
	}

	[XmlRoot(ElementName = "Conceptos")]
	public class Conceptos
	{

		[XmlElement(ElementName = "Concepto")]
		public Concepto Concepto { get; set; }
	}

	[XmlRoot(ElementName = "TimbreFiscalDigital")]
	public class TimbreFiscalDigital
	{

		[XmlAttribute(AttributeName = "schemaLocation")]
		public string SchemaLocation { get; set; }

		[XmlAttribute(AttributeName = "Version")]
		public DateTime Version { get; set; }

		[XmlAttribute(AttributeName = "UUID")]
		public string UUID { get; set; }

		[XmlAttribute(AttributeName = "FechaTimbrado")]
		public DateTime FechaTimbrado { get; set; }

		[XmlAttribute(AttributeName = "RfcProvCertif")]
		public string RfcProvCertif { get; set; }

		[XmlAttribute(AttributeName = "SelloCFD")]
		public string SelloCFD { get; set; }

		[XmlAttribute(AttributeName = "NoCertificadoSAT")]
		public double NoCertificadoSAT { get; set; }

		[XmlAttribute(AttributeName = "SelloSAT")]
		public string SelloSAT { get; set; }

		[XmlAttribute(AttributeName = "tfd")]
		public string Tfd { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }
	}

	[XmlRoot(ElementName = "Complemento")]
	public class Complemento
	{

		[XmlElement(ElementName = "TimbreFiscalDigital")]
		public TimbreFiscalDigital TimbreFiscalDigital { get; set; }
	}

	[XmlRoot(ElementName = "Cab")]
	public class Cab
	{

		[XmlAttribute(AttributeName = "IDDOCUMENTO")]
		public string IDDOCUMENTO { get; set; }

		[XmlAttribute(AttributeName = "IMPLETRA")]
		public string IMPLETRA { get; set; }

		[XmlAttribute(AttributeName = "NOMEMI")]
		public object NOMEMI { get; set; }

		[XmlAttribute(AttributeName = "CALLEEMI")]
		public string CALLEEMI { get; set; }

		[XmlAttribute(AttributeName = "COLEMI")]
		public object COLEMI { get; set; }

		[XmlAttribute(AttributeName = "NUMEMI")]
		public int NUMEMI { get; set; }

		[XmlAttribute(AttributeName = "EDOEMI")]
		public string EDOEMI { get; set; }

		[XmlAttribute(AttributeName = "CPEMI")]
		public int CPEMI { get; set; }

		[XmlAttribute(AttributeName = "CALLEEXP")]
		public string CALLEEXP { get; set; }

		[XmlAttribute(AttributeName = "COLEXP")]
		public object COLEXP { get; set; }

		[XmlAttribute(AttributeName = "NUMEXP")]
		public string NUMEXP { get; set; }

		[XmlAttribute(AttributeName = "EDOEEXP")]
		public string EDOEEXP { get; set; }

		[XmlAttribute(AttributeName = "CPEXP")]
		public int CPEXP { get; set; }

		[XmlAttribute(AttributeName = "CALLEREC")]
		public string CALLEREC { get; set; }

		[XmlAttribute(AttributeName = "COLREC")]
		public object COLREC { get; set; }

		[XmlAttribute(AttributeName = "NUMREC")]
		public string NUMREC { get; set; }

		[XmlAttribute(AttributeName = "EDOREC")]
		public string EDOREC { get; set; }

		[XmlAttribute(AttributeName = "CPREC")]
		public int CPREC { get; set; }

		[XmlAttribute(AttributeName = "NOMDEST")]
		public string NOMDEST { get; set; }

		[XmlAttribute(AttributeName = "RFCDEST")]
		public object RFCDEST { get; set; }

		[XmlAttribute(AttributeName = "CALLEDEST")]
		public string CALLEDEST { get; set; }

		[XmlAttribute(AttributeName = "COLDEST")]
		public object COLDEST { get; set; }

		[XmlAttribute(AttributeName = "NUMDEST")]
		public string NUMDEST { get; set; }

		[XmlAttribute(AttributeName = "EDODEST")]
		public string EDODEST { get; set; }

		[XmlAttribute(AttributeName = "CPDEST")]
		public int CPDEST { get; set; }

		[XmlAttribute(AttributeName = "CLIENTSAP")]
		public int CLIENTSAP { get; set; }

		[XmlAttribute(AttributeName = "COMENCAB")]
		public string COMENCAB { get; set; }

		[XmlAttribute(AttributeName = "ZONA")]
		public object ZONA { get; set; }

		[XmlAttribute(AttributeName = "DESCDOC")]
		public string DESCDOC { get; set; }

		[XmlAttribute(AttributeName = "CANAL")]
		public int CANAL { get; set; }

		[XmlAttribute(AttributeName = "PEDIDOSAP")]
		public int PEDIDOSAP { get; set; }

		[XmlAttribute(AttributeName = "VENDEDOR")]
		public object VENDEDOR { get; set; }

		[XmlAttribute(AttributeName = "TOTPZA")]
		public DateTime TOTPZA { get; set; }

		[XmlAttribute(AttributeName = "INCOTERM")]
		public string INCOTERM { get; set; }

		[XmlAttribute(AttributeName = "VENCIMIENTO")]
		public string VENCIMIENTO { get; set; }

		[XmlAttribute(AttributeName = "CIE")]
		public object CIE { get; set; }

		[XmlAttribute(AttributeName = "ORDCOMP")]
		public int ORDCOMP { get; set; }

		[XmlAttribute(AttributeName = "EMAILCONTACTO")]
		public string EMAILCONTACTO { get; set; }
	}

	[XmlRoot(ElementName = "POS")]
	public class POS_
	{

		[XmlAttribute(AttributeName = "POS")]
		public int POS { get; set; }

		[XmlAttribute(AttributeName = "NoIdentificacion")]
		public int NoIdentificacion { get; set; }

		[XmlAttribute(AttributeName = "SERIE")]
		public object SERIE { get; set; }

		[XmlAttribute(AttributeName = "NCLIENT")]
		public int NCLIENT { get; set; }

		[XmlAttribute(AttributeName = "COMENTPOS")]
		public object COMENTPOS { get; set; }

		[XmlAttribute(AttributeName = "LOTE")]
		public string LOTE { get; set; }

		[XmlAttribute(AttributeName = "UNIDAD")]
		public string UNIDAD { get; set; }

		[XmlAttribute(AttributeName = "CANTIDAD")]
		public DateTime CANTIDAD { get; set; }

		[XmlAttribute(AttributeName = "CODIGO")]
		public int CODIGO { get; set; }
	}

	[XmlRoot(ElementName = "Posiciones")]
	public class Posiciones
	{

		[XmlElement(ElementName = "POS")]
		public POS_ POS { get; set; }
	}

	[XmlRoot(ElementName = "Documento")]
	public class Documento
	{

		[XmlElement(ElementName = "Cab")]
		public Cab Cab { get; set; }

		[XmlElement(ElementName = "Posiciones")]
		public Posiciones Posiciones { get; set; }

		[XmlAttribute(AttributeName = "FormatoXML")]
		public object FormatoXML { get; set; }

		[XmlAttribute(AttributeName = "Logo")]
		public string Logo { get; set; }

		[XmlAttribute(AttributeName = "ColorXML")]
		public string ColorXML { get; set; }
	}

	[XmlRoot(ElementName = "facturasap")]
	public class Facturasap
	{

		[XmlElement(ElementName = "Documento")]
		public Documento Documento { get; set; }

		[XmlAttribute(AttributeName = "schemaLocation")]
		public string SchemaLocation { get; set; }

		[XmlAttribute(AttributeName = "Version")]
		public int Version { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }
	}

	[XmlRoot(ElementName = "Addenda")]
	public class Addenda
	{

		[XmlElement(ElementName = "facturasap")]
		public Facturasap Facturasap { get; set; }
	}

	[XmlRoot(ElementName = "Comprobante")]
	public class Comprobante
	{

		[XmlElement(ElementName = "Emisor")]
		public Emisor Emisor { get; set; }

		[XmlElement(ElementName = "Receptor")]
		public Receptor Receptor { get; set; }

		[XmlElement(ElementName = "Conceptos")]
		public Conceptos Conceptos { get; set; }

		[XmlElement(ElementName = "Impuestos")]
		public Impuestos Impuestos { get; set; }

		[XmlElement(ElementName = "Complemento")]
		public Complemento Complemento { get; set; }

		[XmlElement(ElementName = "Addenda")]
		public Addenda Addenda { get; set; }

		[XmlAttribute(AttributeName = "cce11")]
		public string Cce11 { get; set; }

		[XmlAttribute(AttributeName = "cfdi")]
		public string Cfdi { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }

		[XmlAttribute(AttributeName = "schemaLocation")]
		public string SchemaLocation { get; set; }

		[XmlAttribute(AttributeName = "Version")]
		public double Version { get; set; }

		[XmlAttribute(AttributeName = "Serie")]
		public string Serie { get; set; }

		[XmlAttribute(AttributeName = "Folio")]
		public int Folio { get; set; }

		[XmlAttribute(AttributeName = "Fecha")]
		public DateTime Fecha { get; set; }

		[XmlAttribute(AttributeName = "FormaPago")]
		public int FormaPago { get; set; }

		[XmlAttribute(AttributeName = "CondicionesDePago")]
		public string CondicionesDePago { get; set; }

		[XmlAttribute(AttributeName = "SubTotal")]
		public double SubTotal { get; set; }

		[XmlAttribute(AttributeName = "Moneda")]
		public string Moneda { get; set; }

		[XmlAttribute(AttributeName = "TipoCambio")]
		public int TipoCambio { get; set; }

		[XmlAttribute(AttributeName = "Total")]
		public double Total { get; set; }

		[XmlAttribute(AttributeName = "TipoDeComprobante")]
		public string TipoDeComprobante { get; set; }

		[XmlAttribute(AttributeName = "MetodoPago")]
		public string MetodoPago { get; set; }

		[XmlAttribute(AttributeName = "LugarExpedicion")]
		public int LugarExpedicion { get; set; }

		[XmlAttribute(AttributeName = "Exportacion")]
		public int Exportacion { get; set; }

		[XmlAttribute(AttributeName = "NoCertificado")]
		public double NoCertificado { get; set; }

		[XmlAttribute(AttributeName = "Certificado")]
		public string Certificado { get; set; }

		[XmlAttribute(AttributeName = "Sello")]
		public string Sello { get; set; }
	}




}
