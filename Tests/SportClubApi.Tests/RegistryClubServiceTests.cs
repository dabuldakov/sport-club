using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using SportClubApi.Models;
using SportClubApi.Models.Registry;
using SportClubApi.Repositoory;
using SportClubApi.Service;
using Xunit;

public class RegistryClubServiceTests
{
    private readonly Mock<MembershipRepository> _membershipRepositoryMock = new();
    private readonly Mock<ExcclusionRepository> _exclusionRepositoryMock = new();
    private readonly Mock<RegistryClubRepository> _registryClubRepositoryMock = new();
    private readonly RegistryClubService _service;

    public RegistryClubServiceTests()
    {
        _service = new RegistryClubService(
            _membershipRepositoryMock.Object,
            _exclusionRepositoryMock.Object,
            _registryClubRepositoryMock.Object
        );
    }

    [Fact]
    public async Task SaveMembershipDocument_ShouldThrowException_WhenAthletAlreadyInClub()
    {
        // Arrange
        var document = new MembershipDocument { AthletID = 1, ClubID = 1 };
        _registryClubRepositoryMock
            .Setup(repo => repo.GetByAthletIdFirstAsync(document.AthletID))
            .ReturnsAsync(new RegistryClub());

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _service.SaveMembershipDocument(document));
    }

    [Fact]
    public async Task SaveMembershipDocument_ShouldSave_WhenAthletNotInClub()
    {
        // Arrange
        var document = new MembershipDocument { AthletID = 1, ClubID = 1 };
        _registryClubRepositoryMock
            .Setup(repo => repo.GetByAthletIdFirstAsync(document.AthletID))
            .ReturnsAsync((RegistryClub?)null);

        // Act
        var result = await _service.SaveMembershipDocument(document);

        // Assert
        Assert.Equal(document, result);
        _membershipRepositoryMock.Verify(repo => repo.Save(document), Times.Once);
        _registryClubRepositoryMock.Verify(repo => repo.Save(It.IsAny<RegistryClub>()), Times.Once);
    }

    [Fact]
    public async Task SaveExclusionDocument_ShouldThrowException_WhenAthletNotInClub()
    {
        // Arrange
        var document = new ExclusionDocument { AthletID = 1 };
        _registryClubRepositoryMock
            .Setup(repo => repo.GetByAthletIdFirstAsync(document.AthletID))
            .ReturnsAsync((RegistryClub?)null);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _service.SaveExclusionDocument(document));
    }

    [Fact]
    public async Task SaveExclusionDocument_ShouldSave_WhenAthletInClub()
    {
        // Arrange
        var document = new ExclusionDocument { AthletID = 1 };
        var registryClub = new RegistryClub { AthletID = 1, ClubID = 1 };
        _registryClubRepositoryMock
            .Setup(repo => repo.GetByAthletIdFirstAsync(document.AthletID))
            .ReturnsAsync(registryClub);

        // Act
        var result = await _service.SaveExclusionDocument(document);

        // Assert
        Assert.Equal(document, result);
        _exclusionRepositoryMock.Verify(repo => repo.Save(document), Times.Once);
        _registryClubRepositoryMock.Verify(repo => repo.Delete(registryClub), Times.Once);
    }

    [Fact]
    public async Task GetAthletsInClub_ShouldReturnAthlets()
    {
        // Arrange
        var clubId = 1L;
        var athlets = new List<Athlet> { new Athlet { ID = 1 }, new Athlet { ID = 2 } };
        _registryClubRepositoryMock
            .Setup(repo => repo.GetAthletsByClubIdAsync(clubId))
            .ReturnsAsync(athlets);

        // Act
        var result = await _service.GetAthletsInClub(clubId);

        // Assert
        Assert.Equal(athlets, result);
    }
}