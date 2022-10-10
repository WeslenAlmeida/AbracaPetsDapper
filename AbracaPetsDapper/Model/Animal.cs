using AbracaPetsDapper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Model
{
    internal class Animal
    {
        #region Constantes
        public readonly static string INSERT = "INSERT INTO Animal(Nome, Raca, Familia, Sexo) VALUES (@Nome, @Raca, @Familia, @Sexo)";

        public readonly static string SELECT = "SELECT NumChip, Nome, Raca, Familia, Sexo FROM Animal";

        public readonly static string UPDATE = $"UPDATE Animal SET Nome = @Nome, Raca = @Raca, Familia = @Familia, Sexo = @Sexo WHERE NumChip = @NumChip";

        public readonly static string SELECTCHIP = $"SELECT NumChip FROM Animal WHERE NumChip = ";

        public readonly static string DELETE = $"DELETE FROM Animal WHERE NumChip = ";
        #endregion

        #region Propriedades
        public int NumChip { get; set; }    
        public string Familia { get; set; }
        public string Raca { get; set; }
        public string Sexo { get; set; }
        public string Nome { get; set; }
        #endregion

        #region Metodos
        public Animal()
        {

        }

        public override string ToString()
        {
            return $"Chip: {NumChip}\nNome: {Nome}\nFamilia: {Familia}\nRaça: {Raca}\nSexo: {Sexo}";
        }

        public void CadastrarAnimal()
        {
            Console.WriteLine("\n>>> CADASTRO DE ANIMAL <<<\n");
            if (!CadastrarFamilia()) return;

            if (!CadastrarRaca()) return;

            if (!CadastrarSexo()) return;

            if (!CadastrarNome()) return;
        }

        public void AlterarCadastro()
        {
            int op;
            Console.WriteLine("\n>>> ALTERAR CADASTRO DO ANIMAL <<<\n");

            if (!VerificarChip()) return;

            Console.WriteLine("[1] Alterar Nome\n[2] Alterar Familia\n[3] Alterar Raca\n[4] Alterar Sexo\n[0] Sair");


            do
            {
                try { op = int.Parse(Console.ReadLine()); }
                catch { Console.WriteLine("Dado inválido!!!"); op = -1; }

            } while (op < 0 && op > 11);

            Animal animal = new AnimalService().GetAnimal(NumChip);

            switch (op)
            {
                case 0:
                    return;

                case 1:
                    if (!CadastrarNome()) return;
                    animal.Nome = this.Nome;
                    break;

                case 2:
                    if (!CadastrarFamilia()) return;
                    animal.Familia = this.Familia;
                    break;

                case 3:
                    if (!CadastrarRaca()) return;
                    animal.Raca = this.Raca;
                    break;

                case 4:
                    if (!CadastrarSexo()) return;
                    animal.Sexo = this.Sexo;
                    break;

             
            }
            new AnimalService().Update(animal);
        }

        public bool DeletarAnimal()
        {
            string op;
            Console.WriteLine("\n>>> DELETAR ANIMAL <<<\n");

            if (!VerificarChip()) return false;

            Animal animal = new AnimalService().GetAnimal(NumChip);

            Console.WriteLine(animal.ToString());

            while (true)
            {
                Console.Write("\nConfirma deletar animal?\n[S] Sim\n[N] Não\nOpção:  ");
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

        private bool VerificarChip()
        {
            do
            {
                Console.Write("Digite o número do chip do animal: ");
                try
                {
                    NumChip = int.Parse(new TratamentoDado().TratarDado(Console.ReadLine()));
                }
                catch { Console.WriteLine("Dado inválido"); NumChip = -1; }  

               
                if (NumChip == 0)
                    return false;
                bool verifica = new AnimalService().VerifChip(NumChip);
                if (!verifica)
                {
                    Console.WriteLine("CHIP não cadastrado!!!");
                    Thread.Sleep(2000);
                    NumChip = -1;
                }

            } while (NumChip < 1);
            return true;
        }

        private bool CadastrarFamilia()
        {
            //Cadastra a Família do Animal
            do
            {
                Console.Write("Digite a Familia do Animal: ");
                Familia = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Familia == "0")
                    return false;
                if (Familia.Length == 0)
                    Console.WriteLine("Campo Obrigatório!!");
            } while (Familia.Length == 0);
            return true;

        }

        private bool CadastrarRaca()
        {
            do
            {
                Console.Write("Digite a Raça do Animal: ");
                Raca = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Raca == "0")
                    return false;
                if (Raca.Length == 0)
                    Console.WriteLine("Campo Obrigatório!!");
            } while (Raca.Length == 0);
            return true;
        }

        private bool CadastrarSexo()
        {
            //Cadastra o Sexo do Animal
            do
            {
                Console.Write("Digite o sexo do Animal [M] Macho / [F] Fêmea: ");
                Sexo = new TratamentoDado().TratarDado(Console.ReadLine()).ToUpper();
                if (Sexo == "0")
                    return false;
                if (Sexo != "M" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                    Thread.Sleep(2000);
                }
            } while (Sexo != "M" && Sexo != "F");
            return true;
        }

        private bool CadastrarNome()
        {
            //Cadastra o Nome do Animal
            Console.Write("Digite o Nome do Animal (Opicional): ");
            if (Nome == "0")
                return false;
            Nome = new TratamentoDado().TratarDado(Console.ReadLine());
            return true;
        }
        #endregion
    }
}

