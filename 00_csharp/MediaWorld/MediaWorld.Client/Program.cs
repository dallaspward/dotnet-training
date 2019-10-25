using System;
using MediaWorld.Domain.Models;

namespace MediaWorld.Client
{
  /// <summary>
  /// Contains the start point
  /// </summary>
    class Program
    {
      /// <summary>
      /// Starts the application
      /// </summary>
        private static void Main()
        {
          Play();
        }

        private static void Play()
        {
          var mediaPlayer = MediaPlayerSingleton.GetInstance();
          Music s = new Song();
          Music a = new Audible();

          mediaPlayer.Play(s);
          mediaPlayer.Play(a);
        }
    }
}
