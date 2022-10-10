using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Model
{
    internal class Animal
    {
        public readonly static string INSERT = "INSERT INTO Animal(Nome, Raca, Familia, Sexo) VALUES (@Nome, @Raca, @Familia, @Sexo)";

        public readonly static string SELECT = "SELECT NumChip, Nome, Raca, Familia, Sexo FROM Animal";

        public readonly static string UPDATE = $"UPDATE Animal SET Nome = @Nome, Raca = @Raca, Familia = @Familia, Sexo = @Sexo WHERE NumChip = @NumChip";
                                              
        public int NumChip { get; set; }    
        public string Familia { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        public string Nome { get; set; }
    }
}
