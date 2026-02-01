using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class ApplictionTypeDTO
    {
        public int ApplictionTypeID { get; set; }
        public string ApplictionTypeTitle { get; set; }
        public decimal ApplictionTypeFees { get; set; }

        public ApplictionTypeDTO(int ID, string Title, decimal Fees)
        {
            this.ApplictionTypeID = ID;
            this.ApplictionTypeTitle = Title;
            this.ApplictionTypeFees = Fees;
        }

        public ApplictionTypeDTO() { }

    }
}
