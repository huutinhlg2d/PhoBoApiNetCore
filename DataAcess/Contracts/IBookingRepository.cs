using BussinessObject.PhoBo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IBookingRepository : IRepositoryBase<Booking>
    {
        IEnumerable<Booking> findAllBookingByCondition(Expression<Func<Booking, bool>> expression);
    }
}
