﻿using MyOpinions.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOpinions.MODEL.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Status = DataStatus.Inserted;
            CreatedDate = DateTime.Now;
        }

        public int ID { get; set; }
        public DataStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
