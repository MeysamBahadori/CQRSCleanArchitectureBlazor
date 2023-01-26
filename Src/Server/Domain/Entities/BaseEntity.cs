﻿namespace Mc2.CrudTest.Domain.Entities;

public abstract class BaseEntity<TKey> : IEntity<TKey>
{
    public TKey Id { get; set; }
}

public abstract class BaseEntity : BaseEntity<Guid>
{
    
}