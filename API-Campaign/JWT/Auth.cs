using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UpSchool_WebApi.DAL;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace APICampaign.JWT
{
	public class Auth : IJwtAuth
    {
        private readonly string key;

        public Auth(string key)
        {
            this.key = key;
        }

    
        public string Authentication(string username, string password)
        {
            using (var context = new Context())
            {

                var user = context.UserCredentials.FirstOrDefault(x => x.UserName == username);
                if (user == null || !user.Password.Equals(password))
                {

                    return "Invalid username or password";
                }
            }
            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}

//Create Security Handler – “token handler”.
//Once Token Handler is created, we will encrypt the key into bytes.
//Now we will create a token descriptor.
//Subject – New Claim identity
//Expired – When it will be expired.
//SigningCredentical – Private key + Algorithm
//Now we will create a token using the “create token” method of the token handler.
//Return token from Authentication method.