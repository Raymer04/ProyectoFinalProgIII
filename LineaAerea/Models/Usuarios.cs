using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LineaAerea.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        #region Models
        public class CambiarClave
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña antigua")]
            public string ContraseñaAntigua { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña nueva")]
            public string ContraseñaNueva { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirme la contraseña nueva")]
            [Compare("Contraseña nueva", ErrorMessage = "La contraseña nueva y la de confirmación no coinciden.")]
            public string ConfirmarContraseña { get; set; }
        }

        public class IniciarSesion
        {
            [Required]
            [Display(Name = "Usuario")]
            public string Usuario { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [Display(Name = "Recordarme?")]
            public bool Recordarme { get; set; }
        }
        #endregion
    }
}