using AbracaPetsDapper.Model;
using AbracaPetsDapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Service
{
    internal class AdocaoService
    {
        private IAdocaoRepository _adocaoRepository;

        public AdocaoService()
        {
            _adocaoRepository = new AdocaoRepository();
        }

        public bool Add(Adocao adocao)
        {
            return _adocaoRepository.Add(adocao);
        }

        public List<Adocao> GetAll()
        {
            return _adocaoRepository.GetAll();
        }

        public bool VerifAdocao(int chip)
        {
            return _adocaoRepository.VerifAdocao(chip);
        }

        public Adocao GetAdocao(int chip)
        {
            return _adocaoRepository.GetAdocao(chip);
        }

        public bool Delete(Adocao adocao)
        {
            return _adocaoRepository.Delete(adocao);
        }
    }
}
