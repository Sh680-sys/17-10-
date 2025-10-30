using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSHOP1.DAL.Models;

public class Category :BaseModel
{
    public string Description { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}