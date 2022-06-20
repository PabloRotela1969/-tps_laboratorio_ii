using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;

namespace PruebasUnitarias
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PruebaAltaClientela()
        {
            //Arrange
            Clientela nuevaClientela = new Clientela();
            Cliente nuevoCliente = new Cliente();

            // Act
            nuevaClientela.AltaNuevo(nuevoCliente);
            //Assert
            Assert.AreEqual(nuevaClientela.mostrarLista().Count, 1);

        }
        [TestMethod]
        public void PruebaBajaClienteDeClientela()
        {
            //Arrange
            Clientela nuevaClientela = new Clientela();
            Cliente nuevoCliente = new Cliente();

            // Act
            nuevaClientela.AltaNuevo(nuevoCliente);
            nuevaClientela.EliminarExistente(nuevoCliente);
            //Assert
            Assert.AreEqual(nuevaClientela.mostrarLista().Count, 0);
        }

        [TestMethod]
        public void PruebaModificaClienteDeClientela()
        {
            //Arrange
            Clientela nuevaClientela = new Clientela();
            Cliente nuevoCliente = new Cliente(1, "Juan", "Salsipuedes");
            nuevaClientela.AltaNuevo(nuevoCliente);
            Cliente nuevoClienteCambiado = new Cliente(1, "Juan", "No puede salir");
            // Act

            nuevaClientela.ModificaExistente(nuevoCliente, nuevoClienteCambiado);
            //Assert
            Assert.AreEqual((nuevaClientela.mostrarLista()[0] as Cliente).Apellido, "No puede salir");
        }


        [TestMethod]
        public void PruebaAltaDeItem()
        {
            //Arrange
            Catalogo nuevoCatalogo = new Catalogo();
            Item nuevoItem = new Item(1, "alfa", 3, 1.5f);
            // Act
            nuevoCatalogo.AltaNuevo(nuevoItem);
            
            //Assert
            Assert.AreEqual(nuevoCatalogo.mostrarLista().Count, 1);
        }

        [TestMethod]
        public void PruebaModificaDeItem()
        {
            //Arrange
            Catalogo nuevoCatalogo = new Catalogo();
            Item nuevoItem = new Item(1, "alfa", 3, 1.5f);
            nuevoCatalogo.AltaNuevo(nuevoItem);
            Item nuevoItemCambiado = new Item(1, "gamma", 3, 1.5f);
            nuevoCatalogo.AltaNuevo(nuevoItemCambiado);
            // Act
            nuevoCatalogo.ModificaExistente(nuevoItem, nuevoItemCambiado);

            //Assert
            Assert.AreEqual((nuevoCatalogo.mostrarLista()[0] as Item).Nombre, "gamma");
        }


        [TestMethod]
        public void PruebaEliminadoDeItem()
        {
            //Arrange
            Catalogo nuevoCatalogo = new Catalogo();
            Item nuevoItem = new Item(1, "alfa", 3, 1.5f);
            nuevoCatalogo.AltaNuevo(nuevoItem);
            Item nuevoItemCambiado = new Item(1, "gamma", 3, 1.5f);
            nuevoCatalogo.AltaNuevo(nuevoItemCambiado);
            // Act
            nuevoCatalogo.EliminarExistente(nuevoItemCambiado);

            //Assert
            Assert.AreEqual(nuevoCatalogo.mostrarLista().Count, 1);
        }
    }
}
