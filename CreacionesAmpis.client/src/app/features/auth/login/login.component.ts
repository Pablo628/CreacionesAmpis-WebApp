import { Component, inject, signal } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  standalone: true,
  selector: 'app-login',
  imports: [RouterLink],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  private auth = inject(AuthService);
  private router = inject(Router);

  showPassword = signal(false);
  loginError = signal(false);

  togglePassword() {
    this.showPassword.update((v) => !v);
  }

  onSubmit(email: string, password: string) {
    this.loginError.set(false);
    if (this.auth.login(email.trim(), password)) {
      this.router.navigate(['/']);
    } else {
      this.loginError.set(true);
    }
  }
}
