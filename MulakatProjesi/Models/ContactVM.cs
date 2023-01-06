using System.ComponentModel.DataAnnotations;

namespace MulakatProjesi.Models;

public class ContactVM
{
    // zorunlu, max 128 karakter
    [Required, MaxLength(128)]
    public string Name { get; set; }

    // zorunlu, max 10 min 10 karakter, geçerli bir telefon numarası olmak zorundadır. örn: 5555555555
    [Required, MaxLength(10), MinLength(10)]
    [RegularExpression("^[0-9]{10}$")]
    public string PhoneNumber { get; set; }

    // zorunlu, geçerli bir email adresi olması gerekir
    [Required, EmailAddress]
    public string Email { get; set; }

    // zorunlu, max 256 karakter
    [Required, MaxLength(256)]
    public string Message { get; set; }
}