using System;

namespace RoomBookingSystem.Core.Models;

public class RoomBookingRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime CheckIn { get; set; }
}