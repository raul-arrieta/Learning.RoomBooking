export class Hotel {
    Id: string;
    Name: string;
    Address: string;
    TotalRooms: number;
    TotalRoomReservations: number;

    constructor(id: string,
        name: string,
        address: string,
        totalrooms: number,
        totalroomreservations: number) {
        this.Id = id;
        this.Name = name;
        this.Address = address;
        this.TotalRooms = totalrooms;
        this.TotalRoomReservations = totalroomreservations;
    }
}