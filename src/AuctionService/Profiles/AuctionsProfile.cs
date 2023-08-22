﻿using AuctionServic.Dtos;
using AuctionService.Dtos;
using AuctionService.Models;
using AutoMapper;

namespace AuctionService;

public class AuctionsProfile : Profile
{
    public AuctionsProfile()
    {
        CreateMap<Auction, AuctionDto>().IncludeMembers(x => x.Item);
        CreateMap<Item, AuctionDto>();
        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(x => x.Item, o => o.MapFrom(s => s));
        CreateMap<CreateAuctionDto, Item>();
    }
}
