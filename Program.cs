using TrabalhoProgAvan2.models;
namespace TrabalhoProgAvan2
{
    class Program
    {
        static void Main(string[] args)
        {
            Controlador controlador = new Controlador();
            Recomendacao recomendacao= new Recomendacao();
            controlador.Iniciar(recomendacao);
        }
    }
}
