using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataSources
{


    public static class clsUserData
    {
        public static UserDTO GetUserInfoByID(int UserID)
        {
            UserDTO User = null;

            string query = "SELECT * FROM Users WHERE UserID = @ID";

            clsSqlHelper.ExecuteReader(query,
              cmd =>
              {
                  cmd.Parameters.AddWithValue("@ID", UserID);
              },
              reader =>
              {
                  User = new UserDTO
           (
           (int)reader["UserID"], (int)reader["PersonID"], (string)reader["UserName"],
           (string)reader["Password"], (bool)reader["IsActive"]
           );
              }
            );

            return User;
        }
        public static UserDTO GetUserInfoByUserName(string UsrName)
        {
            UserDTO User = null;

            string query = "SELECT * FROM Users WHERE UserName = @UsrName";

            clsSqlHelper.ExecuteReader(query,
              cmd =>
              {
                  cmd.Parameters.AddWithValue("@UsrName", UsrName);
              },
              reader =>
              {
                  User = new UserDTO
           (
           (int)reader["UserID"], (int)reader["PersonID"], (string)reader["UserName"],
           (string)reader["Password"], (bool)reader["IsActive"]
           );
              }
            );

            return User;
        }
        public static UserDTO GetUserByUserNameAndPassword(string UsrName, string PAS)
        {
            UserDTO User = null;

            string query = "SELECT * FROM Users WHERE UserName = @UsrName AND Password = @PAS";

            clsSqlHelper.ExecuteReader(query,
              cmd =>
              {
                  cmd.Parameters.AddWithValue("@UsrName", UsrName);
                  cmd.Parameters.AddWithValue("@PAS", PAS);
              },
              reader =>
              {
                  User = new UserDTO
           (
           (int)reader["UserID"], (int)reader["PersonID"], (string)reader["UserName"],
           (string)reader["Password"], (bool)reader["IsActive"]
           );
              }
            );

            return User;
        }

        public static int AddNewUser(UserDTO dto)
        {
            string query = @"INSERT INTO Users (PersonID, UserName, Password, IsActive)
                        VALUES (@PID, @USRN, @PAS, @ISACT);
                        SELECT SCOPE_IDENTITY();";

            return clsSqlHelper.ExecuteScalar(query, cmd => {
                cmd.Parameters.AddWithValue("@PID", dto.PersonID);
                cmd.Parameters.AddWithValue("@USRN", dto.UserName);
                cmd.Parameters.AddWithValue("@PAS", dto.Password);
                cmd.Parameters.AddWithValue("@ISACT", dto.IsActive);
            });
        }
        public static bool UpdateUser(UserDTO dto)
        {
            string query = @"UPDATE Users SET UserName=@USRN, Password=@PAS, IsActive=@ISACT WHERE UserID=@ID";

            return clsSqlHelper.ExecuteNonQuery(query,
              cmd =>
              {
                  cmd.Parameters.AddWithValue("@ID", dto.UserID);
                  cmd.Parameters.AddWithValue("@USRN", dto.UserName);
                  cmd.Parameters.AddWithValue("@PAS", dto.Password);
                  cmd.Parameters.AddWithValue("@ISACT", dto.IsActive);
              }

              ) > 0;
        }
        public static bool ChangeUserPassword(int UserID, string NewPassword)
        {
            string query = @"UPDATE Users SET Password=@NewPAS WHERE UserID=@ID";

            return clsSqlHelper.ExecuteNonQuery

                (query,

                cmd =>

                {

                    cmd.Parameters.AddWithValue("@ID", UserID);

                    cmd.Parameters.AddWithValue("@NewPAS", NewPassword);

                }

                ) > 0;
        }
        public static bool DeleteUser(int UserID)
        {
            return clsSqlHelper.ExecuteNonQuery("DELETE FROM Users WHERE UserID = @ID",
              cmd => cmd.Parameters.AddWithValue("@ID", UserID)) > 0;
        }


        public static DataTable GetAllUsers()
        {
            return clsSqlHelper.ExecuteDataTable("SELECT * FROM v_UsersList");
        }

        public static bool IsUserExist(int UserID)
        {
            return clsSqlHelper.IsExist("SELECT Found=1 FROM Users WHERE UserID = @ID",
              cmd => cmd.Parameters.AddWithValue("@ID", UserID));
        }
        public static bool IsUserExist(string UserName)
        {
            return clsSqlHelper.IsExist("SELECT Found=1 FROM Users WHERE UserName = @UsrName",
              cmd => cmd.Parameters.AddWithValue("@UsrName", UserName));
        }
        public static bool IsPersonAlreadyUser(int PersonID)
        {
            return clsSqlHelper.IsExist("SELECT Found=1 FROM Users WHERE PersonID = @ID",
              cmd => cmd.Parameters.AddWithValue("@ID", PersonID));
        }

    }
}
