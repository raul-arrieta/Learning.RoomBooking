import { Component, OnInit } from '@angular/core';
import { Hotel } from '../core/domain/hotel';
import { Paginated } from '../core/common/paginated';
import { DataService } from '../core/services/data.service';
import { UtilityService } from '../core/services/utility.service';
import { NotificationService } from '../core/services/notification.service';

@Component({
    selector: 'hotels',
    templateUrl: './app/components/hotel.component.html'
})
export class HotelComponent extends Paginated implements OnInit {
    private _hotelsAPI: string = 'api/hotel/';
    private _hotels: Array<Hotel>;

    constructor(public hotelService: DataService,
        public utilityService: UtilityService,
        public notificationService: NotificationService) {
        super(0, 0, 0);
    }

    ngOnInit() {
        this.hotelService.set(this._hotelsAPI, 3);
        this.gethotels();
    }

    gethotels(): void {
        this.hotelService.get(this._page)
            .subscribe(res => {
                var data: any = res.json();
                this._hotels = data.Items;
                this._page = data.Page;
                this._pagesCount = data.TotalPages;
                this._totalCount = data.TotalCount;
            },
            error => {

                if (error.status == 401 || error.status == 404) {
                    this.notificationService.printErrorMessage('Authentication required');
                    this.utilityService.navigateToSignIn();
                }
            });
    }

    search(i): void {
        super.search(i);
        this.gethotels();
    };
}