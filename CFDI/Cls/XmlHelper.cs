using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace CFDI
{
    public class XmlHelper
    {
        public static XmlDocument LoadXml(IFormFile file)
        {
            var xml = new XmlDocument();
            xml.Load(file.OpenReadStream());
            return xml;
        }

        public static XmlNodeList SelectNodes(XmlDocument xml, string xpath, XmlNamespaceManager nsmgr)
        {
            return xml.SelectNodes(xpath, nsmgr);
        }

        public static XmlNamespaceManager XMLNamespaces(XmlDocument xml,IFormFile file)
        {
            try
            {
                
                var nsmgr = new XmlNamespaceManager(xml.NameTable);

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

                //var dataCFDI = CFDI(xml, nsmgr);

                return nsmgr;
            }
            catch (Exception ex)
            {
                return Exception(ex.Message);
            }
        }

        private static XmlNamespaceManager Exception(string message)
        {
            throw new NotImplementedException();
        }
    }
}
