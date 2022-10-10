using AbracaPetsDapper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Repository
{
    internal interface IAdocaoRepository
    {
        public bool Add(Adocao adocao);

        public bool VerifAdocao(int chip);

       public List<Adocao> GetAll();
        public Adocao GetAdocao(int chip);

        public bool Delete(Adocao adocao);
    }
}
