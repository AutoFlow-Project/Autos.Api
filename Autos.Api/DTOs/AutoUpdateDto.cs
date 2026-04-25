using System.ComponentModel.DataAnnotations;

namespace Autos.Api.DTOs
{
    public class AutoUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required]
        [StringLength(50)]
        public string Modelo { get; set; }

        [Required]
        public short Anio { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoDeAuto { get; set; }

        [Required]
        [Range(1, 8)]
        public byte CantidadDeAsientos { get; set; }

        [Required]
        [StringLength(30)]
        public string Color { get; set; }

        public bool TieneAireAcondicionado { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^(Gasolina|Diésel|GNV|GLP|Eléctrico|Híbrido)$")]
        public string TipoCombustible { get; set; }
    }
}
