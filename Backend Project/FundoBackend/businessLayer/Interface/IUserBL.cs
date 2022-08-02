using commonLayer.model;
using repoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace businessLayer.Interfaces
{
    public interface IUserBL
{
    public UserEntity Registration(UserRegistration user);
    public string Login(UserLogin userlogin);

    public string ForgotPassword(string email);

    public bool ResetPassword(string email, string password, string confirmpassword);


    }
}
