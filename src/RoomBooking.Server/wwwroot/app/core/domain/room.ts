export class Room {
    Id: string;
    Name: string;
    RoomType: string;
    Hotel: string;
    HotelId: string;

    constructor(id: string,
        name: string,
        roomtype: string,
        hotel: string,
        hotelid: string
    ) {
        this.Id = id;
        this.Name = name;
        this.RoomType = roomtype;
        this.Hotel = hotel;
        this.HotelId = hotelid;
    }
}