namespace MediaWorld.Domain.Interfaces
{
  public interface IPlayer : IVolume
  {
    bool PowerUp();
    bool PowerDown();
  }
}