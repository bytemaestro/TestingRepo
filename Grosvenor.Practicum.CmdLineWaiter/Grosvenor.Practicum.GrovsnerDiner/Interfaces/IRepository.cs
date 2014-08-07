using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.GrovsnerDiner
{
    public interface IRepository<T> 
    {
        IList<T> GetAll();
 
    }
}
