using System;
using System.Collections.Generic;

namespace MovReminder.Data.Entities;

public partial class Movie
{
    public int IdMovie { get; set; }

    public int IdDirector { get; set; }

    public int IdGender { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateOfShow { get; set; }

    public int Duration { get; set; }

    public int? Likes { get; set; }

    public virtual Director IdDirectorNavigation { get; set; } = null!;

    public virtual Gender IdGenderNavigation { get; set; } = null!;

    public virtual ICollection<WatchedMovie> WatchedMovies { get; } = new List<WatchedMovie>();
}
