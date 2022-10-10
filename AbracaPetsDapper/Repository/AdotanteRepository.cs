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

        public bool VerifCPF(string cpf)
        {
            
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var retorno = db.ExecuteScalar(Adotante.SELECTCPF + cpf);
                if (retorno != null) return true;
                else return false;
            }
            return false;
        }

        public Adotante GetAdotante(string cpf)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var dados = db.Query <Adotante>(Adotante.SELECT + $" WHERE CPF = {cpf}");
                Adotante adotante = new()
                {
                    CPF = dados.First().CPF,
                    Nome = dados.First().Nome,
                    DataNasc = dados.First().DataNasc,  
                    Sexo = dados.First().Sexo,  
                    Telefone = dados.First().Telefone,
                    Logradouro = dados.First().Logradouro,
                    Numero = dados.First().Numero,
                    Complemento = dados.First().Complemento,
                    Bairro = dados.First().Bairro,  
                    Cidade = dados.First().Cidade,
                    Estado = dados.First().Estado,
                    Cep = dados.First().Cep,
                };
                return adotante;
            }
        }
        public bool Delete(Adotante adotante)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Adotante.DELETE + adotante.CPF, adotante);
                return true;
            }
            return false;
        }

    }
}
