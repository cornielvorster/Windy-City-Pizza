using System.ComponentModel.DataAnnotations;

namespace Windy_City_Pizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        public string? PizzaName { get; set; }
        public required decimal PriceSmall{ get; set; }
        public required decimal PriceMeduim { get; set; }
        public required decimal PriceLarge{ get; set; }
        
    }
}
