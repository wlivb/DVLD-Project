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
    public class clsApplictionType : clsBaseLogic<ApplictionTypeDTO>
    {
        public clsApplictionType() : base() { }

        private clsApplictionType(ApplictionTypeDTO dto) : base(dto) { }

        public static clsApplictionType Find(int ID)
        {
            ApplictionTypeDTO dto = clsApplictionTypeData.GetApplictionTypeInfoByID(ID);
            if (dto != null)
                return new clsApplictionType(dto);
            else
                return null;
        }
        public static clsApplictionType Find(string Title)
        {
            ApplictionTypeDTO dto = clsApplictionTypeData.GetApplictionTypeInfoByTitle(Title);
            if (dto != null)
                return new clsApplictionType(dto);
            else
                return null;
        }

        protected override bool _AddNew()
        {
            this.DTO.ApplictionTypeID = clsApplictionTypeData.AddNewApplictionType(this.DTO);
            return (this.DTO.ApplictionTypeID != -1);
        }

        protected override bool _Update()
        {
            return clsApplictionTypeData.UpdateApplictionType(this.DTO);
        }

        public static DataTable GetAllApplictionTypes()
        {
            return clsApplictionTypeData.GetAllApplictionType();
        }


    }

}

