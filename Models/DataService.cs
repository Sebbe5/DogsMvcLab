namespace DogsMvc.Models
{
    public class DataService
    {

        List<Dog> dogList = new()
        {
            new Dog { Id = 1, Name = "Bengt", Age = 5},
            new Dog { Id = 2, Name = "Bosse", Age = 7},
            new Dog { Id = 3, Name = "Berra", Age = 2}
        };

        public void AddDog(Dog dog)
        {
            if (dogList.Count != 0)
            {
                dog.Id = dogList.Max(d => d.Id) + 1;
            }
            else { dog.Id = 1; }
            
            dogList.Add(dog);
        }

        public Dog[] GetAllDogs()
        {
            return dogList.ToArray();
        }

        public Dog GetDogById(int id)
        {
            return dogList.SingleOrDefault(d => d.Id == id);
        }

        public void EditDog(Dog newDogInfo)
        {
            Dog dog = GetDogById(newDogInfo.Id);
            dog.Name = newDogInfo.Name;
            dog.Age = newDogInfo.Age;
        }

        internal void RemoveDog(int id)
        {
            dogList.Remove(GetDogById(id));
        }
    }
}
