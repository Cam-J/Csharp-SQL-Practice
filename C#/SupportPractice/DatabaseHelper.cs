using System;
using Microsoft.Data.SqlClient;

public static class DatabaseHelper
{
    // Read connection string
    private static readonly string connectionString = File.ReadAllText("connection.txt").Trim();

    public static void AddUser(string name, string email)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void GetUsers()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "SELECT UserID, Name, Email FROM Users";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["UserID"]}: {reader["Name"]} - {reader["Email"]}");
                }
            }
        }
    }

    public static void UpdateUser(int id, string newEmail)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "UPDATE Users SET Email = @Email WHERE UserID = @UserID";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Email", newEmail);
                cmd.Parameters.AddWithValue("@UserID", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public static void DeleteUser(int id)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            string sql = "DELETE FROM Users WHERE UserID = @UserID";
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@UserID", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}