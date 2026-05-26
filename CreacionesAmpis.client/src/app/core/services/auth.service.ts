import { Injectable, computed, signal } from '@angular/core';

interface User {
  name: string;
  email: string;
  initials: string;
}

const DEMO = { email: 'ampis@creaciones.com', password: 'ampis123' };
const DEMO_USER: User = { name: 'Ana Ampis', email: DEMO.email, initials: 'AA' };

@Injectable({ providedIn: 'root' })
export class AuthService {
  private _user = signal<User | null>(null);

  readonly user = this._user.asReadonly();
  readonly isLoggedIn = computed(() => this._user() !== null);

  login(email: string, password: string): boolean {
    if (email === DEMO.email && password === DEMO.password) {
      this._user.set(DEMO_USER);
      return true;
    }
    return false;
  }

  logout(): void {
    this._user.set(null);
  }
}
