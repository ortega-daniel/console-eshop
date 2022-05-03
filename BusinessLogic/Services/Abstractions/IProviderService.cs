using DataInterface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Abstractions
{
    public interface IProviderService
    {
        List<Provider> Get();
    }
}
