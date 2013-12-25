using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;
using System.Xml;


namespace WebEps
{
    public partial class Index : System.Web.UI.Page
    {
        public string SampleString { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public XmlDocument getMethod(string inURL)
        {
            if (!string.IsNullOrEmpty(inURL))
            {
                HttpWebRequest myHttpWebRequest = null;     //Declare an HTTP-specific implementation of the WebRequest class.
                HttpWebResponse myHttpWebResponse = null;   //Declare an HTTP-specific implementation of the WebResponse class
                XmlDocument myXMLDocument = null;           //Declare XMLResponse document
                XmlTextReader myXMLReader = null;           //Declare XMLReader

                try
                {
                    //Create Request
                    myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(inURL);
                    myHttpWebRequest.Method = "GET";
                    myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";

                    //Get Response
                    myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                    //Now load the XML Document
                    myXMLDocument = new XmlDocument();

                    //Load response stream into XMLReader
                    myXMLReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());
                    myXMLDocument.Load(myXMLReader);
                }
                catch
                //catch (Exception myException)
                {
                    //throw new Exception("Error Occurred in AuditAdapter.getXMLDocumentFromXMLTemplate()", myException);
                    return null;
                }
                finally
                {
                    myHttpWebRequest = null;
                    myHttpWebResponse = null;
                    myXMLReader = null;
                }
                return myXMLDocument;
            }
            return null;
        }

        public bool postMethod(string inURL)
        {
            if (!string.IsNullOrEmpty(inURL))
            {
                try
                {
                    HttpWebRequest req = WebRequest.Create(inURL) as HttpWebRequest;
                    req.KeepAlive = false;
                    req.Method = "POST";
                    string FilePath = @"C:\person-Artha.xml";
                    string content = (File.OpenText(@FilePath)).ReadToEnd();

                    byte[] buffer = Encoding.ASCII.GetBytes(content);
                    req.ContentLength = buffer.Length;
                    req.ContentType = "text/xml";
                    Stream PostData = req.GetRequestStream();
                    PostData.Write(buffer, 0, buffer.Length);
                    PostData.Close();

                    HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
                    Encoding enc = System.Text.Encoding.GetEncoding(1252);
                    StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);

                    string Response = loResponseStream.ReadToEnd();
                    loResponseStream.Close();
                    resp.Close();
                    return true;
                    //Console.WriteLine(Response);
                }
                //catch
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    return false;
                }
            }
            return false;
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string urlstr = "http://localhost:61669/EpsAPI.svc/xml/" + UserNametex.Text.Trim();
            XmlDocument myXMLDocument = getMethod(urlstr);
            string str = string.Empty;
            if (myXMLDocument != null)
            { str = myXMLDocument.InnerText; }
            SampleString = str;
        }

        protected void PostBtn_Click(object sender, EventArgs e)
        {
            string urlstr = "http://localhost:61669/EpsAPI.svc/" + "Login/?UserName=" + UserNametex.Text.Trim() + "&Password=" + PassWordTex.Text.Trim();
            bool result = postMethod(urlstr);
            string str = string.Empty;
            if (result)
            { str = "OK"; }
            else { str = "Fail"; }
            SampleString = str;
        }
    }
}