﻿using System;
using System.Collections.Generic;

namespace AdventuraClick.Service.Database;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime? DateOfBirth { get; set; }

    public string? CreatedAt { get; set; }

    public string? PasswordHash { get; set; }

    public string? PasswordSalt { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}