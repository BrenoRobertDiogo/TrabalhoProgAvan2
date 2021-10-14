using System.Collections.Generic;
using System;

namespace TrabalhoProgAvan2.models
{
    public class Recomendacao
    {
        List<Usuario> Usuarios { get; set; }

        public Recomendacao()
        {
            this.Usuarios = new List<Usuario>();
            Usuario p1 = new Usuario("Corsa", 13, 'C'); // corsa
            Usuario p2 = new Usuario("Bife", 13, 'B'); // Bife
            Usuario p3 = new Usuario("Life", 100, 'T'); // 2 lifes
            Usuario p4 = new Usuario("Teste", 20, 'F'); // FEMALE
            Usuario p5 = new Usuario("Teste3", 53, 'M'); // MEN

            this.adicionaPessoas(ref p1);
            p1.mostraAnimaisVisitados();
            this.adicionaPessoas(ref p2);
            p2.mostraAnimaisVisitados();
            this.adicionaPessoas(ref p3);
            p3.mostraAnimaisVisitados();
            this.adicionaPessoas(ref p4);
            p4.mostraAnimaisVisitados();
            this.adicionaPessoas(ref p5);
            p5.mostraAnimaisVisitados();

            this.Usuarios.Add(p1);
            this.Usuarios.Add(p2);
            this.Usuarios.Add(p3);
            this.Usuarios.Add(p4);
            this.Usuarios.Add(p5);


        }

        public Recomendacao(Usuario user)
        {
            this.Usuarios.Add(user);
        }

        public Animal gerarRecomendacao(Animal animal)
        {

            /* 
                .....
                Como funciona:
                É necessário ter visitado no mínimo dois animais (pegar tamanho lista)
                Os valores serão uma média da nota que ela deu para todas as subclasses
                A 2ª a se comparar vai ter a média com o maior da 1 pessoa e o mesmo tipo
                .....
            */


            /* DISTÂNCIA EUCLIDIANA */
            // Fórmula: d=√∑ni=1(ai−bi)2

            /* Base pra utilizar depois */
            double reptil, aves, mamifero, peixes;
            reptil = 12d;   // TODO: Colocar os valores depois!
            aves = 13d;     // TODO: Colocar os valores depois!
            mamifero = 11d; // TODO: Colocar os valores depois!
            peixes = 10d;   // TODO: Colocar os valores depois!

            var distance = Math.Sqrt((Math.Pow(reptil - aves, 2) + Math.Pow(mamifero - peixes, 2)));

            throw new System.Exception("TEM QUE IMPLEMENTAR ");
        }

        private List<double> mediaSetores(Usuario pessoa)
        {
            double reptilSoma = 0;
            int reptilQnt = 0;
            double avesSoma = 0;
            int avesQnt = 0;
            double mamiferoSoma = 0;
            int mamiferoQnt = 0;
            double peixesSoma = 0;
            int peixesQnt = 0;

            foreach (Animal item in pessoa.AnimaisVisitados)
            {
                // Console.WriteLine(item.GetType());
                // Console.WriteLine(item.GetType() == typeof(Aves));
                if (item.GetType() == typeof(Repteis))
                {
                    reptilSoma += item.Nota;
                    reptilQnt++;
                } else if (item.GetType() == typeof(Aves))
                {
                    avesSoma += item.Nota;
                    avesQnt++;
                } else if (item.GetType() == typeof(Mamiferos))
                {
                    mamiferoSoma += item.Nota;
                    mamiferoQnt++;
                } else if (item.GetType() == typeof(Peixes))
                {
                    peixesSoma += item.Nota;
                    peixesQnt++;
                }

            }

            return new List<double> 
            { 
                Math.Round(reptilSoma / reptilQnt, 2), 
                Math.Round(avesSoma / avesQnt, 2), 
                Math.Round(mamiferoSoma / mamiferoQnt, 2),Math.
                Round (peixesSoma / peixesQnt, 2) 
            };
        }

        private void adicionaPessoas(ref Usuario pessoa)
        {
            Random random = new Random();
            /* FAZ RANDOMICAMENTE */
            // dominio, reino, filo, classe, ordem, familia, genero, especie
            List<Taxonomia> RepteisTax = new List<Taxonomia>();
            List<Taxonomia> PeixesTax = new List<Taxonomia>();
            List<Taxonomia> MamiferosTax = new List<Taxonomia>();
            List<Taxonomia> AvesTax = new List<Taxonomia>();

            // Répteis (Tartaruga cabeçuda)
            RepteisTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Reptilia", "Testudines", "Cheloniidae", "Caretta Rafinesque", "Tartaruga cabeçuda"));
            RepteisTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Reptilia", "Testudines", "Cheloniidae", "Caretta Rafinesque", "Calango"));
            RepteisTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Reptilia", "Testudines", "Cheloniidae", "Caretta Rafinesque", "Jararaca"));
            // Peixe
            PeixesTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Actinopterygii", "Perciformes", "Cichlidae", "Oreochromis", "Tilapia"));
            PeixesTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Actinopterygii", "Perciformes", "Cichlidae", "Oreochromis", "Dourado"));
            PeixesTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Actinopterygii", "Perciformes", "Cichlidae", "Oreochromis", "Piranha"));
            // MamiferosTax    
            MamiferosTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Mammalia", "Primates", "Homnidae", "Pam", "Chimpanzé"));
            MamiferosTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Mammalia", "Primates", "Homnidae", "Pam", "Canguru"));
            MamiferosTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Mammalia", "Primates", "Homnidae", "Pam", "Girafa"));
            // AvesTax 
            AvesTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "AvesTax", "Ciconiiformes Falconiformes", "Accipitridae Falconidae", "Buteo", "Gavião-asa-de-telha"));
            AvesTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "AvesTax", "Ciconiiformes Falconiformes", "Accipitridae Falconidae", "Buteo", "Tucano"));
            AvesTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "AvesTax", "Ciconiiformes Falconiformes", "Accipitridae Falconidae", "Buteo", "Pica-Pau"));


            for (var i = 0; i < 5; i++)
            {
                for (var j = 0; j < random.Next(0, 3); j++)
                {
                    Repteis RepteisAleatorio = new Repteis(RepteisTax[random.Next(0, RepteisTax.Count)]);
                    // Console.WriteLine(RepteisAleatorio.GetType());

                    RepteisAleatorio.Nota = random.Next(0, 10);
                    pessoa.AnimaisVisitados.Add(RepteisAleatorio);

                    // Console.WriteLine($"asdasdasd");
                }
                for (var j = 0; j < random.Next(0, 3); j++)
                {
                    Peixes PeixesAleatorio = new Peixes(PeixesTax[random.Next(0, PeixesTax.Count)]);
                    // Console.WriteLine(PeixesAleatorio.GetType());

                    PeixesAleatorio.Nota = random.Next(0, 10);
                    pessoa.AnimaisVisitados.Add(PeixesAleatorio);
                    // Console.WriteLine($"asdasdasd");
                }
                for (var j = 0; j < random.Next(0, 3); j++)
                {
                    Mamiferos MamiferosAleatorio = new Mamiferos(MamiferosTax[random.Next(0, MamiferosTax.Count)]);
                    // Console.WriteLine(MamiferosAleatorio.GetType());

                    MamiferosAleatorio.Nota = random.Next(0, 10);
                    pessoa.AnimaisVisitados.Add(MamiferosAleatorio);
                    // Console.WriteLine($"asdasdasd");
                }
                for (var j = 0; j < random.Next(0, 3); j++)
                {
                    Aves AvesAleatorio = new Aves(AvesTax[random.Next(0, AvesTax.Count)]);
                    // Console.WriteLine(AvesAleatorio.GetType());

                    AvesAleatorio.Nota = random.Next(0, 10);
                    pessoa.AnimaisVisitados.Add(AvesAleatorio);
                    // Console.WriteLine($"asdasdasd");

                }


            }
            List<double> seila =  this.mediaSetores(pessoa);
            Console.WriteLine($"===================");
            
            Console.WriteLine(seila[0]);
            Console.WriteLine(seila[1]);
            Console.WriteLine(seila[2]);
            Console.WriteLine(seila[3]);
            Console.WriteLine($"===================");
            

        }

    }
}

/* Repteis  ====   Repteis
Peixes  ====   Peixes
Mamiferos  ====   Mamiferos
Aves  ====   Aves
 */