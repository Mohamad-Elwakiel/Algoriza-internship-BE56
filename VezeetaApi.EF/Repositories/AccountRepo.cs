using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaApi.EF.Migrations;
using VezeetaAPI.Core.Models;
using VezeetaAPI.Core.Repositories;

namespace VezeetaApi.EF.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public AccountRepo(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;

        }
        public async Task<IdentityResult> SignUpAsync(SignUpModel signUp)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                PhoneNumber = signUp.PhoneNumber,
                gender = (ApplicationUser.genderEnum)signUp.Gender,
                ImageUrl = signUp.ImageUrl,
                DOB = signUp.DOB,
                UserName = signUp.Email,
                accountType = signUp.accountType,

            };
            return await _userManager.CreateAsync(user, signUp.Password);


        }
        public async Task<string> LoginAsync(SignInModel signInModel)
        {

        }
    }     
}
