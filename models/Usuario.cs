using System.Collections.Generic;

namespace TrabalhoProgAvan2.models
{
    public class Usuario
    {
        public string Nome { get; set; }

        public int Idade { get; set; }

        public char Sexo { get; set; }

        public List<Animal> AnimaisVisitados { get; set; }

        public Animal Atual { get; set; }


        public Usuario(string nome, int idade, char sexo)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Sexo = sexo;
            this.AnimaisVisitados = new List<Animal>();
        }

        public void visitarAnimal(Animal animal)
        {

        }

        public void terminarVisita()
        {
            /* 
            Depois que terminar de visitar o atual ele vai ser ativado 
            Pegar animal atual
            Colocar animalAtual em visitados
            Pedir recomendação
            */
        }
    }
}