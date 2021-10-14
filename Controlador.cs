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
            // Peixe
            PeixesTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Actinopterygii", "Perciformes", "Cichlidae", "Oreochromis", "Tilapia"));
            // MamiferosTax    
            MamiferosTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "Mammalia", "Primates", "Homnidae", "Pam", "Chimpanzé"));
            // AvesTax 
            AvesTax.Add(new Taxonomia("Eukaria", "Animalia", "Chordata", "AvesTax", "Ciconiiformes Falconiformes", "Accipitridae Falconidae", "Buteo", "Gavião-asa-de-telha"));

            /* List<Animal> setores = new List<Animal>{
                new RepteisTax(RepteisTax[0]),
                new PeixesTax(PeixesTax[0]),
                new MamiferosTax(MamiferosTax[0]),
                new AvesTax(AvesTax[0])
            }; */

            Console.Write(
                        "[0] - Recomendação" +
                        "\n[1] - Repteis" +
                        "\n[2] - Peixes" +
                        "\n[3] - Mamiferos" +
                        "\n[4] - Aves\n" +
                        "====            OPERAÇÕES         ====\n"+
                        "[5] Taxonomia do animal atual | [6] Animais que visitei\n"+
                        "\nEscolha o número: "
                    );
            int escolha = int.Parse(Console.ReadLine());
            switch (escolha)
            {
                case 0:
                    // Recomendação
                    List<Animal> visited = this.user.AnimaisVisitados;
                    if (visited.Count > 1)
                    {
                        
                        Animal animalRecomendado = recomendacao.gerarRecomendacao(this.user, visited[visited.Count-1]);
                        Console.WriteLine(animalRecomendado.taxonomia.especie);
                        
                    }
                    
                    break;

                case 1:
                    // pega um Reptei aleatório da lista
                    Repteis RepteisAleatorio = new Repteis(RepteisTax[random.Next(0, RepteisTax.Count)]);
                    this.user.visitarAnimal(RepteisAleatorio);
                    break;
                case 2:
                    // pega um Peixe aleatório da lista
                    Peixes PeixesAleatorio = new Peixes(PeixesTax[random.Next(0, PeixesTax.Count)]);
                    this.user.visitarAnimal(PeixesAleatorio);
                    break;
                case 3:
                    // pega um Mamifero aleatório da lista
                    Mamiferos MamiferosAleatorio = new Mamiferos(MamiferosTax[random.Next(0, MamiferosTax.Count)]);
                    this.user.visitarAnimal(MamiferosAleatorio);
                    break;
                case 4:
                    // pega um Ave aleatório da lista
                    Aves AvesAleatorio = new Aves(AvesTax[random.Next(0, AvesTax.Count)]);
                    this.user.visitarAnimal(AvesAleatorio);
                    break;
                case 5:
                    // Mostra a taxonomia do animal atual
                    this.user.mostraTaxonomiaAnimal();
                    break;
                case 6:
                    // Mostra a lista de animais visitados
                    this.user.mostraAnimaisVisitados();
                    break;
                default:
                    break;
            }


            
            Controlador.digitarContinuar();
            Iniciar(recomendacao, this.user == null);
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

        public static void digitarContinuar() {
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