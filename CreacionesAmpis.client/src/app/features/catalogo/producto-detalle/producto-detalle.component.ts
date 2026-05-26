import { Component, computed, inject, signal } from '@angular/core';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { ProductService } from '../../../core/services/product.service';
import { Producto } from '../../../shared/models/product.model';

const COLOR_HEX: Record<string, string> = {
  Rosa: '#f4a0b5',
  Negro: '#2c2c3a',
  Rojo: '#c0425a',
  Lila: '#b39ddb',
  Beige: '#d4b896',
  Blanco: '#f0f0f0',
};

const ORDEN_TALLAS = ['XS', 'S', 'M', 'L', 'XL', 'XXL'];

@Component({
  standalone: true,
  selector: 'app-producto-detalle',
  imports: [RouterLink],
  templateUrl: './producto-detalle.component.html',
  styleUrl: './producto-detalle.component.css',
})
export class ProductoDetalleComponent {
  private route = inject(ActivatedRoute);
  private router = inject(Router);
  private productService = inject(ProductService);

  producto = signal<Producto | null>(null);
  imagenActiva = signal<string>('');
  colorSeleccionado = signal<string | null>(null);
  tallaSeleccionada = signal<string | null>(null);
  cantidad = signal(1);
  acordeonAbierto = signal<string | null>('descripcion');
  agregado = signal(false);
  favorito = signal(false);

  constructor() {
    const id = +this.route.snapshot.paramMap.get('id')!;
    const found = this.productService.getProductoById(id);
    if (!found) {
      this.router.navigate(['/catalogo']);
      return;
    }
    this.producto.set(found);
    this.imagenActiva.set(
      found.imagenes.find((i) => i.esPrincipal)?.imagenUrl ?? found.imagenes[0]?.imagenUrl ?? '',
    );
  }

  coloresUnicos = computed(() => [
    ...new Set(this.producto()?.variantes.map((v) => v.color) ?? []),
  ]);

  tallasDisponibles = computed(() => {
    const p = this.producto();
    const color = this.colorSeleccionado();
    if (!p) return [];
    const variantes = color ? p.variantes.filter((v) => v.color === color) : p.variantes;
    const tallaMap = new Map<string, { talla: string; stock: number }>();
    variantes.forEach((v) => {
      const ex = tallaMap.get(v.talla);
      if (!ex || v.stock > ex.stock) tallaMap.set(v.talla, { talla: v.talla, stock: v.stock });
    });
    return [...tallaMap.values()].sort(
      (a, b) => ORDEN_TALLAS.indexOf(a.talla) - ORDEN_TALLAS.indexOf(b.talla),
    );
  });

  stockVariante = computed(() => {
    const p = this.producto();
    const color = this.colorSeleccionado();
    const talla = this.tallaSeleccionada();
    if (!p || !color || !talla) return null;
    return p.variantes.find((v) => v.color === color && v.talla === talla)?.stock ?? null;
  });

  puedeAgregar = computed(
    () =>
      !!this.colorSeleccionado() && !!this.tallaSeleccionada() && (this.stockVariante() ?? 0) > 0,
  );

  seleccionarColor(color: string) {
    this.colorSeleccionado.set(color);
    this.tallaSeleccionada.set(null);
    this.cantidad.set(1);
    const imgColor = this.producto()?.imagenes.find((i) => i.color === color);
    if (imgColor) this.imagenActiva.set(imgColor.imagenUrl);
  }

  seleccionarTalla(talla: string) {
    this.tallaSeleccionada.set(talla);
    this.cantidad.set(1);
  }

  cambiarCantidad(delta: number) {
    const max = this.stockVariante() ?? 99;
    this.cantidad.set(Math.min(Math.max(1, this.cantidad() + delta), max));
  }

  agregarAlCarrito() {
    if (!this.puedeAgregar()) return;
    this.agregado.set(true);
    setTimeout(() => this.agregado.set(false), 2500);
  }

  toggleFavorito() {
    this.favorito.update((v) => !v);
  }

  toggleAcordeon(key: string) {
    this.acordeonAbierto.update((c) => (c === key ? null : key));
  }

  setImagen(url: string) {
    this.imagenActiva.set(url);
  }

  getNombreCategoria(id: number) {
    return this.productService.getNombreCategoria(id);
  }
  getColorHex(color: string) {
    return COLOR_HEX[color] ?? '#ccc';
  }

  formatPrecio(precio: number): string {
    return new Intl.NumberFormat('es-CO', {
      style: 'currency',
      currency: 'COP',
      minimumFractionDigits: 0,
    }).format(precio);
  }
}
