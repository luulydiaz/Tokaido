using System.Collections.Generic;

namespace Tokaido
{

    /* 
        La clase TravelerOne hereda de la clase Traveler, por eso subtipo de Traveler. Por lo tanto presenta las mismas
        propiedades y métodos definidos en la superclase.
        ETravelerOne es un Viajero común y no tiene diferencias con Traveler.
        
    */
    
    public class TravelerOne: AbstractTraveler
    {
        public TravelerOne(string name): base(name)
        {
            Name = name;
        }
    }
}