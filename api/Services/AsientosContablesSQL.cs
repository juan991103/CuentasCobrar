using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Services
{
    public class AsientosContablesSQL : I_AsientosContables_Service
    {
        private readonly ApiDbContext _ApiDbContext;

        public AsientosContablesSQL(ApiDbContext apiDbContext)
        {
            this._ApiDbContext = apiDbContext;
        }

        public Asientos_Contables Actualizar(Asientos_Contables dto)
        {
            throw new NotImplementedException();
        }

        public int Eliminar(Asientos_Contables dto)
        {
            throw new NotImplementedException();
        }

        public Asientos_Contables Insert(Asientos_Contables dto)
        {
            throw new NotImplementedException();
        }

        public List<Asientos_Contables> Listar()
        {
            throw new NotImplementedException();
        }

        public Asientos_Contables Recuperar(Asientos_Contables dto)
        {
            throw new NotImplementedException();
        }
    }
}
