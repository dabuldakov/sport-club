using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.CookiePolicy;
using Moq;
using SportClubApi;
using SportClubApi.Interface;
using SportClubApi.Models;
using SportClubApi.Models.Registry;
using SportClubApi.Service;
using Xunit;

public class RegistryClubServiceTests
{
    private readonly Mock<IMembershipRepository> _membershipRepositoryMock = new();
    private readonly Mock<IExclusionRepository> _exclusionRepositoryMock = new();
    private readonly Mock<IRegistryClubRepository> _registryClubRepositoryMock = new();
    private readonly Mock<IAthletRepository> _athletRepositoryMock = new();
    private readonly Mock<IClubRepository> _clubRepositoryMock = new();
    private readonly RegistryClubService _service;

    public RegistryClubServiceTests()
    {
        _service = new RegistryClubService(
            _membershipRepositoryMock.Object,
            _exclusionRepositoryMock.Object,
            _registryClubRepositoryMock.Object,
            _athletRepositoryMock.Object,
            _clubRepositoryMock.Object
        );
    }

    [Fact]
    public async Task SaveMembershipDocument_ShouldThrowException_WhenAthletAlreadyInClub()
    {
        // Arrange
        var document = CreateTestMembershipDocument();
        _registryClubRepositoryMock
            .Setup(repo => repo.GetByAthletIdFirstAsync(document.AthletID))
            .ReturnsAsync(new RegistryClub { AthletID = 1, ClubID = 1, CreateDate = DateTime.Now });

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentException>(() => _service.SaveMembershipDocument(document));
    }

    [Fact]
    public async Task SaveMembershipDocument_ShouldSave_WhenAthletNotInClub()
    {
        // Arrange
        var document = CreateTestMembershipDocument();
        _registryClubRepositoryMock
            .Setup(repo => repo.GetByAthletIdFirstAsync(document.AthletID))
            .ReturnsAsync((RegistryClub?)null);

        _athletRepositoryMock
        .Setup(repo => repo.ExistAthletByIdAsync(document.AthletID))
        .ReturnsAsync(true);

        _clubRepositoryMock
        .Setup(repo => repo.ExistClubByIdAsync(document.ClubID))
        .ReturnsAsync(true);

        // Act
        var result = await _service.SaveMembershipDocument(document);

        // Assert
        Assert.Equal(document, result);
        _membershipRepositoryMock.Verify(repo => repo.SaveAsync(document), Times.Once);
        _registryClubRepositoryMock.Verify(repo => repo.SaveAsync(It.IsAny<RegistryClub>()), Times.Once);
    }

    [Fact]
    public async Task SaveExclusionDocument_ShouldThrowException_WhenAthletNotInClub()
    {
        // Arrange
        var document = CreateTestExclusionDocument();
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
        var document = CreateTestExclusionDocument();
        var registryClub = new RegistryClub { AthletID = 1, ClubID = 1, CreateDate = DateTime.Now };
        _registryClubRepositoryMock
            .Setup(repo => repo.GetByAthletIdFirstAsync(document.AthletID))
            .ReturnsAsync(registryClub);

        _athletRepositoryMock
        .Setup(repo => repo.ExistAthletByIdAsync(document.AthletID))
        .ReturnsAsync(true);

        _clubRepositoryMock
        .Setup(repo => repo.ExistClubByIdAsync(document.ClubID))
        .ReturnsAsync(true);

        // Act
        var result = await _service.SaveExclusionDocument(document);

        // Assert
        Assert.Equal(document, result);
        _exclusionRepositoryMock.Verify(repo => repo.SaveAsync(document), Times.Once);
        _registryClubRepositoryMock.Verify(repo => repo.DeleteAsync(registryClub), Times.Once);
    }

    [Fact]
    public async Task GetAthletsInClub_ShouldReturnAthlets()
    {
        // Arrange
        var clubId = 1L;
        var athlets = new List<Athlet> { CreateAthlet(1), CreateAthlet(2) };
        _registryClubRepositoryMock
            .Setup(repo => repo.GetAthletsByClubIdAsync(clubId))
            .ReturnsAsync(athlets);

        // Act
        var result = await _service.GetAthletsInClub(clubId);

        // Assert
        Assert.Equal(athlets, result);
    }

    private static Athlet CreateAthlet(long id)
    {
        return new Athlet
        {
            ID = id,
            Fio = "Fio",
            SportTypeID = 1,
            ExpirenceWorkDays = 15
        };
    }

    private static MembershipDocument CreateTestMembershipDocument()
    {
        return new MembershipDocument
        {
            AthletID = 1,
            ClubID = 1,
            Date = DateTime.Now,
            Number = "test number",
            CreatorId = 1,
            Comment = "test comment"
        };
    }

    private static ExclusionDocument CreateTestExclusionDocument()
    {
        return new ExclusionDocument
        {
            AthletID = 1,
            ClubID = 1,
            Date = DateTime.Now,
            Number = "test number",
            CreatorId = 1,
            Comment = "test comment"
        };
    }
}