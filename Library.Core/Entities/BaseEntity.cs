using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public int Id { get; private set; }
        
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public DateTime? DeletedAt { get; private set; }
        
        public bool IsDeleted { get; private set; }

        public void Delete() 
        {
            IsDeleted = true;
            DeletedAt = DateTime.Now;
        }
    }
}
