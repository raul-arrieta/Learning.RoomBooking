/// <reference path="../../typings/globals/es6-shim/index.d.ts" />

import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import 'rxjs/add/operator/map';
import {enableProdMode} from '@angular/core';

enableProdMode();

@Component({
    selector: 'roombooking-app',
    templateUrl: './app/app.component.html'
})
export class AppComponent implements OnInit {

    constructor(public location: Location) { }

    ngOnInit() {
        this.location.go('/');
    }
}