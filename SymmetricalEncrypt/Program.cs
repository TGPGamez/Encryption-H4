using SymmetricalEncrypt;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

Encryption encryption = new Encryption();

while (true)
{
    Console.Clear();
    Console.WriteLine("Choose encryption type:");
    Console.WriteLine("1. Aes\n2. Des\n3. TripleDes");
    Console.Write("Choice: ");
    string choice = Console.ReadLine();
    Console.Write("Text to encrypt: ");
    string text = Console.ReadLine();

    switch (choice)
    {
        case "1":
            encryption.SetSymmetricalAlgorithm(Aes.Create());
            break;
        case "2":
            encryption.SetSymmetricalAlgorithm(DES.Create());
            break;
        case "3":
            encryption.SetSymmetricalAlgorithm(TripleDES.Create());
            break;
        default:
            Console.WriteLine("Incorrect algorithm.");
            break;
    }
    if (encryption.IsEncryptionSet())
    {
        Stopwatch encryptWatch = new Stopwatch();
        encryptWatch.Start();
        byte[] computed = encryption.Encrypt(Encoding.UTF8.GetBytes(text));
        encryptWatch.Stop();

        Stopwatch decryptWatch = new Stopwatch();
        decryptWatch.Start();
        byte[] decrypted = encryption.Decrypt(computed);
        decryptWatch.Stop();

        Console.WriteLine("\n\n");
        Console.WriteLine($"Encrypted: {computed.ToBase64()}");
        Console.WriteLine($"Encryption time: {encryptWatch.ElapsedTicks} ticks");
        Console.WriteLine($"Hex: {computed.ToHex()}");
        Console.WriteLine($"Decrypted: {decrypted.GetString()}");
        Console.WriteLine($"Decryption time: {decryptWatch.ElapsedTicks} ticks");
    }
    Console.WriteLine("\nPress any key to reset...");
    Console.ReadKey();
}