using System;
using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Models
{
  public class Song : AAudio
  {
    public Song()
    {
      Initialize();
    }

    Song(string title, TimeSpan duration, int bitRate)
    {
      Initialize(title, duration, bitRate);
    }

    private void Initialize(string title="Untitled", TimeSpan duration=new TimeSpan(), int bitRate=256)
    {
      Title = title;
      Duration = duration;
      BitRate = bitRate;
    }
  }
}