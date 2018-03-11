import { Component, OnInit, OnDestroy } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client';
import { MessagesService } from './services/messages.service';
import { Subject } from 'rxjs/Subject';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
})
export class AppComponent {
}
