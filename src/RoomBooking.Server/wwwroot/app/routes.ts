import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './components/home.component';
import { RoomsComponent } from './components/room.component';
import { HotelComponent } from './components/hotel.component';
import { HotelRoomsComponent } from './components/hotel-rooms.component';


const appRoutes: Routes = [
    {
        path: '',
        redirectTo: '/hotel',
        pathMatch: 'full'
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'room',
        component: RoomsComponent
    },
    {
        path: 'rooms',
        component: RoomsComponent
    },
    {
        path: 'hotels',
        component: HotelComponent
    },
    {
        path: 'hotel',
        component: HotelComponent
    },
    {
        path: 'hotel/:id/rooms',
        component: HotelRoomsComponent
    }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);