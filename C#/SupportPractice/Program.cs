using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        Console.WriteLine(" Users before insert:");
        DatabaseHelper.GetUsers();

        Console.WriteLine("\n Adding new user...");
        DatabaseHelper.AddUser("Jane", "jane@example.com");

        Console.WriteLine("\n Users after insert:");
        DatabaseHelper.GetUsers();

        Console.WriteLine("\n Updating user with ID 3...");
        DatabaseHelper.UpdateUser(3, "updated@example.com");
        DatabaseHelper.GetUsers();

        Console.WriteLine("\n Deleting user with ID 2...");
        DatabaseHelper.DeleteUser(2);
        DatabaseHelper.GetUsers();
    }
}