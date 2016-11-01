import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home.component';
import { RoomsComponent } from './components/room.component';
import { HotelComponent } from './components/hotel.component';
import { HotelRoomsComponent } from './components/hotel-rooms.component';


const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/home',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'rooms',
        component: RoomsComponent
    },
    {
        path: 'hotel',
        component: HotelComponent
    },
    {
        path: 'hotel/:id/rooms',
        component: HotelRoomsComponent
    },
    {
        path: 'ebooks',
        redirectTo: '/ebooks'
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);