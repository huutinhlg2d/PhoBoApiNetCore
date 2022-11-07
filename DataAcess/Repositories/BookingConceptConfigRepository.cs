using BussinessObject.PhoBo.Data;
using BussinessObject.PhoBo.Models;
using DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BookingConceptConfigRepository : RepositoryBase<BookingConceptConfig>, IBookingConceptConfigRepository
    {
        public BookingConceptConfigRepository(PhoBoContext phoBoContext) : base(phoBoContext)
        {
        }

        public IEnumerable<BookingConceptConfig> FindByPhotographerId(int id)
        {
            return PhoBoContext.BookingConceptConfig
                .Include(bcc => bcc.Concept)
                .Where(bcc => bcc.PhotographerId.Equals(id));
        }

        public void LoadConcept(BookingConceptConfig config)
        {
            PhoBoContext.Entry(config).Reference(c => c.Concept).Load();
        }
    }
}
