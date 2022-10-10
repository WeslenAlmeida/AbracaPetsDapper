using AbracaPetsDapper.Config;
using AbracaPetsDapper.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Repository
{
    internal class AdocaoRepository : IAdocaoRepository
    {
        private string _conexao;

        public AdocaoRepository()
        {
            _conexao = ConfigurarBanco.Get();
        }

        public bool Add(Adocao adocao)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Adocao.INSERT, adocao);
                return true;
            }
            return false;
        }

        public List<Adocao> GetAll()
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var adocao = db.Query<Adocao>(Adocao.SELECT);
                return (List<Adocao>)adocao;
            }
        }

        public bool VerifAdocao(int chip)
        {

            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var retorno = db.ExecuteScalar(Adocao.SELECTCHIP + $"{chip}");
                if (retorno != null) return true;
                else return false;
            }
            return false;
        }

        public Adocao GetAdocao(int chip)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var dados = db.Query<Adocao>(Adocao.SELECT + $" WHERE NumCHip = {chip}");
                Adocao adocao = new()
                {
                    DataAdocao = dados.First().DataAdocao,
                    CpfAdotante = dados.First().CpfAdotante,
                    NumChipAnimal = dados.First().NumChipAnimal,
                };
                return adocao;
            }
        }
        public bool Delete(Adocao adocao)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Adotante.DELETE + adocao.NumChipAnimal, adocao);
                return true;
            }
            return false;
        }
    }
}
