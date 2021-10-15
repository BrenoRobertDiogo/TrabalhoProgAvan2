using System.Collections.Generic;
using System;
using System.Linq;

namespace TrabalhoProgAvan2.models
{
    public class Recomendacao
    {
        List<Usuario> Usuarios { get; set; }

        public Recomendacao()
        {
            this.Usuarios = new List<Usuario>();
            Usuario p1 = new Usuario("Maria", 19, 'F'); // corsa
            Usuario p2 = new Usuario("Renato", 39, 'M'); // Bife
            Usuario p3 = new Usuario("Carimbo", 45, 'M'); // 2 Espiritos
            Usuario p4 = new Usuario("Xequira", 20, 'F'); // FEMALE
            Usuario p5 = new Usuario("Brecesfield", 53, 'M'); // MEN

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

        /* 
            .....
            Como funciona:
            É necessário ter visitado no mínimo dois animais (pegar tamanho lista)
            Os valores serão uma média da nota que ela deu para todas as subclasses
            A 2ª a se comparar vai ter a média com o maior da 1 pessoa e o mesmo tipo
            .....
        */
        public Animal gerarRecomendacao(Usuario pessoaAtual, Animal animal)
        {
            Console.WriteLine("\n\n\nasdasdasd\n\n\n\n");

            List<double> mediaSetoresAtual = this.mediaSetores(pessoaAtual);
            /* Duas maiores notas dos setores */
            List<int> maioresUserAtual = this.doisMaiores(mediaSetoresAtual);
            /* Guardar dados do for */
            double menorRotativo = 1000;
            int indiceMenorRotativo = 0;
            /* Verivica se a pessoa visitou mais de um setor
                Caso não, ele da um Exception
             */
            if (this.podeRecomendar(mediaSetoresAtual))
            {
                throw new System.Exception("Recomendação indisponível, visite mais de uma classe.");
            }

            /* Ao final desse for teremos o índice e o valor da distancia entre as pessoas */
            for (int i = 0; i < this.Usuarios.Count; i++)
            {
                /* 
                    [x]----------------------------------------------------[x]
                     | Pegar o 1º Maior do UserAtual como o 1º do Historico | 
                     | Pegar o 2º Maior do UserAtual como o 2º do Historico |  
                    [x]----------------------------------------------------[x]
                */
                Usuario rotativoAtual = this.Usuarios[i];
                List<double> mediaSetoresRotativo = this.mediaSetores(rotativoAtual);


                double distanciaResult = this.distanciaEuclidiana(
                    Esp1User1: mediaSetoresAtual[maioresUserAtual[0]],
                    Esp2User1: mediaSetoresAtual[maioresUserAtual[1]],
                    Esp1User2: mediaSetoresRotativo[maioresUserAtual[0]],
                    Esp2User2: mediaSetoresRotativo[maioresUserAtual[1]]
                    );
                /* Verificando qual tem a menor distância */
                if (distanciaResult < menorRotativo)
                {
                    menorRotativo = distanciaResult;
                    indiceMenorRotativo = i;
                }
            }

            
            
            Usuario maisProximo = this.Usuarios[indiceMenorRotativo];
            /* Guardar dados do for */
            double maiorNota = 0.0;
            Animal retornar = pessoaAtual.AnimaisVisitados[0]; // Valor aleatório só pra ter
            /* Animal que essa pessoa mais gostou */
            foreach (var item in maisProximo.AnimaisVisitados)
            {
                if (item.Nota > maiorNota)
                {
                    retornar  = item;
                }
            }
            return retornar;
        }
        private double distanciaEuclidiana(double Esp1User1, double Esp2User1, double Esp1User2, double Esp2User2)
        {
            /* DISTÂNCIA EUCLIDIANA */
            // Fórmula: √((x1 – x2)² + (y1 – y2)²)

            double esp1User1, esp2User1, // Espécie usuário 1
                   esp1User2, esp2User2; // Espécie usuário 2

            esp1User1 = Esp1User1; // TODO: Colocar os valores depois!
            esp2User1 = Esp2User1; // TODO: Colocar os valores depois!
            esp1User2 = Esp1User2; // TODO: Colocar os valores depois!
            esp2User2 = Esp2User2; // TODO: Colocar os valores depois!

            double distance = Math.Sqrt((Math.Pow(esp1User1 - esp2User1, 2) + Math.Pow(esp1User2 - esp2User2, 2)));
            return distance;
        }

        private List<int> doisMaiores(List<double> lista)
        {
            List<double> listaV = lista;
            // List<int> retornar = new List<int>();
            double maiorValor1 = listaV.Max();
            listaV.Remove(listaV.IndexOf(maiorValor1));
            double maiorValor2 = listaV.Max();
            return new List<int> { listaV.IndexOf(maiorValor1), listaV.IndexOf(maiorValor2) };

        }

        private bool podeRecomendar(List<double> mediaSetoresAtual)
        {
            int cont = 0;
            Console.WriteLine(mediaSetoresAtual.Count+"\n\n\n\n");

            for (int i = 0; i < mediaSetoresAtual.Count; i++)
            {
                if (mediaSetoresAtual[i] > 0)
                {
                    cont++;
                }
            }
            return cont > 1;
        }

        private List<double> mediaSetores(Usuario pessoa)
        {
            /* 
                1 Réptil, 2 Aves, 3 Mamiferos, 3 Peixes
            */
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
                }
                else if (item.GetType() == typeof(Aves))
                {
                    avesSoma += item.Nota;
                    avesQnt++;
                }
                else if (item.GetType() == typeof(Mamiferos))
                {
                    mamiferoSoma += item.Nota;
                    mamiferoQnt++;
                }
                else if (item.GetType() == typeof(Peixes))
                {
                    peixesSoma += item.Nota;
                    peixesQnt++;
                }

            }

            // 

            return new List<double>
            {
                Math.Round(reptilSoma / reptilQnt, 2),
                Math.Round(avesSoma / avesQnt, 2),
                Math.Round(mamiferoSoma / mamiferoQnt, 2),Math.
                Round (peixesSoma / peixesQnt, 2)
            };
        }

        /* FUNCIONANDO */
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

                    RepteisAleatorio.Nota = random.Next(0, 10);
                    pessoa.AnimaisVisitados.Add(RepteisAleatorio);

                }
                for (var j = 0; j < random.Next(0, 3); j++)
                {
                    Peixes PeixesAleatorio = new Peixes(PeixesTax[random.Next(0, PeixesTax.Count)]);

                    PeixesAleatorio.Nota = random.Next(0, 10);
                    pessoa.AnimaisVisitados.Add(PeixesAleatorio);
                }
                for (var j = 0; j < random.Next(0, 3); j++)
                {
                    Mamiferos MamiferosAleatorio = new Mamiferos(MamiferosTax[random.Next(0, MamiferosTax.Count)]);

                    MamiferosAleatorio.Nota = random.Next(0, 10);
                    pessoa.AnimaisVisitados.Add(MamiferosAleatorio);
                }
                for (var j = 0; j < random.Next(0, 3); j++)
                {
                    Aves AvesAleatorio = new Aves(AvesTax[random.Next(0, AvesTax.Count)]);

                    AvesAleatorio.Nota = random.Next(0, 10);
                    pessoa.AnimaisVisitados.Add(AvesAleatorio);

                }


            }
            List<double> seila = this.mediaSetores(pessoa);

        }

    }
}

/* Repteis  ====   Repteis
Peixes  ====   Peixes
Mamiferos  ====   Mamiferos
Aves  ====   Aves
 */