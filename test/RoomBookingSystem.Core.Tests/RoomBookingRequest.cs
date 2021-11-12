using System;

namespace RoomBookingSystem.Core.Tests;

public class RoomBookingRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime CheckIn { get; set; }
}