using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Cryptography.KeyDerivation.PBKDF2;
[assembly: BenchmarkDotNet.Attributes.AspNetCoreBenchmark]
namespace PBKDF2Benchmark
{
    public class HashBenchmark
    {
        [Params(1000, 10000, 100000)]
        public int Iterations { get; set; }
        private static readonly byte[] _salt = GenerateSalt();
        private static readonly DefaultPbkdf2Provider _defaultProvider = new DefaultPbkdf2Provider();
        private static readonly ManagedPbkdf2Provider _managedProvider = new ManagedPbkdf2Provider();

        private static byte[] GenerateSalt()
        {
            using (var random = new RNGCryptoServiceProvider())
            {
                var result = new byte[64];
                random.GetBytes(result);
                return result;
            }
        }

        [Benchmark]
        public byte[] Rfc2898DeriveBytesSHA512()
        {
            byte[] _password = Encoding.UTF8.GetBytes("Hello World");
            var rfc = new Rfc2898DeriveBytes(_password, _salt, Iterations, HashAlgorithmName.SHA512);
            return rfc.GetBytes(64);
        }

        [Benchmark]
        public byte[] ManagedPbkdf2ProviderSHA512()
        {
            var key = _managedProvider.DeriveKey("Hello World", _salt, KeyDerivationPrf.HMACSHA512, Iterations, 512 / 8);
            return key;
        }

        [Benchmark]
        public byte[] DefaultPbkdf2ProviderSHA512()
        {
            var key = _defaultProvider.DeriveKey("Hello World", _salt, KeyDerivationPrf.HMACSHA512, Iterations, 512 / 8);
            return key;
        }
    }
}
