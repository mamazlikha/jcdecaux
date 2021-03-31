using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathsLibrary
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IMathsOperations
    {
        [OperationContract]
        double Add(double v1, double v2);
        
        [OperationContract]
        double Multiply(double v1, double v2);

        [OperationContract]
        double Substract(double v1, double v2);

        [OperationContract]
        double Divide(double v1, double v2);


        // TODO: ajoutez vos opérations de service ici
    }

   
}
