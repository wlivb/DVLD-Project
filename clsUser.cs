using DataAccessLayer.DataSources;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.DataManagement
{
    public class clsUser : clsBaseLogic<UserDTO>
    {
        public int UserID
        {
            get => DTO.UserID;
            set => DTO.UserID = value;
        }
        public int PersonID
        {
            get => DTO.PersonID;
            set => DTO.PersonID = value;
        }
        public string UserName
        {
            get => DTO.UserName;
            set => DTO.UserName = value;
        }     
        public string Password
        {
            get => DTO.Password;
            set => DTO.Password = value;
        }        
        public bool IsActive
        {
            get => DTO.IsActive;
            set => DTO.IsActive = value;
        }

        private clsPerson _PersonInfo;
        public clsPerson PersonInfo
        {
            get
            {
                if (_PersonInfo == null)
                    _PersonInfo = clsPerson.Find(this.PersonID);
                return _PersonInfo;
            }
        }

        public clsUser() : base() { }

        private clsUser(UserDTO dto) : base(dto) { }

        public static clsUser Find(int ID)
        {
            UserDTO dto = clsUserData.GetUserInfoByID(ID);

            if (dto != null)
                return new clsUser(dto);
            else
                return null;
        }
        public static clsUser Find(string UserName)
        {
            UserDTO dto = clsUserData.GetUserInfoByUserName(UserName);

            if (dto != null)
                return new clsUser(dto);
            else
                return null;
        }
        public static clsUser Find(string UserName, string PAS)
        {
            UserDTO dto = clsUserData.GetUserByUserNameAndPassword(UserName, PAS);

            if (dto != null)
                return new clsUser(dto);
            else
                return null;
        }

        protected override bool _AddNew()
        {
            if(!isPersonAlreadyUser(PersonID))
            {
                this.DTO.UserID = clsUserData.AddNewUser(this.DTO);
                return (this.DTO.UserID != -1);
            } 
           return false;
        }
        protected override bool _Update()
        {
            return clsUserData.UpdateUser(this.DTO);
        }

        public bool ChangePassword(string NewPassword)
        {
            return clsUserData.ChangeUserPassword(this.UserID, NewPassword);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool Delete(int ID)
        {
            return clsUserData.DeleteUser(ID);
        }

        public static bool isExist(int ID)
        {
            return clsUserData.IsUserExist(ID);
        }
        public static bool isExist(string UserName)
        {
            return clsUserData.IsUserExist(UserName);
        }
        public static bool isPersonAlreadyUser(int PersonID)
        {
            return clsUserData.IsPersonAlreadyUser(PersonID);
        }

    }
}
