


using AsymmetricalEncrypt;
using System.Diagnostics;

while (true)
{
    Console.Clear();
    Console.WriteLine("Choose encryption type:");
    Console.WriteLine("1. Rsa key\n2. Rsa Container\n3. Rsa XML");
    Console.Write("Choice: ");
    string choice = Console.ReadLine();
    Console.Write("Text to encrypt: ");
    string text = Console.ReadLine();

    byte[] computed = null;
    byte[] decrypted = null;
    Stopwatch stopwatchEncrypt = new Stopwatch();
    Stopwatch stopwatchDecrypt = new Stopwatch();

    switch (choice)
    {
        case "1":
            RsaEncryptionKey rsaKey = new RsaEncryptionKey();
            rsaKey.AssignNewKey();

            stopwatchEncrypt.Start();
            computed = rsaKey.EncryptData(text.GetBytesUTF8());
            stopwatchEncrypt.Stop();

            stopwatchDecrypt.Start();
            decrypted = rsaKey.DecryptData(computed);
            stopwatchDecrypt.Stop();
            break;
        case "2":
            RsaEncryptionContainer encryptionContainer = new RsaEncryptionContainer("Tobias secret container");
            encryptionContainer.AssignNewKey();

            stopwatchEncrypt.Start();
            computed = encryptionContainer.EncryptData(text.GetBytesUTF8());
            stopwatchEncrypt.Stop();

            stopwatchDecrypt.Start();
            decrypted = encryptionContainer.DecryptData(computed);
            stopwatchDecrypt.Stop();
            encryptionContainer.DeleteKeyInCsp();
            break;
        case "3":
            string publicPath = @"C:\Users\TGPGamez\Desktop\ProgrammingData\publicKey.xml";
            string privatePath = @"C:\Users\TGPGamez\Desktop\ProgrammingData\privateKey.xml";
            RsaEncryptionXML encryptionXML = new RsaEncryptionXML(publicPath, privatePath);
            encryptionXML.AssignNewKey();

            stopwatchEncrypt.Start();
            computed = encryptionXML.EncryptData(text.GetBytesUTF8());
            stopwatchEncrypt.Stop();

            stopwatchDecrypt.Start();
            decrypted = encryptionXML.DecryptData(computed);
            stopwatchDecrypt.Stop();
            break;
        default:
            Console.WriteLine("Incorrect input");
            break;
    }
    if (computed != null)
    {
        Console.WriteLine($"Encrypted: {computed.ToBase64()}");
        Console.WriteLine($"Encrypted Hex: {computed.ToHex()}");
        Console.WriteLine($"Encryption time: {stopwatchEncrypt.ElapsedTicks}");
        Console.WriteLine($"Derypted: {decrypted.GetString()}");
        Console.WriteLine($"Derypted Hex: {decrypted.ToHex()}");
        Console.WriteLine($"Decryption time: {stopwatchDecrypt.ElapsedTicks}");
    }
    Console.WriteLine("\nPress any key to reset...");
    Console.ReadKey();
}