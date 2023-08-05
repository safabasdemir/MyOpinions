using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOpinions.MODEL.Entities
{
    public class Category:BaseEntity
    {
        public string CategoryName { get; set; }


        //Relational Property

        public virtual List<Post> Posts { get; set; }
    }

    
}
