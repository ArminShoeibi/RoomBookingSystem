using RoomBookingSystem.Core.Models;
using RoomBookingSystem.Core.Services;

namespace RoomBookingSystem.Core.Processors;

public class RoomBookingRequestProcessor
{
    private readonly IRoomBookingService _roomBookingService;

    public RoomBookingRequestProcessor(IRoomBookingService roomBookingService)
    {
        _roomBookingService = roomBookingService;
    }

    public RoomBookingResponse BookRoom(RoomBookingRequest roomBookingRequest)
    {
        ArgumentNullException.ThrowIfNull(roomBookingRequest);
        return new RoomBookingResponse
        {
            Request = roomBookingRequest,
        };
    }
}