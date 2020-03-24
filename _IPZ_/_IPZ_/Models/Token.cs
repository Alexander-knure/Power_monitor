using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _IPZ_.Models
{
    public class Token
    {
        public int ID { get; set; }
        public string access_token { get; set; }
        public string error_description { get; set; }
        public DateTime expire_data { get; set; }

        public Token()
        {

        }

    }
}
