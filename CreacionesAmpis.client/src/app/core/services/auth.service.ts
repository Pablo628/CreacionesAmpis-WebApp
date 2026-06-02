import { Injectable, signal, computed, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { environment } from '../../../environments/environments';
import { Usuario } from '../../shared/models/user.model';

interface LoginResponse {
  token: string;
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private http = inject(HttpClient);
  private readonly TOKEN_KEY = 'ampis_token';

  private _user = signal<Usuario | null>(this.cargarUsuarioDesdeToken());

  readonly user = this._user.asReadonly();
  readonly isLoggedIn = computed(() => this._user() !== null);

  login(email: string, password: string) {
    return this.http
      .post<LoginResponse>(`${environment.apiUrl}auth/Login`, { email, password })
      .pipe(
        tap((res) => {
          localStorage.setItem(this.TOKEN_KEY, res.token);
          this._user.set(this.decodificarToken(res.token));
        }),
      );
  }

  resetPassword(email: string, newPassword: string) {
    return this.http.post(`${environment.apiUrl}auth/ResetPassword`, { email, newPassword });
  }

  logout() {
    localStorage.removeItem(this.TOKEN_KEY);
    this._user.set(null);
  }

  getToken(): string | null {
    return localStorage.getItem(this.TOKEN_KEY);
  }

  private cargarUsuarioDesdeToken(): Usuario | null {
    const token = localStorage.getItem(this.TOKEN_KEY);
    if (!token) return null;
    return this.decodificarToken(token);
  }

  private decodificarToken(token: string): Usuario | null {
    try {
      const payload = token.split('.')[1];
      const decoded = JSON.parse(atob(payload.replace(/-/g, '+').replace(/_/g, '/')));

      if (decoded.exp && decoded.exp * 1000 < Date.now()) {
        localStorage.removeItem(this.TOKEN_KEY);
        return null;
      }

      const name: string =
        decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'] ?? '';

      return {
        id: decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] ?? '',
        name,
        email: decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'] ?? '',
        rol: decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] ?? 'cliente',
        initials: this.calcularIniciales(name),
      };
    } catch {
      return null;
    }
  }

  private calcularIniciales(name: string): string {
    return name
      .trim()
      .split(' ')
      .filter((p) => p.length > 0)
      .slice(0, 2)
      .map((p) => p[0].toUpperCase())
      .join('');
  }
}
