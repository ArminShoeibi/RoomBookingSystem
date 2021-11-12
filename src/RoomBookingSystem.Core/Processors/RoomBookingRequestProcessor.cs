using RoomBookingSystem.Core.Domain;
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

    public RoomBookingResult BookRoom(RoomBookingRequest roomBookingRequest)
    {
        ArgumentNullException.ThrowIfNull(roomBookingRequest);

        _roomBookingService.CreateRoomBooking(CreateRoomBookingObject<RoomBooking>(roomBookingRequest));

        return CreateRoomBookingObject<RoomBookingResult>(roomBookingRequest);
    }

    private TRoomBooking CreateRoomBookingObject<TRoomBooking>(RoomBookingRequest roomBookingRequest)
        where TRoomBooking : RoomBookingBase, new()
    {
        return new TRoomBooking
        {
            CheckIn = roomBookingRequest.CheckIn,
            FullName = roomBookingRequest.FullName,
            Email = roomBookingRequest.Email,
        };
    }
}