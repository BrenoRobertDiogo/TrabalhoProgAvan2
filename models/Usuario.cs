using System.Collections.Generic;
using System;

namespace TrabalhoProgAvan2.models
{
    public class Usuario
    {
        public string Nome { get; protected set; }

        public int Idade {  get; protected set; }

        public char Sexo {  get; protected set; }

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
            this.Atual = animal;
            this.AnimaisVisitados.Add(animal);

            // animal.locomover();
            Console.WriteLine($"Testezinho {animal.taxonomia.especie}");
            // this.mostraAnimaisVisitados();
            // this.mostraTaxonomiaAnimal();


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

        public void mostraAnimaisVisitados()
        {
            for (int index = 0; index < this.AnimaisVisitados.Count; index++)
            {
                Console.WriteLine($"{index+1}º | {this.AnimaisVisitados[index].taxonomia.especie}");

            }
        }

        public void mostraTaxonomiaAnimal()
        {
            Console.Clear();
            Console.WriteLine(
                "======================================\n" +
                "====             DETALHES         ====\n" +
                "======================================"
            );
            Console.WriteLine(
                $"dominio: {this.Atual.taxonomia.dominio} "+
                $"\nreino: {this.Atual.taxonomia.reino} "+
                $"\nfilo: {this.Atual.taxonomia.filo} "+
                $"\nclasse: {this.Atual.taxonomia.classe} "+
                $"\nordem: {this.Atual.taxonomia.ordem} "+
                $"\nfamilia: {this.Atual.taxonomia.familia} "+
                $"\ngenero: {this.Atual.taxonomia.genero} "+
                $"\nespecie: {this.Atual.taxonomia.especie} "
            );
            Controlador.digitarContinuar();
            
        }
    }
}