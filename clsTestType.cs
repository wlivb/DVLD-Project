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
    public class clsTestType : clsBaseLogic<TestTypeDTO>
    {
        public clsTestType() : base() { }

        private clsTestType(TestTypeDTO dto) : base(dto) { }

        public static clsTestType Find(int ID)
        {
            TestTypeDTO dto = clsTestTypeData.GetTestTypeInfoByID(ID);
            if (dto != null)
                return new clsTestType(dto);
            else
                return null;
        }
        public static clsTestType Find(string Title)
        {
            TestTypeDTO dto = clsTestTypeData.GetTestTypeInfoByTitle(Title);
            if (dto != null)
                return new clsTestType(dto);
            else
                return null;
        }

        protected override bool _AddNew()
        {
            this.DTO.TestTypeID = (TestTypeDTO.enTestType)clsTestTypeData.AddNewTestType(this.DTO);
            return ((int)this.DTO.TestTypeID != -1); 
        }

        protected override bool _Update()
        {
            return clsTestTypeData.UpdateTestType(this.DTO);
        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypeData.GetAllTestType();
        }

    }
}
