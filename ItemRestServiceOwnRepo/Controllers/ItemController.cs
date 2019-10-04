using System;
using System.Collections.Generic;
using System.Linq;
using ItemLibrary1;
using Microsoft.AspNetCore.Mvc;

namespace ItemRestServiceOwnRepo.Controllers
{
    //[Route("api/[controller]")]
    //This special method helps to change uri name.
    [Route("api/localItems")]
    [ApiController]
    public class ItemController : ControllerBase
    {


        private static readonly List<Item> ItemList = new List<Item>()
        {
            new Item(1, "Everest", "Nice", 300),
            new Item(2, "Gorkha", "Good", 500),
            new Item(3, "Tuborg", "Perfect", 400),
            new Item(4,"Carlsbourg","Very Nice",100),
            new Item(5,"Nepal Ice","Strongly perfect",50)


        };

        [HttpGet]
        [Route("Name/{substring}")]
        public IEnumerable<Item> GetFromSubstring(string substring)
        {
            return ItemList.FindAll(i => i.Name.Contains(substring));
        }
        [HttpGet]
        [Route("Quality/{quality}")]
        public IEnumerable<Item> GetQuality(string quality)
        {
            return ItemList.FindAll(i => i.Quality.Contains(quality));
        }


        // GET: api/Item
        [HttpGet]
        public IEnumerable<Item> Get()
        {

            return ItemList;
        }

        // GET: api/Item/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet]
        [Route("{id}")]
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
            if (item != null)
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
