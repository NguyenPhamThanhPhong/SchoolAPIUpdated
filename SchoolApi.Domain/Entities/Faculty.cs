﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Domain.Entities
{
#pragma warning disable CS8618
    public class Faculty
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Subject> subjects { get; set; }
        public List<Post> posts { get; set; }
        public Faculty() { 
            id = Guid.NewGuid().ToString();
            name = "";
            subjects = new List<Subject>();
            posts = new List<Post>();
        }
    }
}
