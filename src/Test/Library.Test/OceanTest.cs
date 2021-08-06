using NUnit.Framework;
using Tokaido;
namespace Tokaido.Test
{
    public class OceanTest
    {
        Ocean ocean1;
        Ocean ocean2;
        Ocean ocean3;

        TravelerOne oneTraveler;
        TravelerOne twoTraveler;

        Game road;

        [SetUp]
        public void Setup()
        {
            ocean1 = new Ocean("Pacífico",4,1);
            ocean2 = new Ocean("Antártico",3,2);
            ocean3 = new Ocean("Atlántico",1,3);
            oneTraveler = new TravelerOne("Pedro");
            twoTraveler = new TravelerOne("Maria");   
            road = new Game();
            road.AddTravelers(oneTraveler);
            road.AddTravelers(twoTraveler);
            road.AddExperience(ocean1);
            road.AddExperience(ocean2);
            road.AddExperience(ocean3);
            road.LoadObservers();
        }

        /// <summary>
        /// Comprueba la puntuacion.
        /// </summary>
        [Test]
        public void TestGivePoints()
        {
            oneTraveler.MoveTraveler(1);
            twoTraveler.MoveTraveler(1);
            
            Assert.AreEqual(oneTraveler.Score, 1);
            Assert.AreEqual(twoTraveler.Score, 1);
        }

        /// <summary>
        /// Comprueba la puntuacion cuando un viajero pasa por varias Aguas Termales.
        /// </summary>
        [Test]
        public void TestGivePointsTwo()
        {
            oneTraveler.MoveTraveler(1);
            oneTraveler.MoveTraveler(2);
            oneTraveler.MoveTraveler(3);

            Assert.AreEqual(oneTraveler.Score, 9);
        }

        /// <summary>
        ///  Comprueba que un viajero puede ingresar a cualquier Agua Termal que este despues.
        /// </summary>        
        [Test]
        public void TestNewExperience()
        {
            oneTraveler.MoveTraveler(1);
            oneTraveler.MoveTraveler(3);
            bool expected = ocean3.Travelers.Contains(oneTraveler);

            Assert.AreEqual(true,expected);
        }

        /// <summary>
        /// Comprueba que un viajero no puede ingresar a un Agua Termal que este antes.
        /// </summary>
        [Test]
        public void TestPreviousExperience()
        {
            oneTraveler.MoveTraveler(2);
            oneTraveler.MoveTraveler(1);
            bool expected = ocean2.Travelers.Contains(oneTraveler);
            bool expected2 = ocean1.Travelers.Contains(oneTraveler);

            Assert.AreEqual(expected,true);
            Assert.AreEqual(expected2,false);
        }

        /// <summary>
        /// Comprueba que cuando viajero se mueve a otra Agua Termal, es eliminado de la que se encontraba 
        /// </summary>
        [Test]
        public void TestRemoveTraveler()
        {
            oneTraveler.MoveTraveler(1);
            bool expected = ocean1.Travelers.Contains(oneTraveler);
            oneTraveler.MoveTraveler(2);
            bool expected2 = ocean1.Travelers.Contains(oneTraveler);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expected2);
        }   

        /// <summary>
        /// Comprueba que si el Agua Termal está llena no puede ingresar otro Viajero.
        /// </summary>
        [Test]
        public void TestFullExperience()
        {
            oneTraveler.MoveTraveler(3);
            twoTraveler.MoveTraveler(3);
            bool expected = ocean3.Travelers.Contains(oneTraveler);
            bool expected2 = ocean3.Travelers.Contains(twoTraveler);

            Assert.AreEqual(true,expected);
            Assert.AreEqual(false,expected2);
        }
    }
}
