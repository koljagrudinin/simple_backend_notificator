import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { MessageListComponent } from './message-list.component';
import { MessagesApi } from '../../services/messages.api';
import { MessagesService } from '../../services/messages.service';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
        MessageListComponent
    ],
    imports: [
        HttpModule,
        CommonModule
    ],
    providers: [
        MessagesApi,
        MessagesService,
    ],
    exports: [
        MessageListComponent
    ]
})
export class MessageListModule { }
