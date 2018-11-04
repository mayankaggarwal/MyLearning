import { Component } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { Message } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  private _hubConnection: HubConnection;
  msgs: Message[] = [];

  constructor() { }

  ngOnInit(): void {
    this._hubConnection = new signalR.HubConnectionBuilder().withUrl('http://localhost:58700/notify')
                    .configureLogging(signalR.LogLevel.Information)
                    .build();
    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this._hubConnection.on('BroadcastMessage', (type: string, payload: string) => {
      this.msgs.push({ severity: type, summary: payload });
    });
  }
}
