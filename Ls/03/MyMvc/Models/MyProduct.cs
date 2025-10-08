using System.ComponentModel.DataAnnotations;

public class MyProduct
{
  [Range(5, 10)]
  public int Id { get; set; }

  [Length(5, 10)]
  public string? Name { get; set; }

  public double Price { get; set; }
  
  public double Tax { get; set; }
}