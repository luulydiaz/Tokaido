using NUnit.Framework;
using Tokaido;
namespace Tokaido.Test
{
    public class TravelerTest
    {
        Mountain mountain;
        Ocean ocean;
        Farm farm;

        TravelerOne pedro;
        
        [SetUp]
        public void Setup()
        {  
            mountain = new Mountain("Aconcagua",2,1);
            ocean = new Ocean("Antártico",3,2);
            farm = new Farm("Granja1",2,1,2);
            pedro = new TravelerOne("Pedro");
            pedro.AddObserver(mountain);
            pedro.AddObserver(ocean);
            pedro.AddObserver(farm);
        }

        /// <summary>
        /// Comprueba que el viajero se mueve a la experiencia indicada por la posición.
        /// </summary>
        [Test]
        public void TestMoveTravelerToPosition()
        {
            pedro.MoveTraveler(1);
            Assert.AreEqual(pedro, mountain.Travelers[0]);
            Assert.AreEqual(pedro.Position,1);
        }

        /// <summary>
        /// Comprueba que la posición del viajero no puede ser negativa.
        /// </summary>
        [Test]
        public void TestPositionNotNegative()
        {
            pedro.MoveTraveler(-1);

            Assert.AreEqual(pedro.Position, 0);
        }

        /// <summary>
        /// Comprueba que aunque el viajero no ingrese a la experiencia indicada, su posición cambia.
        /// </summary>
        [Test]
        public void TestPositionChange()
        {
            pedro.MoveTraveler(3);
            bool actual = farm.Travelers.Contains(pedro);

            Assert.AreEqual(3,pedro.Position);
            Assert.AreEqual(false, actual);
        }

        /// <summary>
        /// Compueba que aunque no exista experiencia el viajero cambia de posición.
        /// </summary>
        [Test]
        public void TestPositionNotExists()
        {
            pedro.MoveTraveler(10);
            Assert.AreEqual(10,pedro.Position);
        }
    }
}