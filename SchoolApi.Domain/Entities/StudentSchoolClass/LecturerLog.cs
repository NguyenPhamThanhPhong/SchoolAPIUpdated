﻿using SchoolApi.Domain.Entities.UserGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities.StudentSchoolClass
{
    public class LecturerLog : SchoolmemberLog
    {
        public virtual Lecturer schoolMember { get; set; }
    }
}
