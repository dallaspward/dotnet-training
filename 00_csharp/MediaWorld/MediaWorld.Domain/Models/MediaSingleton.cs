namespace MediaWorld.Domain.Models
{
  public class MediaPlayerSingleton
  {
    private static readonly MediaPlayerSingleton _instance = new MediaPlayerSingleton();

    private MediaPlayerSingleton()
    {
      
    }

    public static MediaPlayerSingleton GetInstance()
    {
      return _instance;
    }
  }
}