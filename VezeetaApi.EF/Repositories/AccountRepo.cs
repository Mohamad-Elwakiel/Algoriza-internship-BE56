using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VezeetaApi.EF.Migrations;
using VezeetaAPI.Core.Constants;
using VezeetaAPI.Core.Models;
using VezeetaAPI.Core.Repositories;

namespace VezeetaApi.EF.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public AccountRepo(UserManager<ApplicationUser> userManager, 
            ApplicationDbContext context, SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;  
            _configuration = configuration; 
        }
        public async Task<IdentityResult> SignUpAsync(SignUpModel signUp, List<Specalization> specs)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                PhoneNumber = signUp.PhoneNumber,
                gender = (Gender)signUp.Gender,
                ImageUrl = signUp.ImageUrl,
                DOB = signUp.DOB,
                UserName = signUp.Email,
                accountType = signUp.accountType,


            };
            var doctor = new Doctors()
            { 
                UserId = user.Id,   
                Specalizations = specs,


            };
            _context.SaveChanges();
            return await _userManager.CreateAsync(user, signUp.Password);


        }
        public async Task<IdentityResult> SignUpAsync(SignUpModel signUp)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                PhoneNumber = signUp.PhoneNumber,
                gender = (Gender)signUp.Gender,
                ImageUrl = signUp.ImageUrl,
                DOB = signUp.DOB,
                UserName = signUp.Email,
                accountType = signUp.accountType,


            };
         

            return await _userManager.CreateAsync(user, signUp.Password);


        }
        public async Task<string> LoginAsync(SignInModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email,signInModel.Password,false,false);
            if(!result.Succeeded) 
            {
                return null;
            }
            var authClaims = new List<Claim>
            { 
                new Claim(ClaimTypes.Name, signInModel.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };
            var authSiginKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT : Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT : ValidIssuer"],
                audience: _configuration["JWT : ValidAudience"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSiginKey, SecurityAlgorithms.HmacSha256Signature)

                );
          return  new JwtSecurityTokenHandler().WriteToken(token);


        }
    }     
}
