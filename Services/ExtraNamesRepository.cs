using System.Linq;
using Windy_City_Pizza.Data;
using Windy_City_Pizza.Interfaces;

namespace Windy_City_Pizza.Services
{
    public class ExtraNamesRepository : IExtraNamesRepository
    {
        private readonly Windy_City_PizzaContext _context;

        public ExtraNamesRepository(Windy_City_PizzaContext context)
        {
            _context = context;
        }

        public List<string> GetExtraNames()
        {
            //return _context.Pizza.Select(p => p.PizzaName!).ToList();
            
            return _context.Extras.Select(e => e.ExtraName!).ToList();
        }
    }
}
