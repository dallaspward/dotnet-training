using System;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Interfaces;

namespace MediaWorld.Domain.Singletons
{
  /// <summary>
  /// contains the singleton pattern
  /// </summary>
  public class MediaPlayerSingleton : IPlayer
  {
    private static readonly MediaPlayerSingleton _instance = new MediaPlayerSingleton();

    public static MediaPlayerSingleton Instance
    {
      get
      {
        return _instance;
      }
    }

    private MediaPlayerSingleton()
    {

    }
    
    public void Execute(string command, AMedia media)
    {
      Console.WriteLine(media);
    }
  }
}