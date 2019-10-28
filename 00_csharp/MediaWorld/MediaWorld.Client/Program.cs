using System;
using MediaWorld.Domain.Models;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Singletons;

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
          var mediaPlayer = MediaPlayerSingleton.Instance;
          AMedia song = new Song();
          AMedia audible = new Movie();

          mediaPlayer.Execute("play", song);
          mediaPlayer.Execute("play", audible);
        }
    }
}
