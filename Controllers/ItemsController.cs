using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class ItemsController : ControllerBase
{

    private readonly IItemManager _itemManager;


    public ItemsController(IItemManager itemManager)
    {
        _itemManager = itemManager;
    }

    [HttpGet]
    public IActionResult GetItems(){
        var result = _itemManager.GetItems();

        return Ok(result);
    }

    // [HttpGet($"{id}")]
    //   public IActionResult GetItems(){
    //     var result = _itemManager.GetItem(id);

    //     return Ok(result);
    // }


    [HttpPost]
    public IActionResult PostItem(ItemModel model)
    {
        var item = _itemManager.AddItem(model);

        return Ok(item);
    }
} 