using Microsoft.AspNetCore.Components;
using SimpleLoginApp.Models;

namespace SimpleLoginApp.Components.Pages
{
    public class LoginBase : ComponentBase
    {
        protected LoginModel loginModel = new LoginModel();
        protected string message = string.Empty;
        protected string messageCssClass = string.Empty;

        protected void HandleLogin()
        {
            if (loginModel.Username.ToLower() == "admin" && loginModel.Password == "123456")
            {
                message = "Login successful!";
                messageCssClass = "alert-success";
            }
            else
            {
                message = "Invalid credentials. Try: admin / 123456";
                messageCssClass = "alert-danger";
            }
        }

        protected void HandleInvalidSubmit()
        {
            message = string.Empty;
        }
    }
}