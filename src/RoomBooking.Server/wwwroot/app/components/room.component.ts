import { Component, OnInit } from '@angular/core';
import { Room } from '../core/domain/room';
import { Paginated } from '../core/common/paginated';
import { DataService } from '../core/services/data.service';

@Component({
    selector: 'rooms',
    templateUrl: './app/components/room.component.html'
})
export class RoomsComponent extends Paginated implements OnInit {
    private _roomsAPI: string = 'api/room/';
    private _rooms: Array<Room>;

    constructor(public roomsService: DataService) {
        super(0, 0, 0);
    }

    ngOnInit() {
        this.roomsService.set(this._roomsAPI, 12);
        this.getRooms();
    }

    getRooms(): void {
        let self = this;
        self.roomsService.get(self._page)
            .subscribe(res => {

                var data: any = res.json();

                self._rooms = data.Items;
                self._page = data.Page;
                self._pagesCount = data.TotalPages;
                self._totalCount = data.TotalCount;
            },
            error => console.error('Error: ' + error));
    }

    search(i): void {
        super.search(i);
        this.getRooms();
    };
}