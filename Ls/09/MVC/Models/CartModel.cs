namespace MVC.Models;

public class CartModel
{
    public DateTime DateAndTime { get; } = DateTime.Now;
    public IList<ProductModel> Products { get; set; } = [];
}