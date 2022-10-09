using AbracaPetsDapper.Model;
using AbracaPetsDapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Service
{
    internal class AdotanteService
    {
        private IAdotanteRepository _adotanteRepositorio;

        public AdotanteService()
        {
            _adotanteRepositorio = new AdotanteRepository();    
        }

        public bool Add(Adotante adotante)
        {
            return _adotanteRepositorio.Add(adotante);  
        }

        public bool Update(Adotante adotante)
        {
            return _adotanteRepositorio.Update(adotante);
        }

        public List<Adotante> GetAll()
        {
            return _adotanteRepositorio.GetAll();
        }
    }
}
