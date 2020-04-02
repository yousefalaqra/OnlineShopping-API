using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{

    private readonly IItemManager _itemManager;


    public ItemsController(IItemManager itemManager)
    {
        _itemManager = itemManager;
    }

    [HttpGet]
    public IEnumerable<ItemEntity> GetItems(){
        var result = _itemManager.GetItems();

        return result;
    }

    [HttpGet("{id}")]
      public async Task<ItemEntity> GetItem(Guid id){
        var result = await _itemManager.GetItem(id);

        return result;
    }


    [HttpPost]
    public ItemEntity PostItem(ItemModel model)
    {
        var item = _itemManager.AddItem(model);

        return item;
    }


    
    [HttpPut("{id}")]
    public async Task<ItemEntity> PutItem(Guid id ,ItemModel model)
    {
        var item = await _itemManager.UpdateItem(id ,model);

        return item;
    }


    [HttpDelete("{id}")]
    public string DeleteItem(Guid id)
    {
        _itemManager.DeleteItem(id);

        return "Deleted";
    }
    

} 