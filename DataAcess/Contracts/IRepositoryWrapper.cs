using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IRepositoryWrapper
    {
        public IBookingRepository Booking { get; }
        public IBookingConceptConfigRepository BookingConceptConfig { get; }
        public IBookingConceptImageRepository BookingConceptImage { get; }
        public IUserRepository User { get; }
        public ICustomerRepository Customer { get; }
        public IPhotographerRepository Photographer { get; }
        public IConceptRepository Concept { get; }

        int Save();
        Task<int> SaveAsync();
    }
}
