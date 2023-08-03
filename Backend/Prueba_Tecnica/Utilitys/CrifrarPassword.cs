using System.Security.Cryptography;
using System.Text;
namespace Prueba_Tecnica.Utilitys
{
    public class CrifrarPassword
    {
        public string Cifrar_contrase_(string pass)
        {
            byte[] contraByte = Encoding.UTF8.GetBytes(pass);

            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(contraByte);

            string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashString;

        }
    }
}
