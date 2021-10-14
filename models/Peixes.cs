using System;
namespace TrabalhoProgAvan2.models
{
    public class Peixes : Animal
    {
        public Peixes(string dominio, string reino, string filo, string classe, string ordem, string familia, string genero, string especie) {
            taxonomia = new Taxonomia(dominio, reino, filo, classe, ordem, familia, genero, especie);
        }

        public Peixes(Taxonomia tax) {
            taxonomia = new Taxonomia(tax);
        }

        public override void locomover()
        {
            Console.WriteLine($"Depois nois implementa");
            
        }
    }
}