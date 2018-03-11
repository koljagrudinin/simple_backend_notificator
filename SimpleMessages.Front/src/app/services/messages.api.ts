import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

@Injectable()
export class MessagesApi {

    constructor(private http: Http) {
    }

    getMessages(): Observable<string[]> {

        return this.http.get('/api/messages')
            .map(result => {
                return result.json() as string[];
            });
    }
}
