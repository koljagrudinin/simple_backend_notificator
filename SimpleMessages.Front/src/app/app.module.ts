import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { MessagesApi } from './services/messages.api';
import { MessagesService } from './services/messages.service';
import { HttpModule } from '@angular/http';
import { MessageListComponent } from './components/message-list/message-list.component';
import { RouterModule } from '@angular/router';
import { MessageListModule } from './components/message-list/message-list.module';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        MessageListModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'message-list', pathMatch: 'full' },
            { path: 'message-list', component: MessageListComponent },
            { path: '**', redirectTo: 'message-list' }
        ])
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
