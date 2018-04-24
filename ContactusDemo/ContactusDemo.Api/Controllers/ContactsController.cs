﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ContactusDemo.Api.Models;
using ContactusDemo.Api.MessageBroker;
using RabbitMQ.Client;


namespace ContactusDemo.Api.Controllers
{
    [Route("api/v1.00/[controller]")]
    public class ContactsController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]JObject data)
        {
            ContactItem contact = data.ToObject<ContactItem>();

            IMessageSender Sender = new NormalSender(contact.Telephone, "localhost", "hello");

            Sender.SendData();



        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
