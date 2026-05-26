export interface Categoria {
  idCategoria: number;
  nombreCategoria: string;
  descripcion: string;
  activo: boolean;
}

export interface ProductoImagen {
  idProductoImagen: number;
  idProducto: number;
  imagenUrl: string;
  color: string;
  esPrincipal: boolean;
}

export interface ProductoVariante {
  idProductoVariante: number;
  idProducto: number;
  talla: string;
  color: string;
  stock: number;
}

export interface Producto {
  idProducto: number;
  idCategoria: number;
  nombreProducto: string;
  descripcion: string;
  precio: number;
  stock: number;
  materialInfo: string;
  guiaTallas: string;
  activo: boolean;
  fechaCreacion: string;
  imagenes: ProductoImagen[];
  variantes: ProductoVariante[];
  esNuevo?: boolean;
}
