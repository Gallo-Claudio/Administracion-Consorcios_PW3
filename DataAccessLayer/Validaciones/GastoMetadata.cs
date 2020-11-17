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

        [Required(ErrorMessage = "Seleccione un tipo de gasto")]
        public int IdTipoGasto { get; set; }

        [System.ComponentModel.DefaultValue("")]
        public string Descripcion { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaGasto { get; set; }

        [Required(ErrorMessage = "Debe ingresar un anio de expensa")]
        public int AnioExpensa { get; set; }

        [Required(ErrorMessage = "Debe ingresar un mes de expensa")]
        public int MesExpensa { get; set; }

        [Required(ErrorMessage = "Debe ingresar un comprobante")]
        public string ArchivoComprobante { get; set; }

        [Required(ErrorMessage = "Debe ingresar un monto")]
        public decimal Monto { get; set; }
    }
}
