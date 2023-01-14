namespace hangfire.api.Models
{
    public interface ITipoCron { };
    public class Diario : ITipoCron
    {
        public Diario(int hora, int minuto)
        {
            Hora = hora;
            Minuto = minuto;
        }

        public int Hora { get; set; }
        public int Minuto { get; set; }
    }
}
