using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Z11_UCR
{
    public class User
    {
        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public string Login { get; private set; }
        private string Password {get; set;}

        public bool CheckLogin(string login, SecureString password)
        {
            //var test = password.ToString();
            //string test2 = password.

            //return (Login == login && Password == password.ToString());

            var pwd = default(string);
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                pwd = Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }

            return (Login == login && Password == pwd);
        }
    }
}