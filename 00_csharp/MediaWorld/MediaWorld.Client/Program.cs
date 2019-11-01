using System;
using MediaWorld.Domain.Models;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Singletons;
using MediaWorld.Domain.Factories;
using MediaWorld.Storing.Repositories;
using Serilog;
using System.Threading;
using System.Threading.Tasks;

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

    private static async void Main()
        {
          //should start logger at the beginning of program
          var program = new Program(); //must do this because main is static, either make ApplicationStart static (which requires anything that uses it to be static) or make a program object as <---
          program.ApplicationStart();

          Play();

          //MagicAsync().GetAwaiter().GetResult();
          //Console.WriteLine("end of code");
          Log.Warning("end of main method");
        }

        private void ApplicationStart()
        {
          Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Debug()
          .WriteTo.Console()
          .WriteTo.File("log.txt")
          .CreateLogger();
        }

        private static void Play()
        {
          Log.Information("Play Method");
          var mediaPlayer = MediaPlayerSingleton.Instance;

          foreach (var item in _repository.MediaLibrary)
          {
            Log.Debug("{@item}", item.Title); //the @ gives the actual object and not the string representation of the object, a structured log
            mediaPlayer.Execute(item.Play, item);
          }
          // var audioFactory = new AudioFactory();
          // AMedia song = audioFactory.Create<Song>();
          // AMedia audible = new Movie();

          // mediaPlayer.Execute("play", song);
          // mediaPlayer.Execute("play", audible);
        }

        // private static void MagicThread()
        // {
        //   var t1 = new Thread(() => {Run("A");});
        //   var t2 = new Thread(() => {Run("B");});

        //   t1.Start();
        //   t2.Start();

        //   t1.Join();
        //   t2.Join();
        // }

        // private static async Task MagicAsync()
        // {
        //   await Task.Run(() => {Run("C");});
        // }

        // private static void Run(string s)
        // {
        //     for(var x = 0; x < 100; x++)
        //     {
        //       Console.Write(s);
        //     }
        // }

        // private static void MagicTask()
        // {
        //   var t1 = new Task(() => {Run("A");});
        //   var t2 = new Task(() => {Run("B");});

        //   t1.Start();
        //   t2.Start();

        //   Task.WaitAll(new Task[]{t1, t2}, 1000);
        // }
    }
}
