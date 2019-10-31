using System;
using MediaWorld.Domain.Models;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Singletons;
using MediaWorld.Domain.Factories;
using MediaWorld.Storing.Repositories;

namespace MediaWorld.Client
{
  /// <summary>
  /// Contains the start point
  /// </summary>
    internal class Program
    {
      /// <summary>
      /// Starts the application
      /// </summary>
        
        private static MediaRepository _repository = new MediaRepository();

    private static void Main()
        {
          Play();
        }

        private static void Play()
        {
          var mediaPlayer = MediaPlayerSingleton.Instance;

          foreach (var item in _repository.MediaLibrary)
          {
            mediaPlayer.Execute(item.Play, item);
          }
          // var audioFactory = new AudioFactory();
          // AMedia song = audioFactory.Create<Song>();
          // AMedia audible = new Movie();

          // mediaPlayer.Execute("play", song);
          // mediaPlayer.Execute("play", audible);
        }
    }
}
