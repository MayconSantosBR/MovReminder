using System;
using System.Collections.Generic;

namespace MovReminder.Data.Entities;

public partial class Gender
{
    public int IdGender { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}
