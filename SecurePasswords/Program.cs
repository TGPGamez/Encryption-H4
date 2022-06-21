using SecurePasswords;
using System.Text;



MockupData mockupData = new MockupData();




byte[] salt = Hash.GenerateSalt();
byte[] hashedPasswordWithSalt = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes("Test1234"), salt);

byte[] lastHash = Pbkdf2.HashPassword(hashedPasswordWithSalt, salt);
User user = new User("Test", lastHash.ToBase64(), "sha256", salt);
mockupData.AddUser(user);



byte[] hashedPasswordWithSalt = Hash.HashPasswordWithSalt(Encoding.UTF8.GetBytes("Test1234"), mockupData.GetUsers().Find(x => x.Username == "Test").Salt);
Console.WriteLine($"User pass: {mockupData.GetUsers().Find(x => x.Username == "Test").Password}");
Console.WriteLine($"Input pass {hashedPasswordWithSalt.ToBase64()}");
