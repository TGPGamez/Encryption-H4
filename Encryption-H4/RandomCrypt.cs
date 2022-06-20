using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEncrypt
{
    public class RandomCrypt
    {
        public static void RNGCrypto()
        {
            Stopwatch watch = new Stopwatch();
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            Console.WriteLine("RNGCrypto:");
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[1000];
                
                watch.Start();
                for (int i = 0; i < data.Length; i++)
                {
                    rng.GetBytes(data);
                    int value = BitConverter.ToInt32(data, 0);
                    Console.WriteLine(value);
                }
                watch.Stop();
                Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}");
            }
        }

        public static void RandomCrypto()
        {
            Stopwatch watch = new Stopwatch();
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            Console.WriteLine("Random:");
            watch.Start();
            int[] randData = new int[1000];

            for (int i = 0; i < randData.Length; i++)
            {
                for (int j = 0; j < randData.Length; j++)
                {
                    randData[j] = rand.Next(-9, 10);
                }

                string value = randData[0].ToString() + randData[1].ToString() + randData[2].ToString() + randData[3].ToString();

                Console.WriteLine(value);
            }
            watch.Stop();
            Console.WriteLine($"Elapsed time: {watch.ElapsedMilliseconds}");
        }
    }
}
