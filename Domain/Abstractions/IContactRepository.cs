﻿using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IContactRepository : IRepository<Contact>
    {
        IList<Contact> FilterByRegion(string Ddd);
    }
}
