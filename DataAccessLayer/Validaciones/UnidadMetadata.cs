using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Modelos
{
    internal class UnidadMetadata
    {
        [Display(Name = "Nombre de la unidad")]
        [Required(ErrorMessage = "Debe ingresar un nombre a la unidad")]
        [StringLength(50, ErrorMessage = "No puede ingresar un nombre de unidad tan largo")]
        public string Nombre { get; set; }

        [Display(Name = "Nombre del propietario")]
        [Required(ErrorMessage = "Ingrese el nombre del propietario")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 cararcteres")]
        public string NombrePropietario { get; set; }

        [Display(Name = "Apellido del propietario")]
        [Required(ErrorMessage = "Ingrese el apellido del propietario")]
        [StringLength(50, ErrorMessage = "El apellido no puede superar los 50 cararcteres")]
        public string ApellidoPropietario { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "El mail es obligatorio")]
        [StringLength(100, ErrorMessage = "El email no puede ser tan largo")]
        [EmailAddress(ErrorMessage = "El formato del Email no es correcto")]
        public string EmailPropietario { get; set; }
    }
}