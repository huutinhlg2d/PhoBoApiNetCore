using BussinessObject.PhoBo.Data;
using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BookingConceptImageRepository : RepositoryBase<BookingConceptImage>, IBookingConceptImageRepository
    {
        public BookingConceptImageRepository(PhoBoContext phoBoContext) : base(phoBoContext)
        {
        }
    }
}
