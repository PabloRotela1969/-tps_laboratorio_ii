using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    internal interface Ilistado<T>
    {

        public void altaNuevo(T o);

        public void modificaExistente(T o, T a);


        public void eliminarExistente(T o);

        public void persistirListado();

        public List<T> leerListaPersistida();

    }
}
