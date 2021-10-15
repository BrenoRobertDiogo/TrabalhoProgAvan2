using TrabalhoProgAvan2.models;
using System;
using System.Collections.Generic;

namespace TrabalhoProgAvan2
{
    public class Controlador
    {
        public Usuario user { get; set; }

        public void Iniciar(Recomendacao recomendacao, Boolean userCriado = false)
        {
            Random random = new Random();
            this.user = this.user == null ? Controlador.criaUsuario() : this.user;

            Console.Write(
                "======================================\n" +
                "====        VISITAR ANIMAL        ====\n" +
                "======================================\n" +
                "====        ESCOLHA O SETOR       ====\n" +
                "======================================\n"
                );
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


            this.corVermelha("0");
            Console.WriteLine($" - Recomendação");
            Console.WriteLine($"======================================");

            Console.WriteLine($"{this.corAzul("1")} - Repteis");

            Console.WriteLine($"{this.corAzul("2")} - Peixes");

            Console.WriteLine($"{this.corAzul("3")} - Mamiferos");

            Console.WriteLine($"{this.corAzul("4")} - Aves");

            Console.WriteLine($"====            OPERAÇÕES         ====");
            Console.WriteLine($"{this.corVerde("5")} Taxonomia do animal atual");
            Console.WriteLine($"{this.corVerde("6")} - Animais que visitei");
            Console.Write($"\nEscolha o número:");
            int escolha = int.Parse(Console.ReadLine());
            // Console.Clear();
            int mandar;
            switch (escolha)
            {
                case 0:
                    // Recomendação
                    List<Animal> visited = this.user.AnimaisVisitados;
                    /* Visitou mais de um animal */
                    if (visited.Count > 1)
                    {

                        Animal animalRecomendado = recomendacao.gerarRecomendacao(this.user, visited[visited.Count - 1]);
                        Console.Clear();
                        Console.WriteLine($"=======================================");
                        Console.WriteLine($"Recomendamos {animalRecomendado.taxonomia.especie}");
                        Console.WriteLine($"=======================================");
                        Controlador.digitarContinuar();
                    }
                    Iniciar(recomendacao, this.user == null);
                    break;

                case 1:
                    // pega um Reptei aleatório da lista
                    for (int i = 0; i < RepteisTax.Count; i++)
                    {
                        Console.WriteLine($"{this.corAzul($"{i}")} - {RepteisTax[i].especie}");
                    }
                    Console.Write($"Animal a ser escolhido: ");

                    mandar = int.Parse(Console.ReadLine());
                    Repteis RepteisAleatorio = new Repteis(RepteisTax[mandar]);
                    this.user.visitarAnimal(RepteisAleatorio);


                    break;
                case 2:
                    // pega um Peixe aleatório da lista
                    for (int i = 0; i < PeixesTax.Count; i++)
                    {
                        Console.WriteLine($"{this.corAzul($"{i}")} - {PeixesTax[i].especie}");
                    }
                    Console.Write($"Animal a ser escolhido: ");

                    mandar = int.Parse(Console.ReadLine());
                    Peixes PeixesAleatorio = new Peixes(PeixesTax[mandar]);
                    this.user.visitarAnimal(PeixesAleatorio);
                    break;
                case 3:
                    // pega um Mamifero aleatório da lista
                    for (int i = 0; i < MamiferosTax.Count; i++)
                    {
                        Console.WriteLine($"{this.corAzul($"{i}")} - {MamiferosTax[i].especie}");
                    }
                    Console.Write($"Animal a ser escolhido: ");
                    mandar = int.Parse(Console.ReadLine());
                    Mamiferos MamiferosAleatorio = new Mamiferos(MamiferosTax[mandar]);
                    this.user.visitarAnimal(MamiferosAleatorio);
                    break;
                case 4:
                    // pega um Ave aleatório da lista
                    for (int i = 0; i < AvesTax.Count; i++)
                    {
                        Console.WriteLine($"{this.corAzul($"{i}")} - {AvesTax[i].especie}");
                    }
                    Console.Write($"Animal a ser escolhido: ");

                    mandar = int.Parse(Console.ReadLine());
                    Aves AvesAleatorio = new Aves(AvesTax[mandar]);
                    this.user.visitarAnimal(AvesAleatorio);
                    break;
                case 5:
                    // Mostra a taxonomia do animal atual
                    if (this.user.AnimaisVisitados.Count < 1)
                    {
                        Console.WriteLine("Você ainda não visitou nenhum animal!");
                        break;
                    }
                    this.user.mostraTaxonomiaAnimal();
                    break;
                case 6:
                    // Mostra a lista de animais visitados
                    this.user.mostraAnimaisVisitados();
                    break;
                default:
                    Console.WriteLine("Você digitou um valor inválido!");
                    Controlador.digitarContinuar();
                    break;
            }

            if (this.user.AnimaisVisitados.Count > 1 && escolha < 5)
            {
                Controlador.perguntaNota(this.user);
            }

            Controlador.digitarContinuar();
            Iniciar(recomendacao, this.user == null);
        }


        private static double perguntaNota(Usuario user)
        {
            Console.Clear();
            Console.Write($"De 0 a 10, quando você gostou do {user.AnimaisVisitados[user.AnimaisVisitados.Count - 2].taxonomia.especie} : ");
            double resultadoNota = double.Parse(Console.ReadLine());
            if (resultadoNota > 0 && resultadoNota < 11)
            {
                return resultadoNota;
            }
            else
            {
                Console.WriteLine("Valores entre 0 e 11 somente.");
                return Controlador.perguntaNota(user);
            }
        }

        private string corVermelha(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(texto);
            Console.ResetColor();
            return "";
        }
        private string corVerde(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(texto);
            Console.ResetColor();
            return "";
        }
        private string corAzul(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(texto);
            Console.ResetColor();
            return "";
        }


        private static Usuario criaUsuario()
        {
            string nome = "";
            int idade = 0;
            char sexo = 'a';
            Console.Write(
                "======================================\n" +
                "====           BEM VINDO          ====\n" +
                "======================================\n" +
                "====  PRECISAMOS DE ALGUNS DADOS  ====\n" +
                "======================================\n"
                );
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            try
            {
                Console.Write("Idade: ");
                idade = int.Parse(Console.ReadLine());
                Console.Write("Sexo: ");
                sexo = char.Parse(Console.ReadLine());

            }
            catch (Exception ex)
            {
                Console.Write(
                "======================================\n" +
                "====        UM ERRO OCORREU       ====\n" +
                "======================================\n" +
                "====           DETALHES           ====\n" +
                "======================================\n\n" +
                               ex.Message + "\n\n"
                );
                Controlador.digitarContinuar();
                criaUsuario();
            }

            return new Usuario(nome, idade, sexo);

        }

        public static void digitarContinuar()
        {
            Console.Write(
                "======================================\n" +
                "====     DIGITE QUALQUER TECLA    ====\n" +
                "======================================\n"
                );
            Console.ReadKey();
            Console.Clear();
        }
    }
}