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
    internal class AdotanteRepository : IAdotanteRepository
    {
        private string _conexao;

        public AdotanteRepository()
        {
            _conexao = ConfigurarBanco.Get();
        }

        public bool Add(Adotante adotante)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Adotante.INSERT, adotante);
                return true;
            }
            return false;
        }

        public List<Adotante> GetAll()
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var adotante = db.Query<Adotante>(Adotante.SELECT);
                return (List<Adotante>)adotante;
            }
        }

        public bool Update(Adotante adotante)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Adotante.UPDATE, adotante);
                return true;
            }
            return false;
        }
    }
}
