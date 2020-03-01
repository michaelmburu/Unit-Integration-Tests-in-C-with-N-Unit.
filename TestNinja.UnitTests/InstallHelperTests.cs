using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class InstallHelperTests
    {
        private Mock<IFileDownloader> _filedownloader;
        private InstallerHelper _installHelper;
        [SetUp]
        public void SetUp()
        {
            _filedownloader = new Mock<IFileDownloader>();
            _installHelper = new InstallerHelper(_filedownloader.Object);
        }

        [Test]
        public void DownloadInstaller_IfDownloadFileExists_ReturnTrue()
        {
            //Arrange
            _filedownloader.Setup(r => r.DownloadFile("", ""));

            //Act
            var result = _installHelper.DownloadInstaller("", "");

            //Assert
            Assert.That(result == true);
        }

        [Test]
        public void DownloadInstaller_ThrowWebException_ReturnsFalse()
        {
            //Arrange
            _filedownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
            //Act
            var result = _installHelper.DownloadInstaller("customer", "installer");

            //Assert
            Assert.That(result, Is.False);
        }
    }
}
