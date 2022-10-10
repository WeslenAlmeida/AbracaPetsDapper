using AbracaPetsDapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Repository
{
    internal interface IAdotanteRepository
    {
        bool Add(Adotante adotante);

        bool Update(Adotante adotante);

        public bool VerifCPF(string cpf);

        List<Adotante> GetAll();    
        public Adotante GetAdotante(string cpf);

        public bool Delete(Adotante adotante);
    }
}
