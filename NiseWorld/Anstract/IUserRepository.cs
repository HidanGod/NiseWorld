using NiseWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NiseWorld.Anstract
{
    interface IUserRepository
    {
        void SaveUser(User user);
    }
}
