using System;

namespace MediaWorld.Domain.Models
{
  public abstract class Music
  {
    public string Artist { get; set; }

    public string Title { get; set; }

    public string Genre { get; set; }

    public TimeSpan Duration { get; set; }

    public Music()
    {
      Artist = "kanye west";
      Title = "diamonds are forever";
      Genre = "R&B";
      Duration = new TimeSpan(0,5,0);
    }

    public override string ToString()
    {
      return $"{Artist} {Title}";
    }
  }
}