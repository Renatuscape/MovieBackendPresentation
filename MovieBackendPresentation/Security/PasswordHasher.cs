using System.Security.Cryptography;
using System.Text;

namespace MovieBackendPresentation.Security;

public class PasswordHasher {
	public static string HashPassword(string password) {
		using (var sha256 = SHA256.Create()) {
			var passwordBytes = Encoding.UTF8.GetBytes(password);
			var hashBytes     = sha256.ComputeHash(passwordBytes);
			return Convert.ToBase64String(hashBytes);
		}
	}

	public static string GenerateSalt() {
		byte[] salt = new byte[128 / 8];
		using (var rng = RandomNumberGenerator.Create()) {
			rng.GetBytes(salt);
		}
		return Convert.ToBase64String(salt);
	}
}