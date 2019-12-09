//using MediaWorld.Domain.Abstracts;
using System;

namespace MediaWorld.Domain.Models
{
  public class Book : AAudio
  {
    public Book()
    {
      Initialize();
    }

    Book(string title, TimeSpan duration, int bitRate)
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