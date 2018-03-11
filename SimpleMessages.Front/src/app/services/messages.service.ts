import { Injectable, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client';
import { Subject } from 'rxjs/Subject';
import { MessagesApi } from './messages.api';
import { Observable } from 'rxjs';

@Injectable()
export class MessagesService {

    public messageReceivedSubject = new Subject<string>();

    private _hubConnection: HubConnection;

    constructor(private messagesApi: MessagesApi) {
        this.initHub();
    }

    getMessages(): Observable<string[]> {
        return this.messagesApi.getMessages();
    }

    private initHub() {
        this._hubConnection = new HubConnection('/hubs/messages');

        this._hubConnection.on('Send', (data: any) => {
            const received = `${data}`;

            this.messageReceivedSubject.next(received);
        });

        this._hubConnection.start()
            .then(() => {
            })
            .catch(err => {
                console.error(err);
            });
    }
}
