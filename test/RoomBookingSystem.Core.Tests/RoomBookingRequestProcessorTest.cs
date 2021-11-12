using Moq;
using RoomBookingSystem.Core.Domain;
using RoomBookingSystem.Core.Models;
using RoomBookingSystem.Core.Processors;
using RoomBookingSystem.Core.Services;
using System;
using Xunit;

namespace RoomBookingSystem.Core.Tests;

public class RoomBookingRequestProcessorTest
{
    private RoomBookingRequestProcessor _roomBookingRequestProcessor;
    private RoomBookingRequest _roomBookingRequest;
    private Mock<IRoomBookingService> _roomBookingServiceMock;

    public RoomBookingRequestProcessorTest()
    {
        _roomBookingRequest = new RoomBookingRequest()
        {
            FullName = "Armin Shoeibi",
            Email = "armin@gmail.com",
            CheckIn = new DateTime(2021, 11, 12, 12, 00, 00),
        };
        _roomBookingServiceMock = new Mock<IRoomBookingService>();
        _roomBookingRequestProcessor = new RoomBookingRequestProcessor(_roomBookingServiceMock.Object);
    }

    [Fact]
    public void Should_Return_Room_Booking_Response_With_Request_Values()
    {
        // Act
        RoomBookingResult roomBookingResponse = _roomBookingRequestProcessor.BookRoom(_roomBookingRequest);

        // Assert
        Assert.NotNull(roomBookingResponse);
        Assert.Equal(roomBookingResponse.CheckIn, _roomBookingRequest.CheckIn);
        Assert.Equal(roomBookingResponse.Email, _roomBookingRequest.Email);
        Assert.Equal(roomBookingResponse.FullName, _roomBookingRequest.FullName);
    }

    [Fact]
    public void Should_Throw_ArgumentNullException_For_Null_Request()
    {
        var argumentNullException = Assert.Throws<ArgumentNullException>(() => _roomBookingRequestProcessor.BookRoom(null));
        Assert.Equal("roomBookingRequest", argumentNullException.ParamName);
    }


    [Fact]
    public void Should_Create_Room_Booking_Request()
    {
        RoomBooking insertedRoomBooking = null;
        _roomBookingServiceMock.Setup(c => c.CreateRoomBooking(It.IsAny<RoomBooking>()))
                               .Callback<RoomBooking>(roomBooking =>
                               {
                                   insertedRoomBooking = roomBooking;
                               });

        RoomBookingResult roomBookingResponse = _roomBookingRequestProcessor.BookRoom(_roomBookingRequest);


        _roomBookingServiceMock.Verify(c => c.CreateRoomBooking(It.IsAny<RoomBooking>()), Times.Once);

        Assert.NotNull(insertedRoomBooking);
        Assert.Equal(insertedRoomBooking.CheckIn, roomBookingResponse.CheckIn);
        Assert.Equal(insertedRoomBooking.Email, roomBookingResponse.Email);
        Assert.Equal(insertedRoomBooking.FullName, roomBookingResponse.FullName);
    }

}
