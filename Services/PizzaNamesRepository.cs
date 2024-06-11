using System.Linq;
using Windy_City_Pizza.Data;
using Windy_City_Pizza.Interfaces;

namespace Windy_City_Pizza.Services
{
    public class PizzaNamesRepository : IPizzaNamesRepository
    {
        private readonly Windy_City_PizzaContext _context;

        public PizzaNamesRepository(Windy_City_PizzaContext context)
        {
            _context = context;
        }

        public List<string> GetPizzaNames()
        {
            return _context.Pizza.Select(p => p.PizzaName!).ToList();
        }

        public string GetPizzaPrices(string pizzaName)
        {
            decimal pizzaPriceSmall = _context.Pizza.Select(p => p.PriceSmall).Sum();
            return "";
        }

    }
}
