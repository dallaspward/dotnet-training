using MediaWorld.Domain.Interfaces;

namespace MediaWorld.Domain.Singletons
{
  /// <summary>
  /// contains the singleton pattern
  /// </summary>

  public class AudioPlayerSingleton : IPlayer
  {
    public bool PowerDown()
    {
      throw new System.NotImplementedException();
    }

    public bool PowerUp()
    {
      throw new System.NotImplementedException();
    }

    public bool VolumeDown()
    {
      throw new System.NotImplementedException();
    }

    public bool VolumeMute()
    {
      throw new System.NotImplementedException();
    }

    public bool VolumeUp()
    {
      throw new System.NotImplementedException();
    }
  }
}