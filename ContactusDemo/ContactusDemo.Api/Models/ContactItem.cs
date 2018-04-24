using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace ContactusDemo.Api.Models
{
    public class ContactItem : ISendable
    {
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string  Email { get; set; }

        public string Pack()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
