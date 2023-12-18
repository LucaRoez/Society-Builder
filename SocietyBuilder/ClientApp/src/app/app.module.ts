import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NavOptionsComponent } from './nav-options/nav-options.component'
import { HomeComponent } from './home/home.component';
import { NewGameComponent } from './new-game/new-game.component';
import { LoadGameComponent } from './load-game/load-game.component';

@NgModule({
  declarations: [
    AppComponent,
    HttpClientModule,
    NavMenuComponent,
    NavOptionsComponent,
    HomeComponent,
    NewGameComponent,
    LoadGameComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'nav-options', component: NavOptionsComponent, pathMatch: 'full' },
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'new-game', component: NewGameComponent },
      { path: 'load-game', component: LoadGameComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
