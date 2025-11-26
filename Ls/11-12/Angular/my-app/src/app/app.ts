import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Home } from './home/home';

@Component({
  selector: '#main',
  imports: [Home],
  // templateUrl: './app.html',
  styleUrl: './app.css',
  template: `
  <main>
    <section class="content">
      <app-home></app-home>
    </section>
  </main>`,
})

export class App {
  protected readonly title = signal('my-app');
}
