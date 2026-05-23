import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App implements OnInit {

  private http = inject(HttpClient);

  protected readonly title = 'Dating Application';

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/members').subscribe({
      next: (subscribe) => console.log(subscribe),
      error: (error) => console.log(error),
      complete: () => console.log('Request completed')
    });
  }
}
