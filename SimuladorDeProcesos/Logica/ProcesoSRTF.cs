using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorDeProcesos.Logica
{
    class ProcesoSRTF
    {
        public int tlleg;
        public int tcpu;
        public String id;
        //public int tcom;
        //  public int tfin;
        public List<int> tcom = new List<int>();
        public List<int> tfin = new List<int>();
        public int tesp;
        public Boolean paso;
        public Boolean completado;

        public ProcesoSRTF() { this.paso = false; }
        public ProcesoSRTF(string id, int tlleg, int tcpu)
        {
            this.tlleg = tlleg;
            this.tcpu = tcpu;
            this.id = id;
            this.paso = false;
            this.completado = false;
        }
    }
}
