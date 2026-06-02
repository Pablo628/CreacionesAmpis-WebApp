import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './shared/components/navbar/navbar.component';
import { FooterComponent } from './shared/components/footer/footer.component';
import { trigger, transition, style, animate, query, group } from '@angular/animations';

const routeAnimations = trigger('routeAnimations', [
  transition('home => login', [
    query(':enter, :leave', [
      style({ position: 'absolute', width: '100%', top: 0, left: 0 })
    ], { optional: true }),
    query(':enter', [style({ left: '100%' })], { optional: true }),
    group([
      query(':leave', [animate('450ms cubic-bezier(0.4,0,0.2,1)', style({ left: '-100%' }))], { optional: true }),
      query(':enter', [animate('450ms cubic-bezier(0.4,0,0.2,1)', style({ left: '0%' }))], { optional: true }),
    ]),
  ]),
  transition('login => home', [
    query(':enter, :leave', [
      style({ position: 'absolute', width: '100%', top: 0, left: 0 })
    ], { optional: true }),
    query(':enter', [style({ left: '-100%' })], { optional: true }),
    group([
      query(':leave', [animate('450ms cubic-bezier(0.4,0,0.2,1)', style({ left: '100%' }))], { optional: true }),
      query(':enter', [animate('450ms cubic-bezier(0.4,0,0.2,1)', style({ left: '0%' }))], { optional: true }),
    ]),
  ]),
]);

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, FooterComponent],
  templateUrl: './app.html',
  styleUrl: './app.css',
  animations: [routeAnimations],
  animations: [routeAnimations],
})
export class App {
  prepareRoute(outlet: RouterOutlet) {
    return outlet?.activatedRouteData?.['animation'];
  }
}
export class App {
  prepareRoute(outlet: RouterOutlet) {
    return outlet?.activatedRouteData?.['animation'];
  }
}
