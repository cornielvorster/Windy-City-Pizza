using System.ComponentModel.DataAnnotations;

namespace Windy_City_Pizza.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required string Pizza { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public required string PizzaSize { get; set; }
        public String? Extras { get; set; }
        public decimal TotalPrice { get; set; }
        public Boolean isCompleted { get; set; }

    }
}
