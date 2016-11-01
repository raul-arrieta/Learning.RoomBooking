export class RoomReservation {
    Id: string;
    ClientName: string;
    StartDate: Date;
    EndDate: Date;
    Room: string;
    RoomId: string;
    Hotel: string;
    HotelId: string;

    constructor(id: string,
        clientname: string,
        startdate: Date,
        enddate: Date,
        room: string,
        roomid: string,
        hotel: string,
        hotelid: string
    ) {
        this.Id = id;
        this.ClientName = clientname;
        this.StartDate = startdate;
        this.EndDate = enddate;
        this.Room = room;
        this.Hotel = hotel;
        this.RoomId = roomid;
    }
}