using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaAPI.Core.Models;

namespace VezeetaAPI.Core.Repositories
{
    public interface IAccountRepo
    {
         Task<IdentityResult> SignUpAsync(SignUpModel signUp);

        Task<string> LoginAsync(SignInModel signInModel)


    }
}
