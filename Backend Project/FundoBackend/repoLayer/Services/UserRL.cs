using commonLayer.model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using repoLayer.Context;
using repoLayer.Entity;
using repoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace repoLayer.service
{
    public class UserRL : IUserRL
    {
        Fundo fundoContext;
        //private readonly string key;
        //public  string _secret;
        //public  string _expDate;

        private readonly IConfiguration config;

        public UserRL(Fundo fundooContext, IConfiguration config)
        {
            this.fundoContext = fundooContext;
            this.config = config;
        }


        public string JwtMethod(string email, long id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.config[("Jwt:key")]));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                new Claim[]
                {
                        new Claim(ClaimTypes.Email, email),
                        new Claim("id", id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                tokenKey, SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }

        
    public UserEntity Registration(UserRegistration user)
        {
            try
            {
                UserEntity userEntity = new UserEntity();
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;    
                userEntity.Email = user.Email;
                userEntity.Password = user.Password;
                fundoContext.UsersEntity.Add(userEntity);
                int result= fundoContext.SaveChanges();
                if (result > 0)
                {
                    return userEntity;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Login(UserLogin userlogin)
        {
            try
            {
                var login = fundoContext.UsersEntity.SingleOrDefault(x => x.Email == userlogin.Email && x.Password == userlogin.Password);

                if (login != null)
                {
                    var token = JwtMethod(login.Email, login.UserId);
                    return token;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string ForgotPassword(string email)
        {
            try
            {
                var emailCheck = fundoContext.UsersEntity.FirstOrDefault(x => x.Email == email);
                if (emailCheck != null)
                {
                    var token = JwtMethod(emailCheck.Email, emailCheck.UserId);
                    new MsmqModel().MsmqSend(token);
                    return token;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ResetPassword(string email, string password, string confirmpassword)
        {
            try
            {
                if (password.Equals(confirmpassword))
                {
                    UserEntity user = fundoContext.UsersEntity.Where(e => e.Email == email).FirstOrDefault();
                    user.Password = confirmpassword;
                    fundoContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
