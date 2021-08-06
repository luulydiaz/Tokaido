using System.Collections.Generic;

namespace Tokaido
{
    /*
        Esta clase es un subtipo de AbstracExperiencia, y por eso presenta iguales propiedades y metodos 
        definidios por la superclase.
        Mountain usa el patron Observer y por lo tanto es un observador y el metodo PositionChange
        recibe actualizaciones cuando cambia de posicion el viajero.
        PositionChange tambien es Polimorfica y por lo tanto Mountain la define segun sus necesidades
        Usa Expert para asignar los puntos y remover a los viajeros, ya que conoce a los viajeros que se ingresaron.
    */
    public class Mountain: AbstractExperience
    {
        private List<AbstractTraveler> travelersPoint = new List<AbstractTraveler>();
        public List<AbstractTraveler> TravelersPoint {get{return travelersPoint;}}

        public Mountain(string name, int limit, int position) : base(name,limit,position)
        {
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
            foreach(AbstractTraveler traveler in this.Travelers)
            {
                if (!(this.TravelersPoint.Contains(traveler)))
                {
                    traveler.Score += traveler.VisitedMontains + 1;
                    this.TravelersPoint.Add(traveler);
                    traveler.VisitedMontains += 1;
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