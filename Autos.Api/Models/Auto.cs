namespace Autos.Api.Models
{
    public class Auto
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public short Anio { get; set; }
        public string TipoDeAuto { get; set; }
        public byte CantidadDeAsientos { get; set; }
        public string Color { get; set; }
        public bool TieneAireAcondicionado { get; set; }
        public string TipoCombustible { get; set; }
    }
}
