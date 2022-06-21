

using SimpleHashing;
using System.Diagnostics;
using System.Text;

while (true)
{
    Console.Clear();
    Console.WriteLine("SimpleHashing");
    Console.WriteLine("Write the text you want to hash:");
    ChooseHashOrHmac(Console.ReadLine());
}


void ChooseHashOrHmac(string text)
{
    Console.WriteLine("1. Hash");
    Console.WriteLine("2. HMac");

    string userInput = Console.ReadLine();
    switch (userInput)
    {
        case "1":
            Console.Clear();
            HashText(text);
            break;
        case "2":
            Console.Clear();
            HMacText(text);
            break;
        default:
            Console.WriteLine("Wrong input");
            break;
    }
}


void HashText(string text)
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    byte[] hashed = ChooseHash(text);
    stopWatch.Stop();
    Console.WriteLine($"Text to hash: {text}");
    Console.WriteLine($"Elapsed Milliseconds: {stopWatch.ElapsedMilliseconds}");
    Console.WriteLine($"Plain text: {hashed.ToBase64()}");
    Console.WriteLine($"Hex: {hashed.ToHex()}");
    Console.WriteLine("\nPress any key to continue..");
    Console.ReadKey();

}

void HMacText(string text)
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    byte[] key = RandomNumberGenerator.GenerateKey();
    byte[] hashed = ChooseHMac(text, key);
    stopWatch.Stop();
    Console.WriteLine($"Text to hash: {text}");
    Console.WriteLine($"Elapsed Milliseconds: {stopWatch.ElapsedMilliseconds}");
    Console.WriteLine($"Key: {key.ToBase64()}");
    Console.WriteLine($"Plain text: {hashed.ToBase64()}");
    Console.WriteLine($"Hex: {hashed.ToHex()}");
    Console.WriteLine("\nPress any key to continue..");
    Console.ReadKey();

}

byte[] ChooseHash(string text)
{
    Console.WriteLine("1. Sha1");
    Console.WriteLine("2. Sha256");
    Console.WriteLine("3. HMd5");

    string userInput = Console.ReadLine();
    switch (userInput)
    {
        case "1":
            Console.Clear();
            return Hash.ComputeHashSha1(Encoding.UTF8.GetBytes(text));
        case "2":
            return Hash.ComputeHashSha256(Encoding.UTF8.GetBytes(text));
        case "3":
            return Hash.ComputeHashMd5(Encoding.UTF8.GetBytes(text));
        default:
            Console.WriteLine("Wrong input");
            return null;
    }
}

byte[] ChooseHMac(string text, byte[] key)
{
    Console.WriteLine("1. Sha1");
    Console.WriteLine("2. Sha256");
    Console.WriteLine("3. HMd5");

    string userInput = Console.ReadLine();
    switch (userInput)
    {
        case "1":
            Console.Clear();
            return Hmac.ComputeHMacSha1(Encoding.UTF8.GetBytes(text), key);
        case "2":
            return Hmac.ComputeHMacSha256(Encoding.UTF8.GetBytes(text), key);
        case "3":
            return Hmac.ComputeHMacMd5(Encoding.UTF8.GetBytes(text), key);
        default:
            Console.WriteLine("Wrong input");
            return null;
    }
}