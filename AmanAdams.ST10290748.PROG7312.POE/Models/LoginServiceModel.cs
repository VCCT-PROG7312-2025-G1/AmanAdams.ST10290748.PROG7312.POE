
// Aman Adams
// ST10290748
// PROG7312
// POE PART 3

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class LoginServiceModel
    {
        private readonly Dictionary<string, (string Password, string Role)> _users = new()
        {
            { "admin", ("password123", "Admin") },
            { "employee", ("employee123", "Employee") }
        };

        public bool ValidateUser(string username, string password, out string role)
        {
            role = string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            if (_users.TryGetValue(username, out var userData) && userData.Password == password)
            {
                role = userData.Role;
                return true;
            }

            return false;
        }
    }
}


//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//



