using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class ItemManager : IItemManager
{
    private readonly IRepository<ItemEntity> _itemRepository;

    public ItemManager(IRepository<ItemEntity> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public ItemEntity AddItem(ItemModel model)
    {
        var ItemEntity = new ItemEntity
        {
            CreatedBy = model.CreatedBy,
            CreatedOn = model.CreatedOn,
            ItemDescription = model.ItemDescription,
            ItemImg = model.ItemImg,
            ItemName = model.ItemName,
            ItemPrice = model.ItemPrice
        };

        _itemRepository.Add(ItemEntity);

        return ItemEntity;
    }

    public async void DeleteItem(Guid id)
    {
        var item = await _itemRepository.FirstOrDefault(x => x.Id == id);
        _itemRepository.Remove(item);
        _itemRepository.SaveChanges();

    }

    public async ValueTask<ItemEntity> GetItem(Guid id)
    {
        return  await _itemRepository.GetById(id);
    }

    public IEnumerable<ItemEntity> GetItems(Expression<Func<ItemEntity, bool>> predicate = null, Func<IQueryable<ItemEntity>, IOrderedQueryable<ItemEntity>> orderBy = null, string includeProperties = "")
    {
        return _itemRepository.GetAll();
    }

    public async Task<ItemEntity> UpdateItem(Guid id, ItemModel model)
    {
        var item = await _itemRepository.FirstOrDefault(x => x.Id == id);
        item.ItemImg = model.ItemImg;
        item.ItemDescription  = model.ItemDescription;
        item.ItemName = model.ItemName;
        item.ItemPrice = model.ItemPrice;
        item.ModifiedBy = model.ModifiedBy;
        item.ModifiedOn = model.ModifiedOn;

        _itemRepository.Update(item);
        _itemRepository.SaveChanges();

        return item;

    }
}