using LoginMAUIBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginMAUIBlazor.Interfaces
{
    interface ILogin{
        Task<Login> Authenticate(UserMin userMin);

    }
}
