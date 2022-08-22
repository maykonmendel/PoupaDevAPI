using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.Models
{
    public interface IEntity<TPrimaryKey> where TPrimaryKey : struct
    {
        TPrimaryKey Id { get; set; }
    }
}