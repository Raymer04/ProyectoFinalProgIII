using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AgenciaDeViaje.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public int tipoUsuario { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Apellido")]
        public string apellido { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime fechaDeNacimiento { get; set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string password { get; set; }
        public List<Boleto> boletos { get; set; }

       

    }

    #region Models
    public class CambiarClave
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class IniciarSesion
    {
        [Required]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
#endregion
}