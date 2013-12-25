using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEpsAPI" in both code and config file together.
    [ServiceContract]
    public interface IEpsAPI
    {
        //Sample
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "xml/{id}")]
        string XMLData(string id);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "json/{id}")]
        string JSONData(string id);


        //PUT Operation
        [OperationContract]
        [WebInvoke(Method = "POST", 
            UriTemplate = "Login/?UserName={user}&Password={password}")]
        bool login(string user, string password);







        //[OperationContract]
        //[WebInvoke(Method = "DELETE",
        //    ResponseFormat = WebMessageFormat.Xml, UriTemplate = "Delete")]
        //void Delete(string id);

        //[OperationContract]
        //[WebInvoke(Method = "PUT",
        //    ResponseFormat = WebMessageFormat.Xml)]
        //   void Update(string contact);

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Xml)]
        //List<string> GetAll();

        //[OperationContract]
        //[WebInvoke(Method = "GET",
        //    ResponseFormat = WebMessageFormat.Xml, UriTemplate = "GetContact/{id}")]
        //string GetContact(string id);






    }
}
