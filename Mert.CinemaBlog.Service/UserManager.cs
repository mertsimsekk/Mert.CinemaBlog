using Mert.CinemaBlog.Data.Repositories;
using Mert.CinemaBlog.Model.UserDtos;
using Mert.CinemaBlog.Service.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mert.CinemaBlog.Service
{
    public class UserManager
    {
        private readonly IUnitOfWork unitOfWork;

        public UserManager()
        {
            unitOfWork = new UnitOfWork();
        }
        public UserDto LoginCheck(string username, string password)
        {
            return unitOfWork.UserRepository.Get(u => u.Username == username && u.Password == password && !u.IsDeleted).ToDto();
        }
    }
}
