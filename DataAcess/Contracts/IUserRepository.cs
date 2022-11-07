using BussinessObject.PhoBo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User Login(string email, string password);

        User FindByEmail(string email);
    }
}
