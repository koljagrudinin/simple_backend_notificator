import { Component, OnInit, OnDestroy } from '@angular/core';
import { HubConnection } from '@aspnet/signalr-client';
import { Subject } from 'rxjs/Subject';
import { MessagesService } from '../../services/messages.service';

@Component({
    templateUrl: './message-list.html',
})
export class MessageListComponent implements OnInit , OnDestroy {
    messages: string[] = [];
    private destroyed: Subject<boolean> = new Subject();
    constructor(private messagesService: MessagesService) { }

    ngOnInit() {
        this.getCurrentMessagesAndSubscribe();
    }

    ngOnDestroy() {
        this.destroyed.next(true);
      }

    private getCurrentMessagesAndSubscribe() {
        this.messagesService.getMessages()
        .subscribe((messages: string[]) => {
            this.messages = messages;

            this.messagesService.messageReceivedSubject.subscribe((message: string) => {
                this.messages.push(message);
            });
        });
    }
}
