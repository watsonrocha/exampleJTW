using CoreJwtExample.Helpers;
using CoreJwtExample.IService;
using CoreJwtExample.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreJwtExample.Service
{
    public class UserInfoService : IUserinfoService
    {
        private List<UserInfo> _user = new List<UserInfo>
        {
            new UserInfo{ UserIndoId= Guid.NewGuid(), Fullname= "Watson Rocha",Username= "Watson",Password= "Test"}
        };

        private readonly AppSettings _appsettings;

        public UserInfoService(IOptions<AppSettings> appSettings)
        {
            _appsettings = appSettings.Value;

        }
        public UserInfo Authenticate(string username, string password)
        {
            var user = _user.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, user.UserIndoId.ToString())
               }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }
        public IEnumerable<UserInfo> GetAll()
        {
            return _user;
        }



    }
}

