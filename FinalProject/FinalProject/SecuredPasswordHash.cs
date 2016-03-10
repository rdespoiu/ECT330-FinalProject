using System;
using System.Text;
using System.Security.Cryptography;

namespace FinalProject
{
    public class SecuredPasswordHash
    {
        public static String GenerateHash(String password)
        {
            //WARNING: This code does not reflect best practice.  It is a simplistic implementation designed to introduce the concept of hashing.
            password = "$$$$$" + password + "$#!%^";
            var pwdBytes = Encoding.UTF8.GetBytes(password);

            SHA256 hashAlg = new SHA256Managed();
            hashAlg.Initialize();
            var hashedBytes = hashAlg.ComputeHash(pwdBytes);
            var hash = Convert.ToBase64String(hashedBytes);
            return hash;
        }
    }
}