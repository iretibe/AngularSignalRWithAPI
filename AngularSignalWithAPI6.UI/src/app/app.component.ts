import { Component } from '@angular/core';
import { HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SignalR using Angular and .Net Core 6';

  private hubConnectionBuilder! : HubConnection;

  news: any[] = [];

  constructor() {
        
  }

  ngOnInit(): void {
    this.hubConnectionBuilder = new HubConnectionBuilder()
      .withUrl('https://localhost:7155/news')
      .configureLogging(LogLevel.Information)
      .build();

    this.hubConnectionBuilder
      .start()
      .then(() => console.log('Connection started.......!'))
      .catch(ex => console.log('An error occurred while connecting to the server!'));

    this.hubConnectionBuilder
      .on('SendNewsToUser', (result: any) => {
        this.news.push(result);
      })
  }
}
