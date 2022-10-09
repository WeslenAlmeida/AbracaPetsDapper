using AbracaPetsDapper.Model;
using AbracaPetsDapper.Service;
using System;

namespace AbracaPetsDapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Adotante adotante = new ();

            adotante.CadastraAdotante();

            new AdotanteService().Add(adotante);

            new AdotanteService().GetAll().ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Ufa!");

            Console.Read();
        }
    }
}
