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
          var helper = MediaPlayerSingleton.GetInstance();
          // var helper2 = new MediaSingleton();
          System.Console.WriteLine(helper);
        }

        private static void DisplayMusic()
        {
          Music m = new Song();
          m.Artist;
        }
    }
}
