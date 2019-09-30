using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItemLibrary.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ItemRestServiceOwnRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        //private static  List<Item> ItemList = new List<Item>();

        private static readonly List<Item> ItemList = new List<Item>()
        {
            new Item(1, "Everest", "Nice", 300),
            new Item(2, "Gorkha", "Good", 500),
            new Item(3, "Tuborg", "Perfect", 400),
            new Item(4,"Carlsbourg","Very Nice",100),
            new Item(5,"Nepal Ice","Strongly perfect",50)


        };
        // GET: api/Item
        [HttpGet]
        public IEnumerable<Item> Get()
        {
            //return new string[] { "value1", "value2" };
            return ItemList;
        }

        // GET: api/Item/5
        [HttpGet("{id}", Name = "Get")]
        public Item Get(int id)
        {
            return ItemList.Find(i => i.Id == id);
        }

        // POST: api/Item
        [HttpPost]
        public void Post([FromBody] Item value)
        {
           ItemList.Add(value);
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item value)
        {
            Item item = Get(id);
            if (item !=null)
            {
                item.Id = value.Id;
                item.Name = value.Name;
                item.Quality = value.Quality;
                item.Quantity = value.Quantity;
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Item item = Get(id);
            ItemList.Remove(item);
        }
    }
}
