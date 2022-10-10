using AbracaPetsDapper.Model;
using AbracaPetsDapper.Service;
using System;

namespace AbracaPetsDapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Adotante adotante = new ();
            //adotante.CadastraAdotante();
            //new AdotanteService().Add(adotante);
            //new AdotanteService().GetAll().ForEach(x => Console.WriteLine(x));

            //Animal animal = new();
            //animal.CadastrarAnimal();
            //new AnimalService().Add(animal);
            new AnimalService().GetAll().ForEach(x => Console.WriteLine(x));

            //Adocao adocao = new();
            //adocao.CadastrarAdocao();
            //new AdocaoService().Add(adocao);
            new AdocaoService().GetAll().ForEach(x => Console.WriteLine(x));



        }  
    }
}
