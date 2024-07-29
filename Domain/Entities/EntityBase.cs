﻿namespace Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        protected EntityBase()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
