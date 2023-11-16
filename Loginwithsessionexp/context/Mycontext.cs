using Loginwithsessionexp.Models.entity;
using Microsoft.EntityFrameworkCore;

namespace Loginwithsessionexp.context;

public class MyContext:DbContext
{
    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }

    public DbSet<User> user { get; set; }
}