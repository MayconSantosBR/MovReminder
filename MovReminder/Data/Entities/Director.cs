using System;
using System.Collections.Generic;

namespace MovReminder.Data.Entities;

public partial class Director
{
    public int IdDirector { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Birthdate { get; set; }

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
