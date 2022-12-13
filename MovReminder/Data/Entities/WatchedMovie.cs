using System;
using System.Collections.Generic;

namespace MovReminder.Data.Entities;

public partial class WatchedMovie
{
    public int IdMovie { get; set; }

    public int IdUser { get; set; }

    public DateTime Date { get; set; }

    public bool? Liked { get; set; }

    public virtual Movie IdMovieNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
