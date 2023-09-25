using AutoMapper;
using Contracts;
using MongoDB.Driver.Core.Operations;
using SearchService.Models;

namespace SearchService;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AuctionCreated, Item>();
        CreateMap<AuctionUpdated,Item>();
    }
}
