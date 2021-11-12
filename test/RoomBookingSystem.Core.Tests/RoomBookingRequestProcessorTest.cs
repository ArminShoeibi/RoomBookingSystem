using RoomBookingSystem.Core.Models;
using RoomBookingSystem.Core.Processors;
using System;
using Xunit;

namespace RoomBookingSystem.Core.Tests;

public class RoomBookingRequestProcessorTest
{
    private RoomBookingRequestProcessor _roomBookingRequestProcessor;

    public RoomBookingRequestProcessorTest()
    {
        _roomBookingRequestProcessor = new RoomBookingRequestProcessor();
    }

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
     
        // Act
        RoomBookingResponse roomBookingResponse = _roomBookingRequestProcessor.BookRoom(roomBookingRequest);

        // Assert
        Assert.NotNull(roomBookingResponse);
        Assert.Equal(roomBookingResponse.Request, roomBookingRequest);
    }

    [Fact]
    public void Should_Throw_ArgumentNullException_For_Null_Request()
    {
        var argumentNullException = Assert.Throws<ArgumentNullException>(() => _roomBookingRequestProcessor.BookRoom(null));
        Assert.Equal("roomBookingRequest", argumentNullException.ParamName);
    }
}
