import { Component, HostListener, computed, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Categoria, Producto } from '../../shared/models/product.model';

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
  selector: 'app-catalogo',
  imports: [RouterLink],
  templateUrl: './catalogo.component.html',
  styleUrl: './catalogo.component.css',
})
export class CatalogoComponent {
  categorias: Categoria[] = [
    { idCategoria: 1, nombreCategoria: 'Lencería Clásica', descripcion: '', activo: true },
    { idCategoria: 2, nombreCategoria: 'Lencería Sexy', descripcion: '', activo: true },
    { idCategoria: 3, nombreCategoria: 'Pijamas', descripcion: '', activo: true },
    { idCategoria: 4, nombreCategoria: 'Bodies', descripcion: '', activo: true },
    { idCategoria: 5, nombreCategoria: 'Fajas', descripcion: '', activo: true },
  ];

  productos: Producto[] = [
    {
      idProducto: 1,
      idCategoria: 1,
      nombreProducto: 'Conjunto Rosa Clásico',
      descripcion: 'Conjunto de brassier y panty en encaje suave',
      precio: 45000,
      stock: 20,
      materialInfo: '90% Nylon, 10% Elastano',
      guiaTallas: 'S, M, L, XL',
      activo: true,
      fechaCreacion: '2026-05-19',
      esNuevo: true,
      imagenes: [
        {
          idProductoImagen: 1,
          idProducto: 1,
          imagenUrl: 'lenceria.jpg',
          color: 'Rosa',
          esPrincipal: true,
        },
        {
          idProductoImagen: 2,
          idProducto: 1,
          imagenUrl: 'lence.jpg',
          color: 'Rosa',
          esPrincipal: false,
        },
      ],
      variantes: [
        { idProductoVariante: 1, idProducto: 1, talla: 'S', color: 'Rosa', stock: 5 },
        { idProductoVariante: 2, idProducto: 1, talla: 'M', color: 'Rosa', stock: 8 },
        { idProductoVariante: 3, idProducto: 1, talla: 'L', color: 'Rosa', stock: 4 },
        { idProductoVariante: 4, idProducto: 1, talla: 'XL', color: 'Rosa', stock: 3 },
      ],
    },
    {
      idProducto: 2,
      idCategoria: 1,
      nombreProducto: 'Conjunto Negro Elegante',
      descripcion: 'Conjunto liso con detalles en encaje',
      precio: 52000,
      stock: 15,
      materialInfo: '85% Poliéster, 15% Elastano',
      guiaTallas: 'S, M, L',
      activo: true,
      fechaCreacion: '2026-05-19',
      esNuevo: false,
      imagenes: [
        {
          idProductoImagen: 3,
          idProducto: 2,
          imagenUrl: 'lence.jpg',
          color: 'Negro',
          esPrincipal: true,
        },
      ],
      variantes: [
        { idProductoVariante: 5, idProducto: 2, talla: 'S', color: 'Negro', stock: 4 },
        { idProductoVariante: 6, idProducto: 2, talla: 'M', color: 'Negro', stock: 6 },
        { idProductoVariante: 7, idProducto: 2, talla: 'L', color: 'Negro', stock: 5 },
      ],
    },
    {
      idProducto: 3,
      idCategoria: 2,
      nombreProducto: 'Conjunto Rojo Pasión',
      descripcion: 'Conjunto atrevido con transparencias',
      precio: 68000,
      stock: 10,
      materialInfo: '80% Encaje, 20% Elastano',
      guiaTallas: 'S, M, L, XL',
      activo: true,
      fechaCreacion: '2026-05-19',
      esNuevo: true,
      imagenes: [
        {
          idProductoImagen: 5,
          idProducto: 3,
          imagenUrl: 'foto.jpg',
          color: 'Rojo',
          esPrincipal: true,
        },
      ],
      variantes: [
        { idProductoVariante: 8, idProducto: 3, talla: 'S', color: 'Rojo', stock: 3 },
        { idProductoVariante: 9, idProducto: 3, talla: 'M', color: 'Rojo', stock: 4 },
        { idProductoVariante: 10, idProducto: 3, talla: 'L', color: 'Rojo', stock: 3 },
        { idProductoVariante: 11, idProducto: 3, talla: 'XL', color: 'Rojo', stock: 0 },
      ],
    },
    {
      idProducto: 4,
      idCategoria: 3,
      nombreProducto: 'Pijama Satinado Lila',
      descripcion: 'Pijama de dos piezas en satín premium',
      precio: 75000,
      stock: 25,
      materialInfo: '100% Satín de Poliéster',
      guiaTallas: 'S, M, L, XL, XXL',
      activo: true,
      fechaCreacion: '2026-05-19',
      esNuevo: false,
      imagenes: [
        {
          idProductoImagen: 6,
          idProducto: 4,
          imagenUrl: 'body.jpg',
          color: 'Lila',
          esPrincipal: true,
        },
      ],
      variantes: [
        { idProductoVariante: 12, idProducto: 4, talla: 'S', color: 'Lila', stock: 5 },
        { idProductoVariante: 13, idProducto: 4, talla: 'M', color: 'Lila', stock: 10 },
        { idProductoVariante: 14, idProducto: 4, talla: 'L', color: 'Lila', stock: 8 },
        { idProductoVariante: 15, idProducto: 4, talla: 'XL', color: 'Lila', stock: 0 },
        { idProductoVariante: 16, idProducto: 4, talla: 'XXL', color: 'Lila', stock: 2 },
      ],
    },
    {
      idProducto: 5,
      idCategoria: 4,
      nombreProducto: 'Body Negro Encaje',
      descripcion: 'Body de encaje con broches en la base',
      precio: 85000,
      stock: 12,
      materialInfo: '90% Encaje, 10% Elastano',
      guiaTallas: 'S, M, L',
      activo: true,
      fechaCreacion: '2026-05-19',
      esNuevo: true,
      imagenes: [
        {
          idProductoImagen: 7,
          idProducto: 5,
          imagenUrl: 'lenceria.jpg',
          color: 'Negro',
          esPrincipal: true,
        },
      ],
      variantes: [
        { idProductoVariante: 17, idProducto: 5, talla: 'S', color: 'Negro', stock: 5 },
        { idProductoVariante: 18, idProducto: 5, talla: 'M', color: 'Negro', stock: 4 },
        { idProductoVariante: 19, idProducto: 5, talla: 'L', color: 'Negro', stock: 3 },
      ],
    },
    {
      idProducto: 6,
      idCategoria: 5,
      nombreProducto: 'Faja Reductora Beige',
      descripcion: 'Faja moldeadora de cintura y abdomen',
      precio: 95000,
      stock: 18,
      materialInfo: '70% Nylon, 30% Elastano',
      guiaTallas: 'S, M, L, XL',
      activo: true,
      fechaCreacion: '2026-05-19',
      esNuevo: false,
      imagenes: [
        {
          idProductoImagen: 8,
          idProducto: 6,
          imagenUrl: 'lence.jpg',
          color: 'Beige',
          esPrincipal: true,
        },
      ],
      variantes: [
        { idProductoVariante: 20, idProducto: 6, talla: 'S', color: 'Beige', stock: 3 },
        { idProductoVariante: 21, idProducto: 6, talla: 'M', color: 'Beige', stock: 6 },
        { idProductoVariante: 22, idProducto: 6, talla: 'L', color: 'Beige', stock: 7 },
        { idProductoVariante: 23, idProducto: 6, talla: 'XL', color: 'Beige', stock: 2 },
      ],
    },
  ];

  filtroActivo = signal<number | null>(null);
  ordenActivo = signal<string>('nuevo');
  dropdownOpen = signal(false);

  productosFiltrados = computed(() => {
    const lista = this.productos.filter(
      (p) => this.filtroActivo() === null || p.idCategoria === this.filtroActivo(),
    );
    switch (this.ordenActivo()) {
      case 'mayor':
        return [...lista].sort((a, b) => b.precio - a.precio);
      case 'menor':
        return [...lista].sort((a, b) => a.precio - b.precio);
      case 'nombre':
        return [...lista].sort((a, b) => a.nombreProducto.localeCompare(b.nombreProducto));
      default:
        return lista;
    }
  });

  ordenLabel = computed(
    () =>
      ({
        nuevo: 'Más nuevos',
        mayor: 'Mayor precio',
        menor: 'Menor precio',
        nombre: 'Nombre A–Z',
      })[this.ordenActivo()] ?? 'Ordenar',
  );

  setFiltro(id: number | null) {
    this.filtroActivo.set(id);
  }

  setOrden(orden: string) {
    this.ordenActivo.set(orden);
    this.dropdownOpen.set(false);
  }

  toggleDropdown() {
    this.dropdownOpen.update((v) => !v);
  }

  @HostListener('document:click', ['$event'])
  onDocumentClick(e: Event) {
    if (!(e.target as HTMLElement).closest('.sort-wrapper')) {
      this.dropdownOpen.set(false);
    }
  }

  getNombreCategoria(id: number): string {
    return this.categorias.find((c) => c.idCategoria === id)?.nombreCategoria ?? '';
  }

  getImagenPrincipal(producto: Producto): string {
    return (
      producto.imagenes.find((i) => i.esPrincipal)?.imagenUrl ??
      producto.imagenes[0]?.imagenUrl ??
      ''
    );
  }

  getColoresUnicos(producto: Producto): string[] {
    return [...new Set(producto.variantes.map((v) => v.color))];
  }

  getTallasUnicas(producto: Producto): string[] {
    const tallas = [...new Set(producto.variantes.map((v) => v.talla))];
    return tallas.sort((a, b) => ORDEN_TALLAS.indexOf(a) - ORDEN_TALLAS.indexOf(b));
  }

  getColorHex(color: string): string {
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
