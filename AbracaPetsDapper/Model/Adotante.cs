using AbracaPetsDapper.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbracaPetsDapper.Model
{
    internal class Adotante
    {
        #region Constantes
        public readonly static string INSERT = "INSERT INTO Adotante(CPF, Nome, DataNasc, Sexo, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, CEP)" +
                                               " VALUES (@CPF, @Nome, @DataNasc, @Sexo, @Telefone, @Logradouro, @Numero, @Complemento, @Bairro, @Cidade, @Estado, @Cep)";

        public readonly static string SELECT = "SELECT CPF, Nome, DataNasc, Sexo, Telefone, Logradouro, Numero, Complemento, Bairro, Cidade, Estado, CEP FROM Adotante";

        public readonly static string UPDATE = "UPDATE Adotante SET CPF = @Cpf, Nome = @Nome, DataNasc = @DataNasc, Sexo = @Sexo, Telefone = @Telefone, Logradouro = @Logradouro," +
                                               " Numero =  @Numero, Complemento = @Complemento, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado, CEP = @Cep WHERE CPF = @CPF";

        public readonly static string SELECTCPF = $"SELECT CPF FROM Adotante WHERE CPF = ";

        public readonly static string DELETE = $"DELETE FROM Adotante WHERE CPF = ";
        #endregion

        #region Propriedades
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string DataNasc { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        #endregion

        #region Métodos
        public Adotante()
        {

        }

        public override string ToString()
        {
            return $"CPF: {CPF}\nNome: {Nome}\nData de Nascimento: {DataNasc}\nSexo: {Sexo}\nTelefone: {Telefone}\n" +
                $"Logradouro: {Logradouro}\nNúmero: {Numero}\nComplemento: {Complemento}\nBairro: {Bairro}\nCidade: {Cidade}\nEstado: {Estado}\nCEP: {Cep}";
        }

        public void CadastraAdotante()
        {
            Console.WriteLine("\n>>> CADASTRO DE ADOTANTE <<<\n");

            if (!CadastrarCPF()) return;

            if (!CadastrarNome()) return;

            if (!CadastrarDataNasc()) return;

            if (!CadastrarSexo()) return;

            if (!CadastrarTelefone()) return;

            if (!CadastrarLogradouro()) return;

            if (!CadastrarNumResidencia()) return;

            if (!CadastrarComplemento()) return;

            if (!CadastrarBairro()) return;

            if (!CadastrarCidade()) return;

            if (!CadastrarEstado()) return;

            if (!CadastrarCEP()) return;
        }

        public void AlterarCadastro()
        {
            int op;
            Console.WriteLine("\n>>> ALTERAR CADASTRO DE ADOTANTE <<<\n");

            if (!VerificarCPF()) return;

            Console.WriteLine("[1] Alterar Nome\n[2] Alterar Data de Nascimento\n[3] Alterar Sexo\n[4] Alterar Telefone\n[5] Alterar Logradouro" +
                "\n[6] Alterar Número Residencial\n[7] Complemento\n[8] Alterar Bairro\n[9] Alterar Cidade\n[10] Alterar Estado\n[11] Alterar CEP\n[0] Sair");
            do
            {
                try { op = int.Parse(Console.ReadLine());}
                catch { Console.WriteLine("Dado inválido!!!"); op = -1; }   
                
            } while (op < 0 && op > 11);

            Adotante adotante = new AdotanteService().GetAdotante(CPF);

            switch (op)
            {
                case 0:
                    return;

                case 1:
                    if (!CadastrarNome()) return;
                    adotante.Nome = this.Nome;
                    break;

                case 2:
                    if (!CadastrarDataNasc()) return;
                    adotante.DataNasc = this.DataNasc;
                    break;

                case 3:
                    if (!CadastrarSexo()) return;
                    adotante.Sexo = this.Sexo;
                    break;

                case 4:
                    if (!CadastrarTelefone()) return;
                    adotante.Telefone = this.Telefone;
                    break;

                case 5:
                    if (!CadastrarLogradouro()) return;
                    adotante.Logradouro = this.Logradouro;  
                    break;

                case 6:
                    if (!CadastrarNumResidencia()) return;
                    adotante.Numero = this.Numero;  
                    break;

                case 7:
                    if (!CadastrarComplemento()) return;
                    adotante.Complemento = this.Complemento;    
                    break;

                case 8:
                    if (!CadastrarBairro()) return;
                    adotante.Bairro = this.Bairro;  
                    break;

                case 9:
                    if (!CadastrarCidade()) return;
                    adotante.Cidade = this.Cidade;  
                    break;

                case 10:
                    if (!CadastrarEstado()) return;
                    adotante.Estado = this.Estado;  
                    break;

                case 11:
                    if (!CadastrarCEP()) return;
                    adotante.Cep = this.Cep;    
                    break;
            }
            new AdotanteService().Update(adotante);
        }

        public void DeletarAdotante()
        {
            string op;
            Console.WriteLine("\n>>> DELETAR ADOTANTE <<<\n");

            if(!VerificarCPF()) return;

            Adotante adotante = new AdotanteService().GetAdotante(CPF);

            Console.WriteLine(adotante.ToString());

            while (true)
            {
                Console.Write("\nConfirma deletar adotante?\n[S] Sim\n[N] Não\nOpção:  ");
                op = Console.ReadLine().ToUpper();

                if (op == "0") return;
                else if (op != "S" && op != "N") Console.WriteLine("Dado inválido");
                else break;
            }

            if(op == "S") new AdotanteService().Delete(adotante);
            else return;
        }

        private bool VerificarCPF()
        {
            do
            {
                Console.Write("Digite seu CPF: ");
                CPF = new TratamentoDado().TratarDado(Console.ReadLine());
                if (CPF == "0")
                    return false;
                if (!ValidaCPF(CPF))
                {
                    Console.WriteLine("Digite um CPF Válido!");
                    Thread.Sleep(2000);
                }
                else
                {
                    bool verifica = new AdotanteService().VerifCPF(CPF);
                    if (!verifica)
                    {
                        Console.WriteLine("CPF não cadastrado!!!");
                        Thread.Sleep(2000);
                        CPF = "";
                    }
                }

            } while (!ValidaCPF(CPF) || CPF == "");
            return true;
        }

        private bool CadastrarCPF()
        {
            do
            {
                Console.Write("Digite seu CPF: ");
                CPF = new TratamentoDado().TratarDado(Console.ReadLine());
                if (CPF == "0")
                    return false;
                if (!ValidaCPF(CPF))
                {
                    Console.WriteLine("Digite um CPF Válido!");
                    Thread.Sleep(2000);
                }
                else
                {

                    bool verifica = new AdotanteService().VerifCPF(CPF);
                    if (verifica)
                    {
                        Console.WriteLine("CPF Já cadastrado!!!");
                        Thread.Sleep(2000);
                        CPF = "";
                    }
                }

            } while (!ValidaCPF(CPF) || CPF == "");
            return true;
        }

        private bool CadastrarNome()
        {
            do
            {
                Console.Write("Digite seu Nome (Max 50 caracteres): ");
                Nome = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Nome == "0")
                    return false;
                if (Nome.Length == 0)
                {
                    Console.WriteLine("Campo Obrigatório!!!!");
                    Thread.Sleep(2000);
                }
                if (Nome.Length > 50)
                {
                    Console.WriteLine("Infome um nome menor que 50 caracteres!!!!");
                    Thread.Sleep(2000);
                }
            } while (Nome.Length > 50 || Nome.Length == 0);
            return true;
        }

        private bool CadastrarDataNasc()
        {
            string data;
            do
            {
                Console.Write("Digite sua data de nascimento (Mês/Dia/Ano): ");
                data = new TratamentoDado().TratarDado(Console.ReadLine());
                if (data == "0")
                    return false;
                if (data == "")
                    Console.WriteLine("Campo Obrigatório!!!");
                DateTime dataNasc;
                while (!DateTime.TryParse(data, out dataNasc))
                {
                    Console.WriteLine("Formato de data incorreto!");
                    break;
                }
                DataNasc = dataNasc.ToString("dd/MM/yyyy");
            } while (data == "");
            return true;
        }

        private bool CadastrarSexo()
        {
            do
            {
                Console.Write("Digite seu sexo [M] Masculino / [F] Feminino / [N] Prefere não informar: ");
                Sexo = new TratamentoDado().TratarDado(Console.ReadLine()).ToUpper();
                if (Sexo == "0")
                    return false;
                if (Sexo != "M" && Sexo != "N" && Sexo != "F")
                {
                    Console.WriteLine("Digite um opção válida!!!");
                    Thread.Sleep(2000);
                }
            } while (Sexo != "M" && Sexo != "N" && Sexo != "F");
            return true;
        }

        private bool CadastrarTelefone()
        {
            do
            {
                Console.Write("Digite seu Telefone: ");
                Telefone = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Telefone.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Telefone == "0")
                    return false;
            } while (Telefone.Length == 0);
            return true;
        }


        private bool CadastrarLogradouro()
        {
            do
            {
                Console.Write("Digite seu logradouro: ");
                Logradouro = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Logradouro.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Logradouro == "0")
                    return false;
            } while (Logradouro.Length == 0);
            return true;
        }

        private bool CadastrarNumResidencia()
        {
            do
            {
                Console.Write("Digite seu número: ");
                Numero = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Numero.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Numero == "0")
                    return false;
            } while (Numero.Length == 0);
            return true;
        }

        private bool CadastrarComplemento()
        {
            do
            {
                Console.Write("Digite o complemento([N] Caso não Possua): ");
                Complemento = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Complemento.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Complemento == "0")
                    return false;
            } while (Complemento.Length == 0);
            return true;
        }

        private bool CadastrarBairro()
        {
            do
            {
                Console.Write("Digite seu bairro: ");
                Bairro = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Bairro.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Bairro == "0")
                    return false;
            } while (Bairro.Length == 0);
            return true;
        }

        private bool CadastrarCidade()
        {
            do
            {
                Console.Write("Digite sua cidade: ");
                Cidade = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Cidade.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Cidade == "0")
                    return false;
            } while (Cidade.Length == 0);
            return true;
        }

        private bool CadastrarEstado()
        {
            do
            {
                Console.Write("Digite seu estado: ");
                Estado = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Estado.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Estado == "0")
                    return false;
            } while (Estado.Length == 0);
            return true;
        }

        private bool CadastrarCEP()
        {
            do
            {
                Console.Write("Digite seu CEP: ");
                Cep = new TratamentoDado().TratarDado(Console.ReadLine());
                if (Cep.Length == 0)
                    Console.WriteLine("Campo Obrigatório!");
                if (Cep == "0")
                    return false;
            } while (Cep.Length == 0);
            return true;
        }

        private static bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");

            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])

                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)

                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[9] != 0)
                    return false;
            }

            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)

            {
                if (numeros[10] != 0)
                    return false;
            }

            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
        #endregion
    }
}
