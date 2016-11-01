import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute }  from '@angular/router';
import { Room } from '../core/domain/room';
import { Paginated } from '../core/common/paginated';
import { DataService } from '../core/services/data.service';
import { UtilityService } from '../core/services/utility.service';
import { NotificationService } from '../core/services/notification.service';
import { OperationResult } from '../core/domain/operationResult';
import { Subscription }  from 'rxjs/Subscription';

@Component({
    selector: 'hotel-room',
    providers: [NotificationService],
    templateUrl: './app/components/hotel-rooms.component.html'
})
export class HotelRoomsComponent extends Paginated implements OnInit {
    private _hotelAPI: string = 'api/hotel/';
    private _roomsAPI: string = 'api/room/';
    private _hotelId: string;
    private _rooms: Array<Room>;
    private _displayingTotal: number;
    private _hotelTitle: string;
    private sub: Subscription;

    constructor(public dataService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService,
        private route: ActivatedRoute,
        private router: Router) {
        super(0, 0, 0);
    }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this._hotelId = params['id']; // (+) converts string 'id' to a number
            this._hotelAPI += this._hotelId + '/rooms/';
            this.dataService.set(this._hotelAPI, 12);
            this.gethotelRooms();
        });
    }

    gethotelRooms(): void {
        this.dataService.get(this._page)
            .subscribe(res => {

                var data: any = res.json();

                this._rooms = data.Items;
                this._displayingTotal = this._rooms.length;
                this._page = data.Page;
                this._pagesCount = data.TotalPages;
                this._totalCount = data.TotalCount;
                this._hotelTitle = this._rooms[0].Hotel;
            },
            error => {

                if (error.status == 401 || error.status == 302) {
                    this.utilityService.navigateToSignIn();
                }

                console.error('Error: ' + error)
            },
            () => console.log(this._rooms));
    }

    search(i): void {
        super.search(i);
        this.gethotelRooms();
    };

    convertDateTime(date: Date) {
        return this.utilityService.convertDateTime(date);
    }

    delete(room: Room) {
        var _removeResult: OperationResult = new OperationResult(false, '');

        this.notificationService.printConfirmationDialog('Are you sure you want to delete the room?',
            () => {
                this.dataService.deleteResource(this._roomsAPI + room.Id)
                    .subscribe(res => {
                        _removeResult.Succeeded = res.Succeeded;
                        _removeResult.Message = res.Message;
                    },
                    error => console.error('Error: ' + error),
                    () => {
                        if (_removeResult.Succeeded) {
                            this.notificationService.printSuccessMessage(room.Name + ' removed from collection.');
                            this.gethotelRooms();
                        }
                        else {
                            this.notificationService.printErrorMessage('Failed to remove room');
                        }
                    });
            });
    }
}