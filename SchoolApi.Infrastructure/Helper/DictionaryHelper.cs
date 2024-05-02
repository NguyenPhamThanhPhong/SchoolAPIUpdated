using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApi.Infrastructure.Helper
{
    public static class DictionaryHelper
    {
        public static Dictionary<string, string> LeftSymtricKeys(Dictionary<string, string> dictionary, IEnumerable<string> keyList)
        {
            if(dictionary!=null)
            {
                foreach (var key in keyList)
                {
                    dictionary.Remove(key);
                }
                return dictionary;
            }
            return new Dictionary<string, string>();
        }
    }
}
