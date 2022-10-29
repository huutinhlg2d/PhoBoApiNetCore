using DataAccess.Contracts;
using BussinessObject.PhoBo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly PhoBoContext _context;
        private readonly IBookingRepository _bookingRepository;
        private readonly IBookingConceptConfigRepository _bookingConceptConfigRepository;
        private readonly IBookingConceptImageRepository _bookingConceptImageRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPhotographerRepository _photographerRepository;
        private readonly IConceptRepository _conceptRepository;

        public RepositoryWrapper(PhoBoContext context)
        {
            _context = context;
            _bookingConceptConfigRepository = new BookingConceptConfigRepository(context);
            _bookingConceptImageRepository = new BookingConceptImageRepository(context);
            _bookingRepository = new BookingRepository(context);
            _userRepository = new UserRepository(context);
            _customerRepository = new CustomerRepository(context);
            _photographerRepository = new PhotographerRepository(context);
            _conceptRepository = new ConceptRepository(context);
        }

        public IBookingRepository Booking => _bookingRepository;

        public IBookingConceptConfigRepository BookingConceptConfig=> _bookingConceptConfigRepository;

        public IBookingConceptImageRepository BookingConceptImage => _bookingConceptImageRepository;

        public IUserRepository User => _userRepository;

        public ICustomerRepository Customer => _customerRepository;

        public IPhotographerRepository Photographer => _photographerRepository;

        public IConceptRepository Concept => _conceptRepository;

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
