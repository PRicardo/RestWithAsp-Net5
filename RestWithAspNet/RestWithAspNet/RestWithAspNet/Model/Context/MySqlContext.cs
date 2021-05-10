﻿using Microsoft.EntityFrameworkCore;

namespace RestWithAspNet.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(){}

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }


    }
}
