using System;
using MediaWorld.Domain.Abstracts;
using MediaWorld.Domain.Factories;
using MediaWorld.Domain.Models;
using MediaWorld.Domain.Singletons;
using Moq;
using Xunit;

namespace MediaWorld.Testing.Specs
{
  public class MediaSpec
  {
    AudioFactory af = new AudioFactory();
    VideoFactory vf = new VideoFactory();

    Mock <AMedia> mock;

    public MediaSpec()
    {
      mock = new Mock<AMedia>();
      mock.Setup(am => am.Play()).Returns(false);
    }

    [Fact] //this should run before Test_AudioObject
    public void Test_AudioObject()
    {
      //arrange
      var sut = af; //sut = subject under test
      var expected = typeof(Song);

      //act
      var actual = af.Create<Song>() as Song;

      //assert
      Assert.True(expected == actual.GetType());
    }

    [Fact]
    public void Test_VideoObject()
    {
      //arrange 
      var sut = vf;
      var expected = typeof(Movie);

      //act
      var actual = vf.Create<Movie>() as Movie;

      //assert
      Assert.True(expected == actual.GetType());
    }

    public void Test_VideoPlay()
    {
      var sut = MediaPlayerSingleton.Instance;
      var mm = mock.Object;

      

      //Assert.True(sut.Execute(mm.Play, mm));
    }
  }
}