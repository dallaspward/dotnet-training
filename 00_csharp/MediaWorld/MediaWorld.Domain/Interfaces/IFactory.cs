using MediaWorld.Domain.Abstracts;

namespace MediaWorld.Domain.Interface
{
  public interface IFactory
  {
    AMedia Create<T>() where T : AMedia, new();
  }
}