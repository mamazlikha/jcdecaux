﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RoutingWithBikes
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IRoutingWithBikes
    {
       
        [OperationContract]
        [WebInvoke(Method = "GET",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "computeRoute?addressOfStart={addressOfStart}&addressOfDest={addressOfDest}")]
        SerialisedObject computeRoute(string addressOfStart, string addressOfDest);
        // TODO: ajoutez vos opérations de service ici
    }

}
