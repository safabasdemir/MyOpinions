using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOpinions.MODEL.Entities
{
    public class Post:BaseEntity
    {
        public string PostTitle { get; set; }
        public string PostWrite { get; set; }

        public string PictureName { get; set; }
       
        public int CategoryID { get; set; }

        [NotMapped]
        public IFormFile Dosya { get; set; }

        //Relational Property

        
        public virtual Category Category { get; set; }
    }
}
