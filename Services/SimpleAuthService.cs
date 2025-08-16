using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Portfolio.Services
{
    public class SimpleAuthService
    {
        private readonly IConfiguration _configuration;

        public SimpleAuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool ValidateAdmin(string username, string password)
        {
            var configUsername = _configuration["AdminCredentials:Username"] ?? "admin";
            var configPasswordHash = _configuration["AdminCredentials:PasswordHash"];

            // If no hash is configured, use default admin/admin123 for first setup
            if (string.IsNullOrEmpty(configPasswordHash))
            {
                configPasswordHash = HashPassword("admin123");
            }

            if (username != configUsername)
                return false;

            var inputPasswordHash = HashPassword(password);
            return inputPasswordHash == configPasswordHash;
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + "Portfolio_Admin_Salt_2024";
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Helper method to generate hash for configuration
        public string GeneratePasswordHash(string password)
        {
            return HashPassword(password);
        }
    }
}