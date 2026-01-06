namespace PontosTuristicos.Api.Models
{
    using System.ComponentModel.DataAnnotations;
    public class PontoTuristico
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Descricao { get; set; } =string.Empty;

        [Required]
        public string Referencia { get; set; } = string.Empty;

        [Required]
        public string Cidade { get; set; } = string.Empty;

        [Required]
        [MaxLength(2)]
        public string Estado { get; set; } = string.Empty;

        public DateTime DataInclusao { get; set; } = DateTime.Now;
    }
}
