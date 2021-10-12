using System.Collections.Generic;
using System;

namespace TrabalhoProgAvan2.models
{
    public class Recomendacao
    {
        List<Usuario> Usuarios { get; set; }

        public Animal gerarRecomendacao (Animal  animal) {

            /* 
                .....
                Como funciona:

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

    }
}