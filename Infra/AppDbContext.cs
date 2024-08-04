﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options)
        : base(options)
    {
    }
    
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Authentication> Authentications { get; set; }
    public DbSet<User> Users { get; set; }
}