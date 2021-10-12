namespace TrabalhoProgAvan2.models
{
    public class Repteis : Animal, IPorOvo
    {
        public Repteis(string dominio, string reino, string filo, string classe, string ordem, string familia, string genero, string especie) {
            taxonomia = new Taxonomia(dominio, reino, filo, classe, ordem, familia, genero, especie);
        }
    }
}