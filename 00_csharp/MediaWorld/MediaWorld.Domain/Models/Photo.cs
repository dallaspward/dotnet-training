using MediaWorld.Domain.Abstracts;
using System;

namespace MediaWorld.Domain.Models
{
  public class Photo : AVideo
  {
    public Photo()
    {
      Initialize();
    }

    Photo(string title, TimeSpan duration, int frameRate)
    {
      Initialize(title, duration, frameRate);
    }

    private void Initialize(string title="untitled", TimeSpan duration=new TimeSpan(), int framerate=60)
    {
      Title = title;
      Duration = duration;
      FrameRate = FrameRate;
    }
  }
}