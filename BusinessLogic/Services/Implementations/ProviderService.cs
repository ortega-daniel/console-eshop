using BusinessLogic.Services.Abstractions;
using DataInterface;
using DataInterface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementations
{
    public class ProviderService : IProviderService
    {
        private readonly EshopContext _context;

        public ProviderService(EshopContext context)
        {
            _context = context;
        }

        public List<Provider> Get() 
        { 
            var result= _context.Providers.ToList();

            return result;
        }
    }
}
