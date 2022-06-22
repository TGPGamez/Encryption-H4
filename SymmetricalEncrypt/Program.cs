using SymmetricalEncrypt;

Encryption encryption = new Encryption();

while (true)
{
    Console.Clear();
    Console.WriteLine("Choose encryption type:");
    Console.WriteLine("1. Aes\n2. Des");
    Console.Write("Choice: ");
    string choice = Console.ReadLine();
    Console.Write("Text to encrypt: ");
    string text = Console.ReadLine();

    byte[] computed = null;
    byte[] decrypted = null;
    byte[] key = null;
    byte[] iv = null;

    switch (choice)
    {
        case "1":
            key = RandomGeneration.GenerateRandomByteArray(32);
            iv = RandomGeneration.GenerateRandomByteArray(16);

            computed = encryption.EncryptAes(text.GetBytesUTF8(), key, iv);

            decrypted = encryption.DecryptAes(computed, key, iv);
            break;
        case "2":
            key = RandomGeneration.GenerateRandomByteArray(8);
            iv = RandomGeneration.GenerateRandomByteArray(8);

            computed = encryption.EncryptDes(text.GetBytesUTF8(), key, iv);
            decrypted = encryption.DecryptDes(computed, key, iv);
            break;
        default:
            break;
    }
    if (computed != null && decrypted != null)
    {
        Console.WriteLine($"\n\nDecrypted: {decrypted.GetString()}");
        Console.WriteLine($"Key: {key.ToBase64()}");
        Console.WriteLine($"IV: {iv.ToBase64()}");
        Console.WriteLine($"Base: {computed.ToBase64()}");
        Console.WriteLine($"Hex: {computed.ToHex()}");
    }
    Console.WriteLine("\nPress any key to reset...");
    Console.ReadKey();
}