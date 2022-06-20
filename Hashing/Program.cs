

using Hashing;

while (true)
{

    Console.WriteLine("Choose encryption type: \n" +
        "1. Sha256\n" +
        "2. Md5\n" + 
        "3. Hmac md5");

    string choice = Console.ReadLine().ToLower();
    Console.Write("Text: ");
    string text = Console.ReadLine();

    byte[] computed = null;

    switch (choice)
    {
        case "1":
        case "sha256":
            computed = Hash.ComputeHashSha256(text.GetBytesUTF8());
            break;
        case "2":
        case "md5":
            computed = Hash.ComputeHashMd5(text.GetBytesUTF8());
            break;
        case "3":
        case "hmac md5":
            Console.Write("Key: ");
            string hmacMd5Key = Console.ReadLine();
            computed = Hmac.ComputeHmacmd5(text.GetBytesUTF8(), hmacMd5Key.GetBytesUTF8());
            break;
        default:
            Console.WriteLine("Incorrect input");
            break;
    }

    if (computed != null)
    {
        Console.WriteLine("Base: " + computed.ToBase64());
        Console.WriteLine("Hex: " + computed.ToHex());
    }
    Console.WriteLine("-------------------");
}