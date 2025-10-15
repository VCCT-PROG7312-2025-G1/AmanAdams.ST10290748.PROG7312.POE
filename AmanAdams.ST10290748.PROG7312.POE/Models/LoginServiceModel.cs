// Aman Adams
// ST10290748
// PROG7312
// POE PART 2

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class LoginServiceModel
    {
        private readonly Dictionary<string, string> _users = new()
        {
            { "admin", "password123" },
            { "employee", "employee123" }
        };

        public bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            return _users.TryGetValue(username, out string storedPassword) && storedPassword == password;
        }
    }
}
