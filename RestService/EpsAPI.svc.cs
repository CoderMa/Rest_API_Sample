using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EpsAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EpsAPI.svc or EpsAPI.svc.cs at the Solution Explorer and start debugging.
    public class EpsAPI : IEpsAPI
    {
        //Sample
        public string XMLData(string id)
        { return "You requested product " + id; }

        public string JSONData(string id)
        { return "You requested product " + id; }

        public bool login(string user, string password)
        {
            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(password))
            { return true; }
            else
            { return false; }
        }
    }
}
