using System;
using System.Collections.Generic;

namespace MovReminder.Data.Entities;

public partial class User
{
    public int IdUser { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<WatchedMovie> WatchedMovies { get; } = new List<WatchedMovie>();
}
