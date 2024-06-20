using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookings.Entities.Interfaces
{
    public interface IPresenter<T>
    {
        T Content { get; }
    }
}
