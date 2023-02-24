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
    }
}
