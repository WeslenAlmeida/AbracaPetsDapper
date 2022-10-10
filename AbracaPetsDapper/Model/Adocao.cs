using AbracaPetsDapper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Model
{
   
    internal class Adocao
    {
        #region Constantes
        public readonly static string INSERT = "INSERT INTO Adocao(FK_Animal_NumChip, FK_Adotante_CPF) VALUES (@NumChipAnimal, @CpfAdotante)";

        public readonly static string SELECT = "SELECT DataAdocao, FK_Animal_NumChip, FK_Adotante_CPF FROM Adocao";

        public readonly static string SELECTCHIP = $"SELECT FK_Animal_NumChip FROM Adocao WHERE FK_Animal_NumChip = ";

        public readonly static string DELETE = $"DELETE FROM Adocao WHERE FK_Animal_NumChip = ";
        #endregion

        #region Propriedades
        public string CpfAdotante { get; set; }
        public string NumChipAnimal { get; set; }
        public DateTime DataAdocao { get; set; }
        #endregion

        #region Metodos
        public Adocao()
        {

        }

        public override string ToString()
        {
            return $"Data da adoção: {DataAdocao.ToString("dd/MM/yyyy")}\nCPF do Adotante: {CpfAdotante}\nChip do animal adotado: {NumChipAnimal}";
        }

        public void CadastrarAdocao()
        {
            string cpf;
            int chip;

            Console.WriteLine("\n>>> CADASTRO DE ADOÇÃO <<<");
            do
            {
                Console.Write("Digite o CPF do Adotante: ");
                cpf = new TratamentoDado().TratarDado(Console.ReadLine());
                if (cpf == "0") return;
                if (!new AdotanteService().VerifCPF(cpf)) Console.WriteLine("CPF não cadastrado!");

            } while (!new AdotanteService().VerifCPF(cpf));
            
            CpfAdotante = cpf;

            do
            {
                Console.Write("Digite o Chip do animal: ");
                try { chip = int.Parse(Console.ReadLine()); } catch { Console.WriteLine("Dado inválido!"); chip = -1; };

                if (chip == 0) return;

                if (new AdocaoService().VerifAdocao(chip))
                {
                    Console.WriteLine("Animal já Adotado!!!");
                    chip = -1;
                }
            } while (chip < 0);
            NumChipAnimal = chip.ToString();
        }

        public bool DeletarAdocao()
        {
            int chip;
            string op;
            Console.WriteLine("\n>>> DELETAR ADOÇÃO <<<\n");
            do
            {
                Console.Write("Digite o Chip do animal: ");
                try { chip = int.Parse(Console.ReadLine()); } catch { Console.WriteLine("Dado inválido!"); chip = -1; };

                if (chip == 0) return false;

                if (!new AdocaoService().VerifAdocao(chip))
                {
                    Console.WriteLine("Animal não adotado ou cadastrado!!!");
                    chip = -1;
                }
            } while (chip < 0);

            Adocao adocao = new AdocaoService().GetAdocao(chip);

            Console.WriteLine(adocao.ToString());

            while (true)
            {
                Console.Write("\nConfirma deletar adoção?\n[S] Sim\n[N] Não\nOpção:  ");
                op = Console.ReadLine().ToUpper();

                if (op == "0") return false;
                else if (op != "S" && op != "N") Console.WriteLine("Dado inválido");
                else break;
            }

            if (op == "S") 
            {
                return true;
            } 
            else return false;
        }
        #endregion
    }
}
