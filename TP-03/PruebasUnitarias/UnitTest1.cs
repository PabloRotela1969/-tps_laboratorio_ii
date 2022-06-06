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
            nuevaClientela.altaNuevo(nuevoCliente);
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
            nuevaClientela.altaNuevo(nuevoCliente);
            nuevaClientela.eliminarExistente(nuevoCliente);
            //Assert
            Assert.AreEqual(nuevaClientela.mostrarLista().Count, 0);
        }

        [TestMethod]
        public void PruebaModificaClienteDeClientela()
        {
            //Arrange
            Clientela nuevaClientela = new Clientela();
            Cliente nuevoCliente = new Cliente(1, "Juan", "Salsipuedes");
            nuevaClientela.altaNuevo(nuevoCliente);
            Cliente nuevoClienteCambiado = new Cliente(1, "Juan", "No puede salir");
            // Act

            nuevaClientela.modificaExistente(nuevoCliente, nuevoClienteCambiado);
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
            nuevoCatalogo.altaNuevo(nuevoItem);
            
            //Assert
            Assert.AreEqual(nuevoCatalogo.mostrarLista().Count, 1);
        }

        [TestMethod]
        public void PruebaModificaDeItem()
        {
            //Arrange
            Catalogo nuevoCatalogo = new Catalogo();
            Item nuevoItem = new Item(1, "alfa", 3, 1.5f);
            nuevoCatalogo.altaNuevo(nuevoItem);
            Item nuevoItemCambiado = new Item(1, "gamma", 3, 1.5f);
            nuevoCatalogo.altaNuevo(nuevoItemCambiado);
            // Act
            nuevoCatalogo.modificaExistente(nuevoItem, nuevoItemCambiado);

            //Assert
            Assert.AreEqual((nuevoCatalogo.mostrarLista()[0] as Item).Nombre, "gamma");
        }


        [TestMethod]
        public void PruebaEliminadoDeItem()
        {
            //Arrange
            Catalogo nuevoCatalogo = new Catalogo();
            Item nuevoItem = new Item(1, "alfa", 3, 1.5f);
            nuevoCatalogo.altaNuevo(nuevoItem);
            Item nuevoItemCambiado = new Item(1, "gamma", 3, 1.5f);
            nuevoCatalogo.altaNuevo(nuevoItemCambiado);
            // Act
            nuevoCatalogo.eliminarExistente(nuevoItemCambiado);

            //Assert
            Assert.AreEqual(nuevoCatalogo.mostrarLista().Count, 1);
        }
    }
}
