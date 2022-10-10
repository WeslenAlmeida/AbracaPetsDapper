using AbracaPetsDapper.Model;
using AbracaPetsDapper.Service;
using System;
using System.Threading;

namespace AbracaPetsDapper
{
    internal class Program
    {
        #region Menu Principal
        static void Menu()
        {
            string op;

            do
            {

                Console.WriteLine("\n|°°°°°°°°°°°°°°°° BEM VINDO ABRACAPETS °°°°°°°°°°°°°°°°|");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|°°°°°°°°°°°°°°°°°°  MENU DE OPÇÕES  °°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 1 : ADOTANTE                                 |");
                Console.WriteLine("|   opção 2 : ANIMAL                                   |");
                Console.WriteLine("|   opção 3 : ADOÇÃO                                   |");
                Console.WriteLine("|                                                      |");
                Console.WriteLine("|   opção 0 : Sair                                     |");
                Console.WriteLine("|______________________________________________________|");
                Console.WriteLine("\nInforme a opção que deseja realizar");

                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }

            } while (op != "1" && op != "2" && op != "3" && op != "0");

            switch (op)
            {

                case "1":
                    Adotante();
                    Console.Clear();
                    Menu();
                    break;

                case "2":
                    Animal();
                    Console.Clear();
                    Menu();
                    break;

                case "3":
                    Adocao();
                    Console.Clear();
                    Menu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion

        #region Menu Adotante
        static void Adotante()
        {
            Console.Clear();
            Adotante adotante = new();
            
            string op;
            do
            {

                Console.WriteLine("\n|°°°°°°°°°°°°°°°°°°° MENU ADOTANTE °°°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("|  1 - Cadastrar Adotante                             |");
                Console.WriteLine("|  2 - Alterar Adotante                               |");
                Console.WriteLine("|  3 - Exibir Lista de Adotante                       |");
                Console.WriteLine("|  4 - Excluir Adotante                               |");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("|  0 - Encerrar                                       |");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("|_____________________________________________________|");

                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "4" &&  op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }
            } while (op != "1" && op != "2" && op != "3" && op != "4" &&  op != "0");

            switch (op)
            {
                case "1":
                    adotante.CadastraAdotante();
                    new AdotanteService().Add(adotante);
                    Console.WriteLine("Adotante cadastrado com sucesso!!!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Menu();
                    break;

                case "2":
                    adotante.AlterarCadastro();
                    new AdotanteService().Update(adotante);
                    Console.WriteLine("Adotante alterado com sucesso!!!");
                    
                    Console.Clear();
                    Menu();
                    break;

                case "3":
                    new AdotanteService().GetAll();
                    Console.WriteLine("Pressione Enter para continuar....");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;

                case "4":
                    if (adotante.DeletarAdotante())
                    {
                        new AdotanteService().Delete(adotante);
                        Console.WriteLine("Exclusão realizada!!!");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("Exclusão Cancelada!!!");
                        Thread.Sleep(2000);
                    }
                    Console.Clear();
                    Menu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;
            }

        }
        #endregion

        #region Menu Animal
        static void Animal()
        {
            Console.Clear();
            Animal animal = new();

            string op;
            do
            {

                Console.WriteLine("\n|°°°°°°°°°°°°°°°°°°°  MENU ANIMAL  °°°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("|  1 - Cadastrar Animal                               |");
                Console.WriteLine("|  2 - Alterar Animal                                 |");
                Console.WriteLine("|  3 - Exibir Lista de Animal                         |");
                Console.WriteLine("|  4 - Excluir Animal                                 |");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("|  0 - Encerrar                                       |");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("|_____________________________________________________|");

                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" && op != "4" && op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }
            } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "0");

            switch (op)
            {
                case "1":
                    animal.CadastrarAnimal();
                    new AnimalService().Add(animal);
                    Console.WriteLine("Animal cadastrado com sucesso!!!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Menu();
                    break;

                case "2":
                    animal.AlterarCadastro();
                    new AnimalService().Update(animal);
                    Console.WriteLine("Animal alterado com sucesso!!!");

                    Console.Clear();
                    Menu();
                    break;

                case "3":
                    new AnimalService().GetAll();
                    Console.WriteLine("Pressione Enter para continuar....");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    break;

                case "4":
                    if (animal.DeletarAnimal())
                    {
                        new AnimalService().Delete(animal);
                        Console.WriteLine("Exclusão realizada!!!");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("Exclusão Cancelada!!!");
                        Thread.Sleep(2000);
                    }
                    Console.Clear();
                    Menu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;
            }

        }
        #endregion

        #region Menu Adocao
        static void Adocao()
        {

            Console.Clear();
            Adocao adocao = new();
            string op;
            do
            {

                Console.WriteLine("\n|°°°°°°°°°°°°°°°°°°°° MENU ADOÇÂO °°°°°°°°°°°°°°°°°°°°|");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("|  1 - Cadastrar Adoção                               |");
                Console.WriteLine("|  2 - Exibir Lista de Adoção                         |");
                Console.WriteLine("|  3 - Exluir Adoção                                  |");
                Console.WriteLine("|                                                     |");
                Console.WriteLine("|  0 - Encerrar                                       |");
                Console.WriteLine("|_____________________________________________________|");

                op = Console.ReadLine();
                if (op == "0")
                    return;
                if (op != "1" && op != "2" && op != "3" &&  op != "0")
                {
                    Console.Clear();
                    Console.WriteLine("Opção inválida!");
                }
            } while (op != "1" && op != "2" && op != "3" &&  op != "0");

            switch (op)
            {
                case "1":
                    adocao.CadastrarAdocao();
                    new AdocaoService().Add(adocao);
                    Console.WriteLine("Adoção cadastrada com sucesso!!!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    Menu();
                    break;

                case "2":
                    new AdocaoService().GetAll();
                    Console.WriteLine("Pressione Enter para continuar....");
                    Console.ReadKey();
                    Console.Clear();
                    Menu();
                    
                    break;

                case "3":
                    if (adocao.DeletarAdocao())
                    {
                        new AdocaoService().Delete(adocao);
                        Console.WriteLine("Exclusão realizada!!!");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.WriteLine("Exclusão Cancelada!!!");
                        Thread.Sleep(2000);
                    }
                    Console.Clear();
                    Menu();
                    break;

                case "0":
                    Environment.Exit(0);
                    break;
            }

        }
        #endregion

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
