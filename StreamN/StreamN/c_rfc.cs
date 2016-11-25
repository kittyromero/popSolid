using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamN
{
    public class c_rfc
    {
        public string nom, pat, mat, nac = "";

        public string CalcularRFC()
        {
            string cad = null;

            cad = pat.Substring(0, 2) + mat.Substring(0, 1) + nom.Substring(0, 1) + nac.Substring(8, 2) + nac.Substring(3, 2) + nac.Substring(0, 2);

            return cad.ToUpper();

        }
    }
}
