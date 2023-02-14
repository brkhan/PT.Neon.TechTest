using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlayTech.Neon.PremierLeague.Controllers;
using PlayTech.Neon.PremierLeague.Domain.Services;

namespace PlayTech.Neon.PremierLeague.UnitTests.Controllers
{
    [TestClass]
    public class PlayerSelectionControllerTests
    {
        private Mock<IPlayerSelectionService> _mockPlayerSelectionService;
        private PlayerSelectionController _controller;

        [TestInitialize]
        public void Initialize()
        {
            _mockPlayerSelectionService = new Mock<IPlayerSelectionService>();
            
            _controller = new PlayerSelectionController(new Mock<ILogger<PlayerSelectionController>>().Object, _mockPlayerSelectionService.Object);
        }

        [TestMethod]
        public async Task Given_GetUserPlayers_ThenPlayersAreReturned()
        {
            // Arrange
            
            // Act
            var result = await _controller.GetUserPlayers("abc");

            // Assert
            Assert.AreEqual(result.GetType(), typeof(ObjectResult));
            _mockPlayerSelectionService.Verify(a => a.GetPlayersForUser("abc"));

        }
    }
}
