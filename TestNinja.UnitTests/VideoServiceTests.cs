using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _videoRepository;
        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _videoRepository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _videoRepository.Object);
        }


        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            //Act
            var result = _videoService.ReadVideoTitle();

            //Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);

        }

        [Test]
        public void GetUnProcessedVideosAsCsv_AllVideosAreProcesses_ReturnsEmptyString()
        {
            //Arrange
            _videoRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            //Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            //Assert
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnProcessedVideosAsCsv_FewUnProcessesVideos_ReturnsAStringWithIdOFUnprocessesVideos()
        {
            //Arrange
            _videoRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video {Id = 1},
                new Video {Id = 2},
                new Video {Id = 3}
            });

            //Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            //Assert
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
