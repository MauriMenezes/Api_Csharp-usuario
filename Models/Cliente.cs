using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace user.Models
{
  [Table("cliente")]
  public class Cliente
  {
    [Key]
    public long Id { get; set; }

    [Required(ErrorMessage = "Informe o CPF ")]
    [StringLength(14)]
    public String Cpf { get; set; }

    [Required(ErrorMessage = "Informe o Nome ")]
    public String Nome { get; set; }

    [Required(ErrorMessage = "Informe a Senha ")]
    public String Senha { get; set; }

    [Required(ErrorMessage = "Informe o Email ")]
    public String Email { get; set; }
  }
}
