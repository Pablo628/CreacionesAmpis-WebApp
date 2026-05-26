import { Injectable } from '@angular/core';
import { Categoria, Producto } from '../../shared/models/product.model';

@Injectable({ providedIn: 'root' })
export class ProductService {

  readonly categorias: Categoria[] = [
    { idCategoria: 1, nombreCategoria: 'Lencería Clásica', descripcion: '', activo: true },
    { idCategoria: 2, nombreCategoria: 'Lencería Sexy',    descripcion: '', activo: true },
    { idCategoria: 3, nombreCategoria: 'Pijamas',          descripcion: '', activo: true },
    { idCategoria: 4, nombreCategoria: 'Bodies',           descripcion: '', activo: true },
    { idCategoria: 5, nombreCategoria: 'Fajas',            descripcion: '', activo: true },
  ];

  readonly productos: Producto[] = [
    {
      idProducto: 1, idCategoria: 1,
      nombreProducto: 'Conjunto Rosa Clásico',
      descripcion: 'Conjunto de brassier y panty en encaje suave, confeccionado con los mejores materiales para brindarte comodidad y elegancia en cada momento.',
      precio: 45000, stock: 20,
      materialInfo: '90% Nylon, 10% Elastano — Encaje importado de alta calidad. Lavado a mano en agua fría.',
      guiaTallas: 'S, M, L, XL',
      activo: true, fechaCreacion: '2026-05-19', esNuevo: true,
      imagenes: [
        { idProductoImagen: 1, idProducto: 1, imagenUrl: 'lenceria.jpg', color: 'Rosa', esPrincipal: true },
        { idProductoImagen: 2, idProducto: 1, imagenUrl: 'lence.jpg',    color: 'Rosa', esPrincipal: false },
      ],
      variantes: [
        { idProductoVariante: 1, idProducto: 1, talla: 'S',  color: 'Rosa', stock: 5 },
        { idProductoVariante: 2, idProducto: 1, talla: 'M',  color: 'Rosa', stock: 8 },
        { idProductoVariante: 3, idProducto: 1, talla: 'L',  color: 'Rosa', stock: 4 },
        { idProductoVariante: 4, idProducto: 1, talla: 'XL', color: 'Rosa', stock: 3 },
      ],
    },
    {
      idProducto: 2, idCategoria: 1,
      nombreProducto: 'Conjunto Negro Elegante',
      descripcion: 'Conjunto liso con detalles en encaje, diseñado para realzar tu silueta con una combinación perfecta de estilo y confort.',
      precio: 52000, stock: 15,
      materialInfo: '85% Poliéster, 15% Elastano — Acabado satinado premium. Lavado a máquina en frío.',
      guiaTallas: 'S, M, L',
      activo: true, fechaCreacion: '2026-05-19', esNuevo: false,
      imagenes: [
        { idProductoImagen: 3, idProducto: 2, imagenUrl: 'lence.jpg',    color: 'Negro', esPrincipal: true },
        { idProductoImagen: 4, idProducto: 2, imagenUrl: 'lenceria.jpg', color: 'Negro', esPrincipal: false },
      ],
      variantes: [
        { idProductoVariante: 5, idProducto: 2, talla: 'S', color: 'Negro', stock: 4 },
        { idProductoVariante: 6, idProducto: 2, talla: 'M', color: 'Negro', stock: 6 },
        { idProductoVariante: 7, idProducto: 2, talla: 'L', color: 'Negro', stock: 5 },
      ],
    },
    {
      idProducto: 3, idCategoria: 2,
      nombreProducto: 'Conjunto Rojo Pasión',
      descripcion: 'Conjunto atrevido con transparencias en encaje floral, pensado para las mujeres que abrazan su sensualidad con confianza y elegancia.',
      precio: 68000, stock: 10,
      materialInfo: '80% Encaje, 20% Elastano — Diseño exclusivo con transparencias controladas. Lavado a mano.',
      guiaTallas: 'S, M, L, XL',
      activo: true, fechaCreacion: '2026-05-19', esNuevo: true,
      imagenes: [
        { idProductoImagen: 5, idProducto: 3, imagenUrl: 'foto.jpg', color: 'Rojo', esPrincipal: true },
      ],
      variantes: [
        { idProductoVariante: 8,  idProducto: 3, talla: 'S',  color: 'Rojo', stock: 3 },
        { idProductoVariante: 9,  idProducto: 3, talla: 'M',  color: 'Rojo', stock: 4 },
        { idProductoVariante: 10, idProducto: 3, talla: 'L',  color: 'Rojo', stock: 3 },
        { idProductoVariante: 11, idProducto: 3, talla: 'XL', color: 'Rojo', stock: 0 },
      ],
    },
    {
      idProducto: 4, idCategoria: 3,
      nombreProducto: 'Pijama Satinado Lila',
      descripcion: 'Pijama de dos piezas en satín premium que combina suavidad extrema con un diseño sofisticado. Perfecta para descansar con estilo.',
      precio: 75000, stock: 25,
      materialInfo: '100% Satín de Poliéster — Tacto sedoso, fresco y ligero. Lavado a mano en agua fría.',
      guiaTallas: 'S, M, L, XL, XXL',
      activo: true, fechaCreacion: '2026-05-19', esNuevo: false,
      imagenes: [
        { idProductoImagen: 6, idProducto: 4, imagenUrl: 'body.jpg', color: 'Lila', esPrincipal: true },
      ],
      variantes: [
        { idProductoVariante: 12, idProducto: 4, talla: 'S',   color: 'Lila', stock: 5 },
        { idProductoVariante: 13, idProducto: 4, talla: 'M',   color: 'Lila', stock: 10 },
        { idProductoVariante: 14, idProducto: 4, talla: 'L',   color: 'Lila', stock: 8 },
        { idProductoVariante: 15, idProducto: 4, talla: 'XL',  color: 'Lila', stock: 0 },
        { idProductoVariante: 16, idProducto: 4, talla: 'XXL', color: 'Lila', stock: 2 },
      ],
    },
    {
      idProducto: 5, idCategoria: 4,
      nombreProducto: 'Body Negro Encaje',
      descripcion: 'Body de encaje con broches en la base, una pieza versátil que puedes combinar como prenda interior o exterior. Diseño atemporal.',
      precio: 85000, stock: 12,
      materialInfo: '90% Encaje, 10% Elastano — Broches resistentes de alta durabilidad. Lavado a mano en frío.',
      guiaTallas: 'S, M, L',
      activo: true, fechaCreacion: '2026-05-19', esNuevo: true,
      imagenes: [
        { idProductoImagen: 7, idProducto: 5, imagenUrl: 'lenceria.jpg', color: 'Negro', esPrincipal: true },
        { idProductoImagen: 8, idProducto: 5, imagenUrl: 'body.jpg',     color: 'Negro', esPrincipal: false },
      ],
      variantes: [
        { idProductoVariante: 17, idProducto: 5, talla: 'S', color: 'Negro', stock: 5 },
        { idProductoVariante: 18, idProducto: 5, talla: 'M', color: 'Negro', stock: 4 },
        { idProductoVariante: 19, idProducto: 5, talla: 'L', color: 'Negro', stock: 2 },
      ],
    },
    {
      idProducto: 6, idCategoria: 5,
      nombreProducto: 'Faja Reductora Beige',
      descripcion: 'Faja moldeadora de cintura y abdomen con tecnología de compresión progresiva. Resultados visibles desde el primer uso sin sacrificar comodidad.',
      precio: 95000, stock: 18,
      materialInfo: '70% Nylon, 30% Elastano — Costuras planas anti-fricción. Lavado a mano suave.',
      guiaTallas: 'S, M, L, XL',
      activo: true, fechaCreacion: '2026-05-19', esNuevo: false,
      imagenes: [
        { idProductoImagen: 9,  idProducto: 6, imagenUrl: 'lence.jpg', color: 'Beige', esPrincipal: true },
        { idProductoImagen: 10, idProducto: 6, imagenUrl: 'foto.jpg',  color: 'Beige', esPrincipal: false },
      ],
      variantes: [
        { idProductoVariante: 20, idProducto: 6, talla: 'S',  color: 'Beige', stock: 3 },
        { idProductoVariante: 21, idProducto: 6, talla: 'M',  color: 'Beige', stock: 6 },
        { idProductoVariante: 22, idProducto: 6, talla: 'L',  color: 'Beige', stock: 7 },
        { idProductoVariante: 23, idProducto: 6, talla: 'XL', color: 'Beige', stock: 2 },
      ],
    },
  ];

  getProductoById(id: number): Producto | undefined {
    return this.productos.find(p => p.idProducto === id);
  }

  getNombreCategoria(idCategoria: number): string {
    return this.categorias.find(c => c.idCategoria === idCategoria)?.nombreCategoria ?? '';
  }
}
