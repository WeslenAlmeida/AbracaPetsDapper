using AbracaPetsDapper.Model;
using AbracaPetsDapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Service
{
    internal class AnimalService
    {
        private IAnimalRepository _animalRepository;

        public AnimalService()
        {
            _animalRepository = new AnimalRepository();
        }

        public bool Add(Animal animal)
        {
            return _animalRepository.Add(animal);
        }

        public bool Update(Animal animal)
        {
            return _animalRepository.Update(animal);
        }

        public List<Animal> GetAll()
        {
            return _animalRepository.GetAll();
        }

        public bool VerifChip(int chip)
        {
            return _animalRepository.VerifChip(chip);
        }

        public Animal GetAnimal(int chip)
        {
            return _animalRepository.GetAnimal(chip);
        }

        public bool Delete(Animal animal)
        {
            return _animalRepository.Delete(animal);
        }
    }
}
