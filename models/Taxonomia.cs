namespace TrabalhoProgAvan2.models
{
    public class Taxonomia
    {
        public string dominio { get; set; }
        public string reino { get; set; }
        public string filo { get; set; }
        public string classe { get; set; }
        public string ordem { get; set; }
        public string familia { get; set; }
        public string genero { get; set; }
        public string especie { get; set; }

        public Taxonomia(string dominio, string reino, string filo, string classe, string ordem, string familia, string genero, string especie) {
            this.dominio = dominio;
            this.reino = reino;
            this.filo = filo;
            this.classe = classe;
            this.ordem = ordem;
            this.familia = familia;
            this.genero = genero;
            this.especie = especie;
        }
    }
}