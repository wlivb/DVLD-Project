using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class TestTypeDTO
    {
        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
        public enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; } // May be null
        public decimal TestTypeFees { get; set; }

        public TestTypeDTO(int ID, string Description, decimal Fees)
        {
            this.TestTypeID = (enTestType)ID;
            this.TestTypeDescription = Description;
            this.TestTypeFees = Fees;
        }

        public TestTypeDTO() { }
    }
}
