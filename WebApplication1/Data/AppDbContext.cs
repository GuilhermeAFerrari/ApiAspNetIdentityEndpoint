﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    // Customize Identity
}
