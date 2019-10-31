namespace MediaWorld.Domain.Abstracts
{
  public abstract class AAudio : AMedia
  {
    public int BitRate { get; set; }

    public override bool Forward()
    {
      return true;
    }

    // public override bool Play()
    // {
    //   return true;
    // }

    public override bool Rewind()
    {
      return true;
    }

    public new bool Stop()
    {
      return true;
    }

    public override string ToString()
    {
      return $"{Title} {Duration}\nBitRate: {BitRate}";
    }
  }
}