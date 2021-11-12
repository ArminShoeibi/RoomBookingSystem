using System;

namespace RoomBookingSystem.Core.Tests;

public class RoomBookingRequestProcessor
{
    public RoomBookingResponse BookRoom(RoomBookingRequest roomBookingRequest)
    {
        return new RoomBookingResponse
        {
            CheckIn = roomBookingRequest.CheckIn,
            Email = roomBookingRequest.Email,
            FullName = roomBookingRequest.FullName,
        };
    }
}