using businessLayer.Interfaces;
using commonLayer.model;
using repoLayer.Entity;
using repoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace businessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public UserEntity Registration(UserRegistration user)
        {
            try
            {
                return userRL.Registration(user);
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
                return userRL.Login(userlogin);
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
                return userRL.ForgotPassword(email);
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
                return this.userRL.ResetPassword(password, confirmpassword, email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
