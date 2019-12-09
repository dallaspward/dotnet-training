using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Client.Validations;

namespace PizzaBox.Client.Models
{
  public class Pizza
  {
    [Required()]
    public string Crust { get; set; }

    [Required()]
    public string Size { get; set; }
    [Range(1,10)]
    public int Quantity { get; set; }

    //[DataType(DataType.Text)]
    [NameAttribute(ErrorMessage = "the name must be letters only")]
    [StringLength(50)]
    public string Name { get; set; }
    public List<string> Crusts { get; set; }
    public List<string> Sizes { get; set; }

    public Pizza()
    {
      Crusts = new List<string> {"thin", "new york", "deep dish"};
      Sizes = new List<string> {"small", "medium", "large"};
    }
  }
}