﻿namespace InkWellReads.Books.Domain.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
