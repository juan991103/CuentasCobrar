using api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public interface I_AsientosContables_Service
    {
        List<Asientos_Contables> Listar();
        Asientos_Contables Insert(Asientos_Contables dto);
        Asientos_Contables Actualizar(Asientos_Contables dto);
        int Eliminar(Asientos_Contables dto);
        Asientos_Contables Recuperar(Asientos_Contables dto);
    }
}
