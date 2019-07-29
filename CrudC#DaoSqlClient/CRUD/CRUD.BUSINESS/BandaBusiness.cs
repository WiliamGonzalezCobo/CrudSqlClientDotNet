using System;
using CRUD.DAO;
using CRUD.ENTIDADES;

namespace CRUD.BUSINESS
{
    public class BandaBusiness
    {
        private readonly Banda _banda;
        public BandaBusiness()
        {
            _banda = new Banda();
        }
        public BandaClass readBandaXiD(int id, out string Mensaje)
        {
            return _banda.readBandaXiD(id, out Mensaje);
        }

        public string deleteBanda(int id)
        {
            return _banda.deleteBanda(id);
        }

        public String insertBandasp(BandaClass objBanda)
        {
            return _banda.insertBandasp(objBanda);
        }

        public string updateBanda(BandaClass objBanda)
        {
            return _banda.updateBanda(objBanda);
        }
    }
}
