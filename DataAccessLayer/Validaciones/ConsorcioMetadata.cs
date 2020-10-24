using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Modelos
{
    internal class ConsorcioMetadata
    {
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public int IdProvincia { get; set; }
        //public virtual Provincia Provincia { get; set; }

        [Required]
        [StringLength(50)]
        public string Ciudad { get; set; }

        [Required]
        [StringLength(50)]
        public string Calle { get; set; }

        [Required]
        public int Altura { get; set; }

        [Required]
        [Range(1, 28)]
        public int DiaVencimientoExpensas { get; set; }
    }
}