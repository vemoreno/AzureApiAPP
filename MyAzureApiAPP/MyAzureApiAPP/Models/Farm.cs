using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAzureApiAPP.Models
{
    public class Farm
    {
        public List<Animal> TheFarm { get; set; }

        public Farm()
        {
            FillingFarm();
        }

        public List<Animal> FillingFarm()
        {
            this.TheFarm = new List<Animal>();

            this.TheFarm.Add(new Animal { ID = 10, Fed = false, Type = "Dove" });
            this.TheFarm.Add(new Animal { ID = 11, Fed = false, Type = "Horse" });
            this.TheFarm.Add(new Animal { ID = 12, Fed = false, Type = "Lamb" });
            this.TheFarm.Add(new Animal { ID = 13, Fed = false, Type = "Duck" });
            this.TheFarm.Add(new Animal { ID = 14, Fed = false, Type = "Rabbit" });
            this.TheFarm.Add(new Animal { ID = 15, Fed = false, Type = "Cow" });
            this.TheFarm.Add(new Animal { ID = 16, Fed = false, Type = "Rooster" });
            this.TheFarm.Add(new Animal { ID = 17, Fed = false, Type = "Donkey" });
            this.TheFarm.Add(new Animal { ID = 18, Fed = false, Type = "Pig" });
            this.TheFarm.Add(new Animal { ID = 19, Fed = false, Type = "Goat" });
            this.TheFarm.Add(new Animal { ID = 20, Fed = false, Type = "Turkey" });
            this.TheFarm.Add(new Animal { ID = 21, Fed = false, Type = "Bull" });
            this.TheFarm.Add(new Animal { ID = 22, Fed = false, Type = "Chicken" });

            return this.TheFarm;
        }

        public List<Animal> GetAllTheFarm()
        {
            return this.TheFarm;
        }

        public Animal GetAnimalByID(int ID)
        {
            foreach (Animal A in this.TheFarm)
            {
                if (A.ID == ID)
                    return A;
            }

            return new Animal { Fed=false, ID= -1, Type= "Unknown"};
        }

        public void IncludeAnimal(Animal A)
        {
            
            this.TheFarm.Add(new Animal { Fed = A.Fed, ID = A.ID, Type = A.Type });

            //return A;
        }

        public void FeedAnimal(int ID)
        {
            foreach (Animal A in this.TheFarm)
            {
                if (A.ID == ID)
                {
                    A.Fed = true;
                    break;
                    //return A;
                }
            }

           
        }

        public void TakeOutAnimal(int ID)
        {
            Animal AnimalClone = new Animal();

            foreach (Animal A in this.TheFarm)
            {
                if (A.ID == ID)
                {
                    AnimalClone = A;
                    this.TheFarm.Remove(AnimalClone);
                    break;
                }
            }           
        }
    }

    public class Animal
    {
        public int ID { get; set; }
        public bool Fed { get; set; }
        public string Type { get; set; }
    }
}