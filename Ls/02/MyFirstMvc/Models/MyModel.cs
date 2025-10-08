using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MyFirstMvc.Models;

public class MyModel
{
  [ValidarId]
  public int Id { get; set; }

  [Length(5, 10, ErrorMessage = "Largo de Name debe ser entre 5 y 10")]
  public string? Name { get; set; }

  [BindNever]
  public string? NoBindear { get; set; }


  class ValidarId : ValidationAttribute
  {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      var valor = (int?)value;

      if (valor < 100)
      {
        return new ValidationResult("El Id debe ser mayor que o igual que cien");
      }
      else
      {
        return ValidationResult.Success;
      }
    }
  }
}