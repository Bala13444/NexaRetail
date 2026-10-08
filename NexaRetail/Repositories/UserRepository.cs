using Microsoft.Data.SqlClient;
using NexaRetail.Helpers;
using NexaRetail.Models;
using System;
using System.Data;

namespace NexaRetail.Repositories
{
    public class UserRepository
    {
        public User GetUser(string userName, string passwordHash)
        {
            User user = null;

            using (SqlConnection connection =
                new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command =
                    new SqlCommand("dbo.usp_UserLogin", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue(
                        "@UserName",
                        userName);

                    command.Parameters.AddWithValue(
                        "@PasswordHash",
                        passwordHash);

                    connection.Open();

                    using (SqlDataReader reader =
                        command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                UserId = Convert.ToInt32(
                                    reader["UserId"]),

                                UserName = Convert.ToString(
                                    reader["UserName"]),

                                FullName = Convert.ToString(
                                    reader["FullName"]),

                                Email = Convert.ToString(
                                    reader["Email"]),

                                MobileNo = Convert.ToString(
                                    reader["MobileNo"]),

                                RoleId = Convert.ToInt32(
                                    reader["RoleId"]),

                                RoleName = Convert.ToString(
                                    reader["RoleName"]),

                                IsActive = Convert.ToBoolean(
                                    reader["IsActive"])
                            };
                        }
                    }
                }
            }

            return user;
        }
    }
}