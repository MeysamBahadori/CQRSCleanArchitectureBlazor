﻿namespace Mc2.CrudTest.Domain.Entities;

public interface IEntity
{ }

public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }
}
