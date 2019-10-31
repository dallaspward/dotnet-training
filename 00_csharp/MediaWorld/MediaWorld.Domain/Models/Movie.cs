using MediaWorld.Domain.Abstracts;
using System;

namespace MediaWorld.Domain.Models
{
  public class Movie : AVideo
  {
    public Movie()
    {
      Initialize();
    }

    public Movie(string title, TimeSpan duration, int frameRate)
    {
      Initialize(title, duration, frameRate);
    }

    private void Initialize(string title="Untitled", TimeSpan duration=new TimeSpan(), int frameRate=24)
    {
      Title = title;
      Duration = duration;
      FrameRate = frameRate;
    }
  }
}