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
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(PhoBoContext phoBoContext) : base(phoBoContext)
        {
        }

        public User Login(string email, string password)
        {
            return PhoBoContext.User.SingleOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));
        }

        public User FindByEmail(string email)
        {
            return PhoBoContext.User.SingleOrDefault(u => u.Email.Equals(email));
        }
    }
}
