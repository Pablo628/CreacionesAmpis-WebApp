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
  loading = signal(false);

  showResetModal = signal(false);
  resetLoading = signal(false);
  resetError = signal('');
  resetSuccess = signal(false);

  togglePassword() {
    this.showPassword.update((v) => !v);
  }

  onSubmit(email: string, password: string) {
    if (this.loading()) return;
    this.loginError.set(false);
    this.loading.set(true);

    this.auth.login(email.trim(), password).subscribe({
      next: () => this.router.navigate(['/']),
      error: () => {
        this.loginError.set(true);
        this.loading.set(false);
      },
    });
  }

  abrirReset() {
    this.showResetModal.set(true);
    this.resetError.set('');
    this.resetSuccess.set(false);
  }

  cerrarReset() {
    this.showResetModal.set(false);
  }

  onReset(email: string, newPassword: string, confirmPassword: string) {
    this.resetError.set('');

    if (!email || !newPassword || !confirmPassword) {
      this.resetError.set('Por favor completa todos los campos.');
      return;
    }

    if (newPassword !== confirmPassword) {
      this.resetError.set('Las contraseñas no coinciden.');
      return;
    }

    if (newPassword.length < 6) {
      this.resetError.set('La contraseña debe tener al menos 6 caracteres.');
      return;
    }

    this.resetLoading.set(true);

    this.auth.resetPassword(email.trim(), newPassword).subscribe({
      next: () => {
        this.resetLoading.set(false);
        this.resetSuccess.set(true);
      },
      error: () => {
        this.resetLoading.set(false);
        this.resetError.set('No encontramos una cuenta con ese correo.');
      },
    });
  }
}
