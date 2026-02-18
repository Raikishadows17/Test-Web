import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FiltersComponent } from '../../../components/filters/filters.component';
import { RouterLink } from "@angular/router";

interface TreeGroup {
  key: string;
  title: string;
  items: string[];
}


@Component({
  selector: 'app-dashboard-strategic',
  standalone: true,
  imports: [CommonModule, FormsModule, FiltersComponent, RouterLink],
  templateUrl: './dashboard-strategic.html',
  styleUrl: './dashboard-strategic.css',
})

export class DashboardStrategic implements OnInit {
  /** FUTURO: activar mapa */
  useMap = false;

  openGroupRight: string | null = null;
  treeData: TreeGroup[] = []; // Datos para el panel derecho

  selectedUnit: any = null;     // Guardará los datos completos de la unidad seleccionada
  showDetailsModal = false;     // Controla si se muestra el modal

 private allData: any[] = [
  // GRUPO: IDA (foráneo)
  {
    economico: 'ECO-101',
    origen: 'Monterrey',
    destino: 'CDMX',
    operador: 'Juan Pérez',
    equipo: 'Tracto 45',
    terminal: 'Terminal Norte',
    contenedor: 'Contenedor 40',
    cliente: 'Cliente Alpha',
    tipoViaje: 'lleno',
    grupo: 'IDA',
    isForaneo: true,
    estimatedKm: 850,
    estimatedTime: '11:30',
    estimatedDelivery: '2026-02-17T13:00'   // ya pasó (demora)
  },
  {
    economico: 'ECO-102',
    origen: 'Monterrey',
    destino: 'CDMX',
    operador: 'Luis Hernández',
    equipo: 'Tracto 52',
    terminal: 'Terminal Norte',
    contenedor: 'Contenedor 40',
    cliente: 'Cliente Beta',
    tipoViaje: 'lleno',
    grupo: 'IDA',
    isForaneo: true,
    estimatedKm: 860,
    estimatedTime: '11:45',
    estimatedDelivery: '2026-02-17T14:30'   // próxima entrega
  },
  {
    economico: 'ECO-103',
    origen: 'Guadalajara',
    destino: 'Querétaro',
    operador: 'María López',
    equipo: 'Tracto 33',
    terminal: 'Terminal Sur',
    contenedor: 'Contenedor 20',
    cliente: 'Cliente Gamma',
    tipoViaje: 'vacio',
    grupo: 'IDA',
    isForaneo: true,
    estimatedKm: 320,
    estimatedTime: '4:20',
    estimatedDelivery: '2026-02-17T10:00'   // ya pasó (demora)
  },
  {
    economico: 'ECO-104',
    origen: 'Monterrey',
    destino: 'CDMX',
    operador: 'Carlos Ramírez',
    equipo: 'Tracto 45',
    terminal: 'Terminal Norte',
    contenedor: 'Contenedor 40',
    cliente: 'Cliente Alpha',
    tipoViaje: 'lleno',
    grupo: 'IDA',
    isForaneo: true,
    estimatedKm: 840,
    estimatedTime: '11:15',
    estimatedDelivery: '2026-02-17T15:00'   // en tiempo
  },

  // GRUPO: VUELTA (foráneo)
  {
    economico: 'ECO-201',
    origen: 'CDMX',
    destino: 'Monterrey',
    operador: 'Ana Gómez',
    equipo: 'Tracto 78',
    terminal: 'Terminal Norte',
    contenedor: 'Contenedor 40',
    cliente: 'Cliente Alpha',
    tipoViaje: 'vacio',
    grupo: 'VUELTA',
    isForaneo: true,
    estimatedKm: 850,
    estimatedTime: '11:30',
    estimatedDelivery: '2026-02-17T12:00'   // ya pasó (demora)
  },
  {
    economico: 'ECO-202',
    origen: 'Querétaro',
    destino: 'Guadalajara',
    operador: 'Juan Pérez',
    equipo: 'Tracto 12',
    terminal: 'Terminal Sur',
    contenedor: 'Contenedor 20',
    cliente: 'Cliente Beta',
    tipoViaje: 'lleno',
    grupo: 'VUELTA',
    isForaneo: true,
    estimatedKm: 320,
    estimatedTime: '4:30',
    estimatedDelivery: '2026-02-17T16:00'   // en tiempo
  },
  {
    economico: 'ECO-203',
    origen: 'CDMX',
    destino: 'Monterrey',
    operador: 'Pedro Sánchez',
    equipo: 'Tracto 89',
    terminal: 'Terminal Norte',
    contenedor: 'Contenedor 40',
    cliente: 'Cliente Gamma',
    tipoViaje: 'vacio',
    grupo: 'VUELTA',
    isForaneo: true,
    estimatedKm: 860,
    estimatedTime: '11:50',
    estimatedDelivery: '2026-02-17T13:30'   // ya pasó (demora)
  },
  {
    economico: 'ECO-204',
    origen: 'CDMX',
    destino: 'Monterrey',
    operador: 'Luis Hernández',
    equipo: 'Tracto 52',
    terminal: 'Terminal Norte',
    contenedor: 'Contenedor 40',
    cliente: 'Cliente Alpha',
    tipoViaje: 'vacio',
    grupo: 'VUELTA',
    isForaneo: true,
    estimatedKm: 840,
    estimatedTime: '11:20',
    estimatedDelivery: '2026-02-17T14:45'   // próxima entrega
  },

  // GRUPO: MANTOO (locales → sin km/tiempo/entrega)
  {
    economico: 'ECO-301',
    origen: 'Monterrey',
    destino: 'Mantenimiento',
    operador: 'Roberto Díaz',
    equipo: 'Tracto 67',
    terminal: 'Terminal Norte',
    contenedor: 'Sin contenedor',
    cliente: 'Interno',
    tipoViaje: 'vacio',
    grupo: 'MANTOO',
    isForaneo: false,
    estimatedKm: null,
    estimatedTime: '',
    estimatedDelivery: null
  },
  {
    economico: 'ECO-302',
    origen: 'Guadalajara',
    destino: 'Mantenimiento',
    operador: 'Sofía Martínez',
    equipo: 'Tracto 19',
    terminal: 'Terminal Sur',
    contenedor: 'Sin contenedor',
    cliente: 'Interno',
    tipoViaje: 'vacio',
    grupo: 'MANTOO',
    isForaneo: false,
    estimatedKm: null,
    estimatedTime: '',
    estimatedDelivery: null
  },
  {
    economico: 'ECO-303',
    origen: 'CDMX',
    destino: 'Mantenimiento',
    operador: 'Miguel Torres',
    equipo: 'Tracto 90',
    terminal: 'Terminal Norte',
    contenedor: 'Sin contenedor',
    cliente: 'Interno',
    tipoViaje: 'vacio',
    grupo: 'MANTOO',
    isForaneo: false,
    estimatedKm: null,
    estimatedTime: '',
    estimatedDelivery: null
  },

  // GRUPO: MAOSA (foráneo)
  {
    economico: 'ECO-401',
    origen: 'Monterrey',
    destino: 'Saltillo',
    operador: 'Laura Fernández',
    equipo: 'Tracto 34',
    terminal: 'Terminal Norte',
    contenedor: 'Contenedor 20',
    cliente: 'Cliente Delta',
    tipoViaje: 'lleno',
    grupo: 'MAOSA',
    isForaneo: true,
    estimatedKm: 110,
    estimatedTime: '1:45',
    estimatedDelivery: '2026-02-17T10:30'   // ya pasó (demora)
  },
  {
    economico: 'ECO-402',
    origen: 'Saltillo',
    destino: 'Monterrey',
    operador: 'José Ruiz',
    equipo: 'Tracto 56',
    terminal: 'Terminal Norte',
    contenedor: 'Contenedor 20',
    cliente: 'Cliente Delta',
    tipoViaje: 'vacio',
    grupo: 'MAOSA',
    isForaneo: true,
    estimatedKm: 110,
    estimatedTime: '1:50',
    estimatedDelivery: '2026-02-17T15:00'   // en tiempo
  },
  {
    economico: 'ECO-403',
    origen: 'Monterrey',
    destino: 'Saltillo',
    operador: 'María López',
    equipo: 'Tracto 33',
    terminal: 'Terminal Norte',
    contenedor: 'Contenedor 20',
    cliente: 'Cliente Delta',
    tipoViaje: 'lleno',
    grupo: 'MAOSA',
    isForaneo: true,
    estimatedKm: 115,
    estimatedTime: '1:55',
    estimatedDelivery: '2026-02-17T12:45'   // ya pasó (demora)
  },
  {
    economico: 'ECO-404',
    origen: 'Saltillo',
    destino: 'Monterrey',
    operador: 'Carlos Ramírez',
    equipo: 'Tracto 45',
    terminal: 'Terminal Norte',
    contenedor: 'Contenedor 20',
    cliente: 'Cliente Delta',
    tipoViaje: 'vacio',
    grupo: 'MAOSA',
    isForaneo: true,
    estimatedKm: 110,
    estimatedTime: '1:40',
    estimatedDelivery: '2026-02-17T16:30'   // próxima entrega
  }
];
  ngOnInit() {
    this.treeData = this.getAllGroupedData();
  }
  private getAllGroupedData(): TreeGroup[] {
  const gruposMap = new Map<string, string[]>();

  this.allData.forEach(unidad => {
    if (!gruposMap.has(unidad.grupo)) {
      gruposMap.set(unidad.grupo, []);
    }
    gruposMap.get(unidad.grupo)!.push(unidad.economico);
  });

  let grupos = Array.from(gruposMap.entries())
    .map(([key, items]) => ({
      key,
      title: key,
      items
    }));

  // Ordenar grupos foráneos por estimatedKm (de menor a mayor)
  const foraneosGrupos = ['IDA', 'VUELTA', 'MAOSA']; // agrega todos los grupos foráneos que tengas

  grupos.forEach(grupo => {
    if (foraneosGrupos.includes(grupo.title)) {
      grupo.items.sort((a, b) => {
        const unidadA = this.allData.find(u => u.economico === a);
        const unidadB = this.allData.find(u => u.economico === b);
        return (unidadA?.estimatedKm || 999999) - (unidadB?.estimatedKm || 999999);
      });
    }
  });

  // Orden alfabético para grupos locales (opcional)
  return grupos.sort((a, b) => a.title.localeCompare(b.title));
}

  // Este método recibe los filtros del componente hijo
  onFiltersApplied(filters: any) {
    console.log('Filtros recibidos en el dashboard:', filters);

    // Si recibe { clear: true } → vaciamos el panel
    if (filters.clear) {
      this.treeData = this.getAllGroupedData();
      return;
    }
    // Filtramos los datos crudos
    let unidadesFiltradas = this.allData.filter(unidad => {
      return (
        (!filters.origen || unidad.origen === filters.origen) &&
        (!filters.destino || unidad.destino === filters.destino) &&
        (!filters.operador || unidad.operador === filters.operador) &&
        (!filters.equipo || unidad.equipo === filters.equipo) &&
        (!filters.terminal || unidad.terminal === filters.terminal) &&
        (!filters.contenedor || unidad.contenedor === filters.contenedor) &&
        (!filters.cliente || unidad.cliente === filters.cliente) &&
        (filters.tipoViaje.length === 0 || filters.tipoViaje.includes(unidad.tipoViaje))
      );
    });

    // Agrupamos por 'grupo' (IDA, VUELTA, MANTOO, etc.)
    const gruposMap = new Map<string, string[]>();

    unidadesFiltradas.forEach(unidad => {
      if (!gruposMap.has(unidad.grupo)) {
        gruposMap.set(unidad.grupo, []);
      }
      gruposMap.get(unidad.grupo)!.push(unidad.economico);
    });

    // Convertimos a formato TreeGroup
    this.treeData = Array.from(gruposMap.entries())
      .map(([key, items]) => ({
        key,
        title: key,
        items
      }))
      .sort((a, b) => a.title.localeCompare(b.title)); // orden alfabético opcional
  }
  showDetails(economico: string) {
    // Busca la unidad completa en allData
    this.selectedUnit = this.allData.find(u => u.economico === economico);

    if (this.selectedUnit) {
      this.showDetailsModal = true;
    }
  }
  // Método para cerrar el modal
  closeDetailsModal() {
    this.showDetailsModal = false;
    this.selectedUnit = null;
  }
  ngAfterViewInit() {
    if (this.useMap) {
      this.initMap();
    }
  }
  private initMap() {
    //listo para usar leaflet / google maps
    console.log('Mapa listo para inicializar');
  }

  toggleRight(key: string) {
    this.openGroupRight = this.openGroupRight === key ? null : key;
  }
  // Contar total de foráneos
getCountForaneo(): number {
  let count = 0;
  this.treeData.forEach(group => {
    if (this.isGroupForaneo(group)) {
      count += group.items.length;
    }
  });
  return count;
}

// Contar total de locales
getCountLocal(): number {
  let count = 0;
  this.treeData.forEach(group => {
    if (!this.isGroupForaneo(group)) {
      count += group.items.length;
    }
  });
  return count;
}

// Filtrar grupos foráneos
isGroupForaneo(group: TreeGroup): boolean {
  if (group.items.length === 0) return false;
  const economico = group.items[0]; // Tomamos el primero como referencia
  const unidad = this.allData.find(u => u.economico === economico);
  return unidad ? unidad.isForaneo : false;
}

getDeliveryStatus(economico: string): { text: string; class: string } | null {
  const unidad = this.allData.find(u => u.economico === economico);
  if (!unidad || !unidad.isForaneo || !unidad.estimatedDelivery) return null;

  const entrega = new Date(unidad.estimatedDelivery);
  const ahora = new Date();

  if (ahora > entrega) {
    const diffMin = Math.round((ahora.getTime() - entrega.getTime()) / 60000);
    return { text: `¡Retrasado! +${diffMin} min`, class: 'badge critical' };
  }

  const diffMin = Math.round((entrega.getTime() - ahora.getTime()) / 60000);

  if (diffMin <= 30) {
    return { text: `Próxima entrega (${diffMin} min)`, class: 'badge warning' };
  }

  if (diffMin <= 120) {
    return { text: 'En ruta', class: 'badge success' };
  }

  return { text: 'En ruta', class: 'badge success' };
}
}

