using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using Task.Application.UserCases.Login;
using Task.Domain.ApplicationUser;
using Task.Domain.Common;
using Task.Presistence.IRepositories;
using Microsoft.Extensions.Options;
using Task.Presistence.Core;
using System.Linq;
using Task.Domain.Employees;
using IdentityModel;

namespace Task.Presistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JWTSettings _jwtsettings;
        private readonly SignInManager<ApplicationUser> signInManager;

        public EmployeeRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IOptions<JWTSettings> jwtsettings, SignInManager<ApplicationUser> signInManager)
        {
            this.context = context;
            this.userManager = userManager;
            _jwtsettings = jwtsettings.Value;
            this.signInManager = signInManager;
        }

        public async Task<long> Create(Employee entity)
        {

            context.Employees.Add(entity);
            context.SaveChanges();
            var res = entity.Id > 0 ? entity.Id : 0;
            return res;
        }
        public async Task<bool> Update(Employee entity)
        {
            context.Employees.Update(entity);
            context.SaveChanges();
            return true;
        }

        public async Task<bool> Delete(long id, string userId)
        {
            var res = false;
            var data = context.Employees.FirstOrDefault(a => a.Id == id);
            if (data != null)
            {
                data.IsDeleted = true;
                data.DeletedBy = userId;
                context.SaveChanges();
                res = true;
            }
            return res;
        }

        public async Task<List<Employee>> GetAll()
        {
            var res = context.Employees.ToList();
            return res;
        }

        public async Task<Employee> GetById(long id)
        {
            var res = new Employee();
            var data = context.Employees.FirstOrDefault(a => a.Id == id);
            if (data != null)
            {
                res = data;
            }
            return res;
        }

        public async Task<AccessTokenResponse> GetAccessToken(LoginModel model)
        {
            var accessTokenResponse = new AccessTokenResponse();

            var user = await userManager.FindByNameAsync(model.UserName);



            //if (user is null || !await userManager.CheckPasswordAsync(user, model.Password))
            if (user is null || !(user.PasswordHash == model.Password))
            {
                accessTokenResponse.Message = "Email or Password is incorrect!";
                return accessTokenResponse;
            }

            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await userManager.GetRolesAsync(user);

            accessTokenResponse.AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            accessTokenResponse.Email = user.Email;
            accessTokenResponse.UserName = user.UserName;
            accessTokenResponse.Scope = "Employee.read";
            accessTokenResponse.ExpiresOn = jwtSecurityToken.ValidTo;
            accessTokenResponse.Roles = rolesList.ToList();
            accessTokenResponse.PhoneNumber = user.PhoneNumber;
            accessTokenResponse.UserId = user.Id;

            return accessTokenResponse;
        }

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim(JwtClaimTypes.Role, role));

            var claims = new[]
            {
                new Claim(JwtClaimTypes.Subject, user.UserName),
                new Claim(JwtClaimTypes.JwtId, Guid.NewGuid().ToString()),
                new Claim(JwtClaimTypes.Email, user.Email),
                new Claim(JwtClaimTypes.Id, user.Id.ToString()),
                new Claim(JwtClaimTypes.PhoneNumber, user.PhoneNumber),
                new Claim(JwtClaimTypes.Name, user.UserName),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtsettings.SecretKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtsettings.Issuer,
                audience: _jwtsettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtsettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
