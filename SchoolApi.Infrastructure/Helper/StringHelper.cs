using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Helper
{
    public class StringHelper
    {
        public static string cleanSearchTerm(string searchTerm)
        {
            return Regex.Replace(searchTerm, "[^a-zA-Z0-9]", "");
        }
    }
}
