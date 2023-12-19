﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace CFDI
{
    public class XmlHelper
    {
        public static XmlDocument LoadXml(string file)
        {

            //string username = "MR.DESARR";
            //string password = "US70mc14*-......";

            //HttpClientHandler handler = new HttpClientHandler();
            //handler.Credentials = new NetworkCredential(username, password);


            //using (HttpClient client = new HttpClient(handler))
            //{
            var xml = new XmlDocument();
                //xml.Load(file.OpenReadStream());
                xml.Load(file);
                return xml;
            //}



            
        }

        public static XmlNodeList SelectNodes(XmlDocument xml, string xpath, XmlNamespaceManager nsmgr)
        {
            return xml.SelectNodes(xpath, nsmgr);
        }

        public static XmlNamespaceManager XMLNamespaces(XmlDocument xml,string file)
        {
            try
            {
                
                var nsmgr = new XmlNamespaceManager(xml.NameTable);

                foreach (XmlAttribute attr in xml.DocumentElement.Attributes)
                {
                    if (attr.Name.StartsWith("xmlns"))
                    {
                        string prefix = string.Empty;
                        if (attr.Name.Contains(""))
                        {
                            prefix = attr.Name.Split(':')[1];
                        }
                        nsmgr.AddNamespace(prefix, attr.Value);
                    }
                }

                // Agregar el namespace "tfd"
                nsmgr.AddNamespace("tfd", "http://www.sat.gob.mx/TimbreFiscalDigital");
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
