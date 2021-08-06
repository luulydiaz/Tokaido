using System.Collections.Generic;

namespace Tokaido
{
    public class ThermalWater: AbstractExperience
    {
        /*  
            Esta clase es un subtipo de AbstracExperiencia, y por eso presenta iguales propiedades y metodos 
            definidios por la superclase.
            ThermalWater usa el patron Observer y por lo tanto es un observador y el metodo PositionChange
            recibe actualizaciones cuando cambia de posicion el viajero.
            PositionChange tambien es Polimorfica y por lo tanto ThermalWater la define segun sus necesidades
            Usa Expert para asignar los puntos y remover a los viajeros, ya que conoce a los viajeros que se ingresaron.
            
        */
        
        public int Points {get;set;}
        private List<AbstractTraveler> travelersPoint = new List<AbstractTraveler>();
        public List<AbstractTraveler> TravelersPoint {get{return travelersPoint;}}

        public ThermalWater(string name,int limit, int position, int points): base(name,limit,position)
        {
            Points = points;
        }  
        
        /// <summary>
        /// Se ejecuta cuando hay un cambio en la posicion del viajero, si es igual a la de la Experiencia se lo agrega
        /// de lo contrario se lo remueve
        /// </summary>
        /// <param name="observable"></param>
        public override void PositionChange(AbstractTraveler observable)
        {
            if(observable.Position == this.Position)
            {
                this.NewTraveler(observable);
                GivePoints();
            }
            else if (this.Travelers.Contains(observable))
            {
                this.RemoveTraveler(observable);
            }
        }
       
        /// <summary>
        /// Le asigna los puntos a los viajeros
        /// </summary>
        public void GivePoints()
        {
            foreach (AbstractTraveler traveler in this.Travelers)
            {
                if (!(this.TravelersPoint.Contains(traveler)))
                {
                    this.TravelersPoint.Add(traveler);
                    traveler.Score += this.Points;
                }
            }  
        }
          
        /// <summary>
        /// Remueve a los viajeros de la experiencia
        /// </summary>
        /// <param name="traveler"></param>
        public void RemoveTraveler(AbstractTraveler traveler)
        {
            this.Travelers.Remove(traveler);
            this.TravelersPoint.Remove(traveler);
        }
    }
}