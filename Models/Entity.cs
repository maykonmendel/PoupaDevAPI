using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoupaDevAPI.Models
{
    public abstract class Entity<TPrimaryKey> where TPrimaryKey : struct
    {
        public TPrimaryKey Id { get; set; }        
    }
}