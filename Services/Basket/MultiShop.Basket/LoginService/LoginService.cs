namespace MultiShop.Basket.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public string GetUserId
        {
            get
            {
                // Check if HttpContext and User are not null before accessing Claims
                var user = _httpContextAccessor.HttpContext?.User;
                if (user == null)
                {
                    // Handle the case where the user is not authenticated
                    return null; // or throw an exception, or return a default value
                }

                // Attempt to find the 'sub' claim
                return user.Claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            }
        }
    }
}