using AbracaPetsDapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Repository
{
    internal interface IAnimalRepository
    {
        bool Add(Animal animal);

        bool Update(Animal animal);

        public bool VerifChip(int chip);

        List<Animal> GetAll();
        public Animal GetAnimal(int chip);

        public bool Delete(Animal animal);
    }
}
