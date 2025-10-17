using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSHOP1.DAL.Models
{
    public enum Status
    {
        Active=1,
        Inactive=2,
     }
    public class BaseModel
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } 
        public Status status { get; set; }
        public bool IsActive { get; set; }
    }
}
