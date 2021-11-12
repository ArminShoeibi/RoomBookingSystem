using RoomBookingSystem.Core.Models;

namespace RoomBookingSystem.Core.Processors;

public class RoomBookingRequestProcessor
{
    public RoomBookingResponse BookRoom(RoomBookingRequest roomBookingRequest)
    {
        return new RoomBookingResponse
        {
            Request = roomBookingRequest,
        };
    }
}