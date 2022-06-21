
using SimpleEncrypt;

Excel excel = new Excel(@"C:\Users\tobi8268\Desktop\Results", 1);

EncryptResultSet encryptResultSet = RandomCrypt.RNGCrypto();
excel.WriteToCell(0, 0, "RNGCrypto");
excel.WriteToCell(0, 1, $"Elapsed ticks: {encryptResultSet.TicksElapsed}");
int index = 1;
foreach (string result in encryptResultSet.Data)
{
    //Console.WriteLine(index);
    excel.WriteToCell(index, 0, result);
    index++;
}

excel.Save();

EncryptResultSet encryptResultSet2 = RandomCrypt.RandomCrypto();
excel.WriteToCell(0, 3, "Random");
excel.WriteToCell(0, 4, $"Elapsed ticks: {encryptResultSet2.TicksElapsed}");
index = 1;
foreach (string result in encryptResultSet.Data)
{
    //Console.WriteLine(index);
    excel.WriteToCell(index, 3, result);
    index++;
}

excel.Save();

excel.Close();

//Console.WriteLine("");
//RandomCrypt.RandomCrypto();

//Console.WriteLine("");

//Console.WriteLine("Encrypter:");
//Console.WriteLine(Encrypter.Enctrypt("Hello"));
//Console.WriteLine(Encrypter.Decrypt("Ifmmp"));
Console.WriteLine("Done");
Console.ReadLine();