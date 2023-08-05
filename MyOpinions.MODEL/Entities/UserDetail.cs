using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOpinions.MODEL.Entities
{
    public class UserDetail:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public int AppUserID { get; set; }

        //Relational Property

        public virtual AppUser AppUser { get; set; }
    }
}
