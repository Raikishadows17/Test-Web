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
    // GRUPO: IDA
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
      isForaneo: true
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
      isForaneo: true
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
      isForaneo: true
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
      isForaneo: true
    },

    // GRUPO: VUELTA
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
      isForaneo: true
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
      isForaneo: true
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
      isForaneo: true
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
      isForaneo: true
    },

    // GRUPO: MANTOO
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
      isForaneo: false
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
      isForaneo: false
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
      isForaneo: false
    },

    // GRUPO: MAOSA
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
      isForaneo: true
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
      isForaneo: true
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
      isForaneo: true
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
      isForaneo: true
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

    return Array.from(gruposMap.entries())
      .map(([key, items]) => ({
        key,
        title: key,
        items
      }))
      .sort((a, b) => a.title.localeCompare(b.title));
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
}

