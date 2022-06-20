using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal interface Ilistado<T>
    {

        public void AltaNuevo(T o);

        public void ModificaExistente(T o, T a);


        public void EliminarExistente(T o);

        public void PersistirListado();

        public List<T> LeerListaPersistida();

    }
}
