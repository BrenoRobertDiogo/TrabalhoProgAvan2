namespace TrabalhoProgAvan2.models
{
    public abstract class Animal
    {
        public Taxonomia taxonomia;
        public double Nota { get; set; }
        public abstract void locomover();

    }
}