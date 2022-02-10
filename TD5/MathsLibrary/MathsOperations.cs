using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MathsLibrary
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class MathsOperations : IMathsOperations
    {
       
        public double Add(double v1, double v2)
        {
            return v1 + v2;
        }

        public double Divide(double v1, double v2)
        {
            if (v2 != 0) { return v1 / v2; }
            else throw new Exception("dividing by zero !\n");
        }

        public double Multiply(double v1, double v2)
        {
            return v1 * v2;
        }

        public double Substract(double v1, double v2)
        {
            return v1 - v2;
        }
    }
}
