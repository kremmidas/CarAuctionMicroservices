using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService;

public class AuctionDeletedConsumer : IConsumer<AuctionCreated>
{
    private readonly IMapper _mapper;
    public AuctionDeletedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<AuctionCreated> context)
    {
        Console.WriteLine("Consuming auction deleted:" + context.Message.Id);

        var result = await DB.DeleteAsync<Item>(context.Message.Id.ToString());

        if(!result.IsAcknowledged){
            throw new MessageException(typeof(AuctionDeleted),"Problem deleting auction");
        }
}}
