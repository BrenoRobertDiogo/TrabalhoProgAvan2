using TrabalhoProgAvan2.models;
using System;
namespace TrabalhoProgAvan2
{
    public class Controlador
    {
        public Usuario user { get; set; }


        public void Iniciar(Boolean userCriado = false)
        {
            this.user = this.user == null ? Controlador.criaUsuario() : this.user;
            Console.Write(
                "======================================\n" +
                "====        VISITAR ANIMAL        ====\n" +
                "======================================\n" 
                );

            Console.ReadKey();
            Iniciar(this.user == null);
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
                "======================================\n" +
                "======================================\n\n" +
                               ex.Message +"\n\n"+
                "======================================\n" +
                "======================================\n" +
                "====     DIGITE QUALQUER TECLA    ====\n" +
                "======================================\n"
                );
                Console.ReadKey();
                Console.Clear();
                criaUsuario();
            }

            return new Usuario(nome, idade, sexo);

        }
    }
}