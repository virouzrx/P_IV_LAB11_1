using System;
using System.Collections.Generic;

namespace Z11_UCR
{
    public class LoginFailureEventArgs : EventArgs
    {
        public List<LoginError> Errors { get; set; }
        public class LoginError
        {
            public LoginFields Field { get; set; }
            public string ErrorMessage { get; set; }
        }
    }


    public enum LoginFields
    {
        Login, 
        Password,
        All
    }
}