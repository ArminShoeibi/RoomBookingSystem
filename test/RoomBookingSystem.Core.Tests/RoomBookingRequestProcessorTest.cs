using System;
using Xunit;

namespace RoomBookingSystem.Core.Tests;

public class RoomBookingRequestProcessorTest
{
    [Fact]
    public void Should_Return_Room_Booking_Response_With_Request_Values()
    {
        // Arrange
        RoomBookingRequest roomBookingRequest = new RoomBookingRequest()
        {
            FullName = "Armin Shoeibi",
            Email = "armin@gmail.com",
            CheckIn = new DateTime(2021, 11, 12, 12, 00, 00),
        };
        RoomBookingRequestProcessor processor = new();

        // Act
        RoomBookingResponse roomBookingResponse = processor.BookRoom(roomBookingRequest);

        // Assert
        Assert.NotNull(roomBookingResponse);
        Assert.Equal(roomBookingResponse.)
    }

}
