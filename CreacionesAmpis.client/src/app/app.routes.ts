import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    data: { animation: 'home' },
    loadComponent: () => import('./features/home/home.component').then((m) => m.HomeComponent),
  },
  {
    path: 'ingresar',
    data: { animation: 'login' },
    loadComponent: () => import('./features/auth/login/login.component').then((m) => m.LoginComponent),
  },
  {
    path: 'catalogo',
    loadComponent: () => import('./features/catalogo/catalogo.component').then((m) => m.CatalogoComponent),
  },
  {
    path: 'catalogo/:id',
    loadComponent: () => import('./features/catalogo/producto-detalle/producto-detalle.component').then((m) => m.ProductoDetalleComponent),
  },
  {
    path: 'guia-tallas',
    loadComponent: () => import('./features/guia-tallas/guia-tallas.component').then((m) => m.GuiaTallasComponent),
  },
];
