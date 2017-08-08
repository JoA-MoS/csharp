import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
// import { HomeComponent } from './components/home/home.component';
import { Dojodatchi } from './components/dojodatchi/dojodatchi.component'
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
// import { CounterComponent } from './components/counter/counter.component';

export const sharedConfig: NgModule = {
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        Dojodatchi,
        FetchDataComponent,
        // HomeComponent
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: Dojodatchi },
            // { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
};
