using RoomBookingSystem.Core.Domain;

namespace RoomBookingSystem.Core.Services;

public interface IRoomBookingService
{
    void CreateRoomBooking(RoomBooking roomBooking);

    IEnumerable<Room> GetAvailableRooms(DateTime dateTime);
}
