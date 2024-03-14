using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Models.Helpers
{
  
    public class PasswordHasher
    { // Générateur de nombres aléatoires sécurisé.
        private static readonly RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

        // Taille du sel en octets.
        private static readonly int SaltSize = 16;

        // Taille du hachage en octets.
        private static readonly int HashSize = 20;

        // Nombre d'itérations pour la dérivation de clé.
        private static readonly int Iterations = 10000;

        // Méthode pour hacher un mot de passe.
        public static string HashPassword(string password)
        {
            // Génération d'un sel aléatoire.
            byte[] salt;
            rng.GetBytes(salt = new byte[SaltSize]);

            // Création d'une instance de Rfc2898DeriveBytes pour la dérivation de clé PBKDF2.
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);

            // Génération du hachage du mot de passe.
            var hash = key.GetBytes(HashSize);

            // Concaténation du sel et du hachage.
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Encodage du hachage en base64 pour stockage.
            var base64Hash = Convert.ToBase64String(hashBytes);

            return base64Hash;
        }

        // Méthode pour vérifier un mot de passe par rapport à un hachage donné.
        public static bool VerifyPassword(string password, string base64Hash)
        {
            // Décodage du hachage en base64 pour récupérer le sel et le hachage.
            var hashBytes = Convert.FromBase64String(base64Hash);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Recréation de la clé dérivée.
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);

            // Génération du hachage du mot de passe à vérifier.
            byte[] hash = key.GetBytes(HashSize);

            // Comparaison des hachages.
            for (var i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                    return false;
            }

            return true; // Les hachages correspondent, le mot de passe est valide.
        }
    }


}

