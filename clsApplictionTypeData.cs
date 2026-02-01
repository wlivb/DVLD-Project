using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataSources
{
    public class clsApplictionTypeData
    {
        public static ApplictionTypeDTO GetApplictionTypeInfoByID(int ID)
        {
            ApplictionTypeDTO ApplictionType = null;

            string query = "SELECT * FROM ApplictionTypes WHERE ApplictionTypeID = @ID";

            clsSqlHelper.ExecuteReader(query,
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@ID", ID);
                },
                reader =>
                {
                    ApplictionType = new ApplictionTypeDTO
                    {
                        ApplictionTypeID = (int)reader["ApplictionTypeID"],
                        ApplictionTypeTitle = (string)reader["ApplictionTypeTitle"],
                        ApplictionTypeFees = (decimal)reader["ApplictionTypeFees"]
                    };
                });

           return ApplictionType;
        }
        public static ApplictionTypeDTO GetApplictionTypeInfoByTitle(string Title)
        {
            ApplictionTypeDTO ApplictionType = null;

            string query = "SELECT * FROM ApplictionTypes WHERE ApplictionTypetitle = @Title";

            clsSqlHelper.ExecuteReader(query,
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@Title", Title);
                },
                reader =>
                {
                    ApplictionType = new ApplictionTypeDTO
                    {
                        ApplictionTypeID = (int)reader["ApplictionTypeID"],
                        ApplictionTypeTitle = (string)reader["ApplictionTypeTitle"],
                        ApplictionTypeFees = (decimal)reader["ApplictionTypeFees"]
                    };
                });

            return ApplictionType;
        }
        public static DataTable GetAllApplictionType()
        {
            return clsSqlHelper.ExecuteDataTable("SELECT * FROM ApplictionTypes");
        }

        public static int AddNewApplictionType(ApplictionTypeDTO dto)
        {
            string query = @"INSERT INTO ApplictionTypes (ApplictionTypeTitle, ApplictionTypeFees)
                         VALUES (@Title, @Fees);
                         SELECT SCOPE_IDENTITY();";
            object result = clsSqlHelper.ExecuteScalar(query,
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@ApplictionTypeTitle", dto.ApplictionTypeTitle);
                    cmd.Parameters.AddWithValue("@ApplictionTypeFees", dto.ApplictionTypeFees);
                });
            return Convert.ToInt32(result);
        }

        public static bool UpdateApplictionType(ApplictionTypeDTO dto)
        {
            string query = @"UPDATE ApplictionTypes SET ApplictionTypeTitle=@Title, ApplictionTypeFees=@Fees WHERE ApplictionTypeID=@ID";

            return clsSqlHelper.ExecuteNonQuery(query,
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@ID", dto.ApplictionTypeID);
                }

               ) > 0;
        }
    }
}
