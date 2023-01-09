using Etrade.Core;
using Etrade.DTO;
using Etrade.Entity.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Repos.Abstracts
{
    public interface IUsersRep : IBaseRepository<Users>
    {
        Users CreateUser(Users u);
        UserDTO Login(string username, string password);
    }
}

