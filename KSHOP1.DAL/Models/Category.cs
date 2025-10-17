using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSHOP1.DAL.Models;

public class Category :BaseModel
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}