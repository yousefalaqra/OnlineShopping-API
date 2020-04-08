using System;


public interface IEntity : ITrackbleEntity
{
    public Guid Id { get; set; }
}