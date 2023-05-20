using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dbWeb.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        
        public string Name { get; set; }

        public decimal Budget { get; set; }
    }
}
