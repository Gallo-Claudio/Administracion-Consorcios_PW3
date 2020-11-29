using DataAccessLayer.Validaciones;
using System;
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
        [DataType(DataType.Date, ErrorMessage = "Solamente fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FechaGasto { get; set; }

        [Display(Name = "Año")]
        [Required(ErrorMessage = "Ingrese un año de expensa.")]
        [RangeYearToCurrent(1995, ErrorMessage = "El año es invalido")]
        public int AnioExpensa { get; set; }

        [Display(Name = "Mes")]
        [Required(ErrorMessage = "Ingrese un mes de expensa")]
        [Range(1, 12, ErrorMessage = "El mes debe estar entre 1 y 12")]
        public int MesExpensa { get; set; }

        [Display(Name = "Comprobante")]
        [Required(ErrorMessage = "Debe ingresar un comprobante")]
        public string ArchivoComprobante { get; set; }

        [Required(ErrorMessage = "Debe ingresar un monto")]
        public decimal Monto { get; set; }
    }
}