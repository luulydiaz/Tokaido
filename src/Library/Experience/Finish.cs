using System.Collections.Generic;

namespace Tokaido
{
    /*
        Esta clase es un subtipo de AbstracExperiencia, y por eso presenta iguales propiedades y metodos 
        definidios por la superclase.
        Finish usa el patron Observer y por lo tanto es un observador y el metodo PositionChange
        recibe actualizaciones cuando cambia de posicion el viajero.
        PositionChange tambien es Polimorfica y por lo tanto Finish la define segun sus necesidades
        Usa Expert para asignar los puntos y remover a los viajeros, ya que conoce a los viajeros que se ingresaron.
        Cumple con SRP debido a que su responsabilidad es determina cual o cuales son los viajeros ganadores.
        Utiliza Singleton ya que el camino solo tiene un punto final, solo puede haber una instancia de Finish.
    */
    public class Finish: AbstractExperience
    {
        private static Finish instance = null; 

        private Finish(string name, int limit, int position) : base (name,limit,position)
        {
        } 

        /// <summary>
        /// Crea una instancia de Finish en caso que no exista una
        /// </summary>
        /// <param name="name"></param>
        /// <param name="limit"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Finish Instance(string name, int limit, int position)
        {   
            if (instance == null)  
            {  
                instance = new Finish(name,limit,position);     
            }  
            
            return instance;  
        }

        private List<AbstractTraveler> winners = new List<AbstractTraveler>();
        public List<AbstractTraveler> Winners {get{return winners;}}


        /// <summary>
        /// Se ejecuta cuando hay un cambio en la posicion del viajero
        /// </summary>
        /// <param name="observable"></param>
        public override void PositionChange(AbstractTraveler observable)
        {
            if(observable.Position == this.Position)
            {
                if (this.Limit > this.Travelers.Count)
                {
                    NewTraveler(observable);
                    
                    if (this.Limit == this.Travelers.Count)
                    {
                        WinnersTraveler();
                    }
                }
            }
        }
        
        /// <summary>
        /// Determina los o el ganadores.
        /// </summary>
        public void WinnersTraveler()
        {   
            int maxScore = 0;

            foreach(AbstractTraveler traveler in this.Travelers)
            {
                if (traveler.Score > maxScore)
                {
                    Winners.Clear();
                    maxScore = traveler.Score;
                    Winners.Add(traveler);
                }
                else if(traveler.Score == maxScore)
                {
                    Winners.Add(traveler);
                }
            }
        }
    }
}