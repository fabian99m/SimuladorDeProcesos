using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorDeProcesos.Logica
{
    class Proceso 
    {
        public int tlleg;
        public int tcpu;
        public String id;
        public int tcom;
        public int tfin;
        public int tesp;

        public Proceso( string id,int tlleg, int tcpu)
        {
            this.tlleg = tlleg;
            this.tcpu = tcpu;
            this.id = id;
        }

      
       
    }
}
