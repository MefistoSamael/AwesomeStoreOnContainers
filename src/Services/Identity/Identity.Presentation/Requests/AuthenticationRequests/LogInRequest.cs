﻿namespace Identity.Presentation.Requests.AuthenticationRequests
{
    public class LogInRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}