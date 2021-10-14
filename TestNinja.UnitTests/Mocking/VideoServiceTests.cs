using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
	[TestFixture]
	public class VideoServiceTests
	{
		private Mock<IFileReader> _fileReader;
		private Mock<IVideoRepository> _videoRepository;
		private VideoService _videoService;

		[SetUp]
		public void SetUp()
		{
			_fileReader = new Mock<IFileReader>();
			_videoRepository = new Mock<IVideoRepository>();
			_videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
		}

		[Test]
		public void ReadVideoTitle_EmptyFile_ReturnError()
		{
			_fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

			var result = _videoService.ReadVideoTitle();

			Assert.That(result, Does.Contain("error").IgnoreCase);
		}

		[Test]
		public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnEmptyString()
		{
			_videoRepository.Setup(k => k.GetUnprocessedVideos()).Returns(new List<Video>());

			var result = _videoService.GetUnprocessedVideosAsCsv();

			Assert.That(result, Is.EqualTo(""));
		}

		[Test]
		public void GetUnprocessedVideosAsCsv_SomeUnprocessedVideos_ReturnStringWithIds()
		{
			_videoRepository.Setup(k => k.GetUnprocessedVideos()).Returns(new List<Video>()
			{ 
				new Video { Id = 1, IsProcessed = false },
				new Video { Id = 3, IsProcessed = false },
				new Video { Id = 4, IsProcessed = false }
			});

			var result = _videoService.GetUnprocessedVideosAsCsv();

			Assert.That(result, Is.EqualTo("1,3,4"));
		}
	}
}
