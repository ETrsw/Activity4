using System;


namespace ThisAPI
{
    interface registeruser
    {
        string Username { get; set; }
        string Password { get; set; }
        int Age { get; set; }
        string Email { get; set; }
         
       
        
    }
   
    public class User: registeruser
    {

        private string username;
        private string password;
        private int age;    
        private string email;   

        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public int Age { get { return age;} set { age = value; } }
        public string Email { get { return email; } set { email = value; } }     
    }

    
}

public class RegistrationService
{
    public delegate void RegistrationServiceDelegate(object user, EventArgs eventArgs);
    public event RegistrationServiceDelegate RegistrationSuccessful;
    public void RegisterUser(ThisAPI.User user)
    {
        Console.WriteLine("Your account is being set up.");
        Thread.Sleep(100);

        OnRegistrationSuccess();
    }
    protected virtual void OnRegistrationSuccess()
    {
        if (RegistrationSuccessful != null)
            RegistrationSuccessful(this, null);
    }
}


public class AppService
{
    public void OnRegistrationSuccess(object user,EventArgs eventArgs)
    {
        Console.WriteLine("Registration successful.");
    }
}
 class Userlist<T>
{
    private T[] arr = new T[10];
    public T this[int i] { get { return arr[i]; } set { arr[i] = value; } }
}
class Program
{
    static void Main ()
    {
        var newUser = new ThisAPI.User
        {
            Username = "blablabla",
            Password = "blablabla1",
            Email = "blablabla@dgd.com",
            Age = 90
        }; 
        var userlist = new Userlist<ThisAPI.User>();
       userlist[0] = newUser;
       var registrationservice = new RegistrationService();
       var appservice = new AppService();
       registrationservice.RegistrationSuccessful += appservice.OnRegistrationSuccess;
       registrationservice.RegisterUser(newUser);
       Console.WriteLine($"User #1 is {userlist[0].Username}");
       Console.ReadKey(); 
    }
}