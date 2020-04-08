using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public interface IItemManager
{
    /// <summary>
    /// Get all the items
    ///</summary>
    /// <param name="predicate"> filtet the data</param>
    /// <param name="orderBy"> Order by</param>
    /// <param name="includeProperties"> INnclides</param>
    /// <returns>List of Itesm</returns>
    IEnumerable<ItemEntity> GetItems(
        Expression<Func<ItemEntity, bool>> predicate = null,
        Func<IQueryable<ItemEntity>,IOrderedQueryable<ItemEntity>> orderBy = null,
        string includeProperties = ""
    );

    /// <summary>
    /// Get all the items
    ///</summary>
    /// <param name="id">item id</param>
    /// <returns>item entity</returns>
    ValueTask<ItemEntity> GetItem(Guid id);

    /// <summary>
    /// Update item 
    ///</summary>
    /// <param name="id">item id</param>
    /// <param name="model">item model</param>
    /// <returns>item entity</returns>
    Task<ItemEntity> UpdateItem(Guid id, ItemModel model);

    /// <summary>
    /// Insert Item
    ///</summary>
    /// <param name="model">item model</param>
    /// <returns>item entity</returns>
    ItemEntity AddItem(ItemModel model);

    /// <summary>
    /// Insert Item
    ///</summary>
    /// <param name="id">item id</param>
    /// <returns>item entity</returns>
    void DeleteItem(Guid id);


}