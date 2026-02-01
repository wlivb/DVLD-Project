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
    public class clsPerson : clsBaseLogic<PersonDTO>
    {

        public int PersonID
        {
            get => DTO.PersonID;
            set => DTO.PersonID = value;
        }
        public string NationalNo
        {
            get => DTO.NationalNo;
            set => DTO.NationalNo = value;
        }
        public string FirstName
        {
            get => DTO.FirstName;
            set => DTO.FirstName = value;
        }
        public string SecondName
        {
            get => DTO.SecondName;
            set => DTO.SecondName = value;
        }
        public string ThirdName
        {
            get => DTO.ThirdName;
            set => DTO.ThirdName = value;
        }
        public string LastName
        {
            get => DTO.LastName;
            set => DTO.LastName = value;
        }
        public DateTime DateOfBirth
        {
            get => DTO.DateOfBirth;
            set => DTO.DateOfBirth = value;
        }
        public short Gendor
        {
            get => DTO.Gendor;
            set => DTO.Gendor = value;
        }
        public string Address
        {
            get => DTO.Address;
            set => DTO.Address = value;
        }
        public string Phone
        {
            get => DTO.Phone;
            set => DTO.Phone = value;
        }
        public string Email
        {
            get => DTO.Email;
            set => DTO.Email = value;
        }
        public int NationalityCountryID
        {
            get => DTO.NationalityCountryID;
            set => DTO.NationalityCountryID = value;
        }
        public string NationalityCountryName
        {
            get => clsCountryData.GetCountryNameByID(NationalityCountryID);
        }
        public string ImagePath
        {
            get => DTO.ImagePath;
            set => DTO.ImagePath = value;
        }
        public string FullName
        {
            get
            {
                string full = FirstName + " " + SecondName;
                if (!string.IsNullOrWhiteSpace(ThirdName))
                    full += " " + ThirdName;
                full += " " + LastName;
                return full;
            }
        }

        public clsPerson() : base() { }

        private clsPerson(PersonDTO dto) : base(dto) { }

        public static clsPerson Find(int ID)
        {
            PersonDTO dto = clsPersonData.GetPersonInfoByID(ID);

            if (dto != null)
                return new clsPerson(dto); 
            else
                return null;
        }
        public static clsPerson Find(string NationalNo)
        {
            PersonDTO dto = clsPersonData.GetPersonInfoByNationalNo(NationalNo);

            if (dto != null)     
               return new clsPerson(dto);
            else
                return null;
        }


        protected override bool _AddNew()
        {
            this.DTO.PersonID = clsPersonData.AddNewPerson(this.DTO);
            return (this.DTO.PersonID != -1);
        }
        protected override bool _Update()
        {
            return clsPersonData.UpdatePerson(this.DTO);
        }


        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }


        public static bool Delete(int ID)
        {
            return clsPersonData.DeletePerson(ID);
        }

        public static bool isExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }
        public static bool isExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }
    }
}
