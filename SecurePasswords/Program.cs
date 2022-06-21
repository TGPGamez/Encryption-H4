using SecurePasswords;
using System.Text;

LoginManager loginManager = new LoginManager();

SystemMessage response = null;
while(response == null || response.Status != true)
{
    Console.Clear();
    Console.Write("Username: ");
    string username = Console.ReadLine();

    Console.Write("Password: ");
    string password = Console.ReadLine();

    response = loginManager.Login(username, password);

    if (response.Status == false)
    {
        Console.WriteLine(response.Message);
        if (response.SystemType != TypeSystem.IncorrectUsername && response.SystemType != TypeSystem.UserLocked)
        {
            SystemMessage systemMessage = loginManager.AddLoginAttempt(username);
            Console.WriteLine(systemMessage.Message);
        }
        Console.WriteLine("\nPress any key to continue");
    }
    else
    {
        Console.WriteLine(response.Message);
        Console.WriteLine("\nPress any key to continue");
    }
    Console.ReadKey();
}