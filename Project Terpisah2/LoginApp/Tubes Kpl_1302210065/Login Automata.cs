using System;

public class LoginAutomata
{
    private enum State
    {
        Idle,
        EnterUsername,
        EnterPassword,
        Success,
        Failed
    }

    private State currentState;

    public LoginAutomata()
    {
        currentState = State.Idle;
    }

    public void ProcessInput(string input)
    {
        switch (currentState)
        {
            case State.Idle:
                if (input.Equals("login", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Enter username:");
                    currentState = State.EnterUsername;
                }
                break;
            case State.EnterUsername:
                if (!string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Enter password:");
                    currentState = State.EnterPassword;
                }
                break;
            case State.EnterPassword:
                if (!string.IsNullOrEmpty(input))
                {
                    if (Authenticate(input))
                    {
                        Console.WriteLine("Login successful!");
                        currentState = State.Success;
                    }
                    else
                    {
                        Console.WriteLine("Login failed!");
                        currentState = State.Failed;
                    }
                }
                break;
            default:
                Console.WriteLine("Invalid state!");
                break;
        }
    }

    private bool Authenticate(string password)
    {
        // Perform authentication logic here
        // For simplicity, let's assume the password is "password"
        return password.Equals("password");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        LoginAutomata loginAutomata = new LoginAutomata();

        while (true)
        {
            Console.WriteLine("Enter 'login' to start the login process:");
            string input = Console.ReadLine();

            loginAutomata.ProcessInput(input);

            if (loginAutomata.currentState == LoginAutomata.State.Success || loginAutomata.currentState == LoginAutomata.State.Failed)
            {
                break;
            }
        }
    }
}