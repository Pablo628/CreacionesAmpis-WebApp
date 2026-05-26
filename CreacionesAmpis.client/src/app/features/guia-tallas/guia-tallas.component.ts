import { Component, computed, signal } from '@angular/core';

interface FilaTalla {
  talla: string;
  busto?: string;
  cintura: string;
  cadera?: string;
  bustoMin?: number;
  bustoMax?: number;
  cinturaMin: number;
  cinturaMax: number;
  caderaMin?: number;
  caderaMax?: number;
}

interface TablaConfig {
  id: 'general' | 'fajas';
  label: string;
  descripcion: string;
  usaBusto: boolean;
  usaCadera: boolean;
  filas: FilaTalla[];
}

@Component({
  standalone: true,
  selector: 'app-guia-tallas',
  templateUrl: './guia-tallas.component.html',
  styleUrl: './guia-tallas.component.css',
})
export class GuiaTallasComponent {
  tablas: TablaConfig[] = [
    {
      id: 'general',
      label: 'Lencería & Bodies',
      descripcion: 'Para conjuntos, brassieres, panties y bodies',
      usaBusto: true,
      usaCadera: true,
      filas: [
        {
          talla: 'XS',
          busto: '80–84',
          cintura: '60–64',
          cadera: '86–90',
          bustoMin: 80,
          bustoMax: 84,
          cinturaMin: 60,
          cinturaMax: 64,
          caderaMin: 86,
          caderaMax: 90,
        },
        {
          talla: 'S',
          busto: '84–88',
          cintura: '64–68',
          cadera: '90–94',
          bustoMin: 84,
          bustoMax: 88,
          cinturaMin: 64,
          cinturaMax: 68,
          caderaMin: 90,
          caderaMax: 94,
        },
        {
          talla: 'M',
          busto: '88–92',
          cintura: '68–72',
          cadera: '94–98',
          bustoMin: 88,
          bustoMax: 92,
          cinturaMin: 68,
          cinturaMax: 72,
          caderaMin: 94,
          caderaMax: 98,
        },
        {
          talla: 'L',
          busto: '92–96',
          cintura: '72–76',
          cadera: '98–102',
          bustoMin: 92,
          bustoMax: 96,
          cinturaMin: 72,
          cinturaMax: 76,
          caderaMin: 98,
          caderaMax: 102,
        },
        {
          talla: 'XL',
          busto: '96–100',
          cintura: '76–80',
          cadera: '102–106',
          bustoMin: 96,
          bustoMax: 100,
          cinturaMin: 76,
          cinturaMax: 80,
          caderaMin: 102,
          caderaMax: 106,
        },
        {
          talla: 'XXL',
          busto: '100–106',
          cintura: '80–86',
          cadera: '106–112',
          bustoMin: 100,
          bustoMax: 106,
          cinturaMin: 80,
          cinturaMax: 86,
          caderaMin: 106,
          caderaMax: 112,
        },
      ],
    },
    {
      id: 'fajas',
      label: 'Fajas',
      descripcion: 'Para fajas reductoras y moldeadoras',
      usaBusto: false,
      usaCadera: true,
      filas: [
        {
          talla: 'S',
          cintura: '60–66',
          cadera: '86–92',
          cinturaMin: 60,
          cinturaMax: 66,
          caderaMin: 86,
          caderaMax: 92,
        },
        {
          talla: 'M',
          cintura: '66–72',
          cadera: '92–98',
          cinturaMin: 66,
          cinturaMax: 72,
          caderaMin: 92,
          caderaMax: 98,
        },
        {
          talla: 'L',
          cintura: '72–78',
          cadera: '98–104',
          cinturaMin: 72,
          cinturaMax: 78,
          caderaMin: 98,
          caderaMax: 104,
        },
        {
          talla: 'XL',
          cintura: '78–84',
          cadera: '104–110',
          cinturaMin: 78,
          cinturaMax: 84,
          caderaMin: 104,
          caderaMax: 110,
        },
        {
          talla: 'XXL',
          cintura: '84–92',
          cadera: '110–118',
          cinturaMin: 84,
          cinturaMax: 92,
          caderaMin: 110,
          caderaMax: 118,
        },
      ],
    },
  ];

  tabActiva = signal<'general' | 'fajas'>('general');
  bustoInput = signal<number | null>(null);
  cinturaInput = signal<number | null>(null);
  caderaInput = signal<number | null>(null);
  tallaSugerida = signal<string | null>(null);
  calcHecho = signal(false);

  tablaActiva = computed(() => this.tablas.find((t) => t.id === this.tabActiva())!);

  setTab(id: 'general' | 'fajas') {
    this.tabActiva.set(id);
    this.resetCalc();
  }

  resetCalc() {
    this.tallaSugerida.set(null);
    this.calcHecho.set(false);
    this.bustoInput.set(null);
    this.cinturaInput.set(null);
    this.caderaInput.set(null);
  }

  setBusto(e: Event) {
    const v = +(e.target as HTMLInputElement).value;
    this.bustoInput.set(v > 0 ? v : null);
  }
  setCintura(e: Event) {
    const v = +(e.target as HTMLInputElement).value;
    this.cinturaInput.set(v > 0 ? v : null);
  }
  setCadera(e: Event) {
    const v = +(e.target as HTMLInputElement).value;
    this.caderaInput.set(v > 0 ? v : null);
  }

  calcularTalla() {
    this.calcHecho.set(true);
    const cintura = this.cinturaInput();
    if (!cintura) {
      this.tallaSugerida.set(null);
      return;
    }

    const busto = this.bustoInput();
    const cadera = this.caderaInput();
    const tabla = this.tablaActiva();

    const exacta = tabla.filas.find((f) => {
      const cinturaOk = cintura >= f.cinturaMin && cintura <= f.cinturaMax;
      const bustoOk =
        !tabla.usaBusto || !busto || (busto >= (f.bustoMin ?? 0) && busto <= (f.bustoMax ?? 999));
      const caderaOk =
        !tabla.usaCadera ||
        !cadera ||
        (cadera >= (f.caderaMin ?? 0) && cadera <= (f.caderaMax ?? 999));
      return cinturaOk && bustoOk && caderaOk;
    });

    // Si no hay coincidencia exacta, busca la más cercana por cintura
    const resultado =
      exacta ??
      tabla.filas.reduce((prev, curr) => {
        const dPrev = Math.min(
          Math.abs(cintura - prev.cinturaMin),
          Math.abs(cintura - prev.cinturaMax),
        );
        const dCurr = Math.min(
          Math.abs(cintura - curr.cinturaMin),
          Math.abs(cintura - curr.cinturaMax),
        );
        return dCurr < dPrev ? curr : prev;
      });

    this.tallaSugerida.set(resultado.talla);
  }
}
