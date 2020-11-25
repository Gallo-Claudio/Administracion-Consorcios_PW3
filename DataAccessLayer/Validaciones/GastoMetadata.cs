using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Modelos
{
    internal class GastoMetadata
    {
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(200, ErrorMessage = "No puede ingresar un nombre tan largo")]
        public string Nombre { get; set; }

        [Display(Name = "Consorcio")]
        [Required(ErrorMessage = "Consorcio invalido")]
        public int IdConsorcio { get; set; }

        [Display(Name = "Tipo de Gasto")]
        [Required(ErrorMessage = "Seleccione un tipo de gasto")]
        public int IdTipoGasto { get; set; }

        [Display(Name = "Descripción")]
        [System.ComponentModel.DefaultValue("")]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaGasto { get; set; }

        [Display(Name = "Año")]
        [Required(ErrorMessage = "Ingrese un año de expensa.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;")]
        public int AnioExpensa { get; set; }

        [Display(Name = "Mes")]
        [Required(ErrorMessage = "Ingrese un mes de expensa")]
        public int MesExpensa { get; set; }

        [Display(Name = "Comprobante")]
        [Required(ErrorMessage = "Debe ingresar un comprobante")]
        public string ArchivoComprobante { get; set; }

        [Required(ErrorMessage = "Debe ingresar un monto")]
        public decimal Monto { get; set; }
    }
}