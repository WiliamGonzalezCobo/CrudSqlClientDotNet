using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.ENTIDADES
{
    public class BandaClass
    {
        private int ibanda;


        public int Ibanda
        {
            get { return ibanda; }
            set { ibanda = value; }
        }
        private String strNombre;


        public String StrNombre
        {
            get { return strNombre; }
            set { strNombre = value; }
        }

        private String strTipo;

        public String StrTipo
        {
            get { return strTipo; }
            set { strTipo = value; }
        }

       

        public BandaClass() {
            this.ibanda = 0;
            this.strNombre = "";
            this.strTipo = "";
        }


        

    }
}
