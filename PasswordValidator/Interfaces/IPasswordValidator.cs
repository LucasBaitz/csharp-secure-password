using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidator.Services.Interfaces
{
    public interface IPasswordValidator
    {
        Task<bool> Validate(string password);
    }
}
