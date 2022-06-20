
using SimpleEncrypt;

RandomCrypt.RNGCrypto();
Console.WriteLine("");
RandomCrypt.RandomCrypto();

Console.WriteLine("");

Console.WriteLine("Encrypter:");
Console.WriteLine(Encrypter.Enctrypt("Hello"));
Console.WriteLine(Encrypter.Decrypt("Ifmmp"));

Console.ReadLine();