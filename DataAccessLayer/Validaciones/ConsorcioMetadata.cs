using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Modelos
{
    internal class ConsorcioMetadata
    {
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(50, ErrorMessage = "No puede ingresar un nombre tan largo")]
        public string Nombre { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "Seleccione una provincia")]
        public int IdProvincia { get; set; }
        //public virtual Provincia Provincia { get; set; }

        [Required(ErrorMessage = "Ingrese una ciudad")]
        [StringLength(50, ErrorMessage = "No puede ingresar un nombre tan largo")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Ingrese una calle")]
        [StringLength(50, ErrorMessage = "No puede ingresar un nombre tan largo")]
        public string Calle { get; set; }

        [Required(ErrorMessage = "Debe ingresar una altura")]
        public int Altura { get; set; }

        [Display(Name = "Día vencimiento Expensas")]
        [Required(ErrorMessage = "Debe ingresar un día de vencimiento")]
        [Range(1, 28, ErrorMessage = "El vencimiento tiene que ser entre el 1º y el día 28")]
        public int DiaVencimientoExpensas { get; set; }
    }
}