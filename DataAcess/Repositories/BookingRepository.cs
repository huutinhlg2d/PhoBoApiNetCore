using BussinessObject.PhoBo.Data;
using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(PhoBoContext phoBoContext) : base(phoBoContext)
        {
        }

        public IEnumerable<Booking> findAllBookingByCondition(Expression<Func<Booking, bool>> expression)
        {
            return PhoBoContext.Booking.Include(booking => booking.Photographer)
                .Include(booking => booking.Customer)
                .Include(booking => booking.Concept)
                .Where(expression).AsNoTracking();
        }
    }
}
