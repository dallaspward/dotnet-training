using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Interface;

namespace MediaWorld.Domain.Factories
{
  public class VideoFactory : IFactory
  {
    public AMedia Create<T>() where T : AMedia, new()
    {
      return new T() as AMedia;
      //switch (type)
      //{
      //  case "book":
      //    return new Book();
      //  case "song":
      //    return new Song();
      //  default:
      //    return null;
      //}
    }
  }
}