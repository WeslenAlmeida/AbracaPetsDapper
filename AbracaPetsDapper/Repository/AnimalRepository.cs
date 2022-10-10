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
    internal class AnimalRepository : IAnimalRepository
    {
        private string _conexao;

        public AnimalRepository()
        {
            _conexao = ConfigurarBanco.Get();
        }

        public bool Add(Animal animal)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Adotante.INSERT, animal);
                return true;
            }
            return false;
        }

        public List<Animal> GetAll()
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var animal = db.Query<Adotante>(Animal.SELECT);
                return (List<Animal>)animal;
            }
        }

        public bool Update(Animal animal)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Animal.UPDATE, animal);
                return true;
            }
            return false;
        }

        public bool VerifChip(int chip)
        {

            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var retorno = db.ExecuteScalar(Animal.SELECTCHIP + $"{chip}");
                if (retorno != null) return true;
                else return false;
            }
            return false;
        }

        public Animal GetAnimal(int chip)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                var dados = db.Query<Animal>(Animal.SELECT + $" WHERE NumCHip = {chip}");
                Animal animal = new()
                {
                    Familia = dados.First().Familia,
                    Nome = dados.First().Nome,
                    Raca = dados.First().Raca,
                    Sexo = dados.First().Sexo,
                    NumChip = dados.First().NumChip,
                };
                return animal;
            }
        }
        public bool Delete(Animal animal)
        {
            using (var db = new SqlConnection(_conexao))
            {
                db.Open();
                db.Execute(Adotante.DELETE + animal.NumChip, animal);
                return true;
            }
            return false;
        }
    }
}
