import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-filters',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './filters.component.html',
  styleUrls: ['./filters.component.css']
})
export class FiltersComponent {
  @Output() filtersApplied = new EventEmitter<any>();

  collapsed = true;

  // Valores actuales de los filtros (usados en el template con ngModel)
  filters = {
    origen: '',
    destino: '',
    operador: '',
    equipo: '',
    terminal: '',
    contenedor: '',
    cliente: '',
    tipoViajeLleno: false,
    tipoViajeVacio: false
  };

  showModal = false;
  modalMessage = '';

  // Opciones para los selects (puedes cargarlas desde un servicio después)
  options = {
    origenes: ['Monterrey', 'Guadalajara', 'CDMX', 'Querétaro', 'Saltillo'],
    destinos: ['CDMX', 'Querétaro', 'Monterrey', 'Guadalajara', 'Mantenimiento', 'Saltillo'],
    operadores: [
      'Juan Pérez',
      'Luis Hernández',
      'María López',
      'Carlos Ramírez',
      'Ana Gómez',
      'Pedro Sánchez',
      'Roberto Díaz',
      'Sofía Martínez',
      'Miguel Torres',
      'Laura Fernández',
      'José Ruiz'
    ],
    equipos: [
      'Tracto 45',
      'Tracto 52',
      'Tracto 33',
      'Tracto 78',
      'Tracto 12',
      'Tracto 89',
      'Tracto 67',
      'Tracto 19',
      'Tracto 90',
      'Tracto 34',
      'Tracto 56'
    ],
    terminales: ['Terminal Norte', 'Terminal Sur'],
    contenedores: ['Contenedor 40', 'Contenedor 20', 'Sin contenedor'],
    clientes: ['Cliente Alpha', 'Cliente Beta', 'Cliente Gamma', 'Interno', 'Cliente Delta']
  };

  applyFilters() {
    // Construimos el array de tipo de viaje
    const tipoViaje: string[] = [];
    if (this.filters.tipoViajeLleno) tipoViaje.push('lleno');
    if (this.filters.tipoViajeVacio) tipoViaje.push('vacio');

    const hasActiveFilter =
      this.filters.origen ||
      this.filters.destino ||
      this.filters.operador ||
      this.filters.equipo ||
      this.filters.terminal ||
      this.filters.contenedor ||
      this.filters.cliente ||
      tipoViaje.length > 0;

    if (hasActiveFilter) {
      // Hay filtros → emitimos normal
      const appliedFilters = {
        origen: this.filters.origen || null,
        destino: this.filters.destino || null,
        operador: this.filters.operador || null,
        equipo: this.filters.equipo || null,
        terminal: this.filters.terminal || null,
        contenedor: this.filters.contenedor || null,
        cliente: this.filters.cliente || null,
        tipoViaje
      };
      this.filtersApplied.emit(appliedFilters);
    } else {
      // NUEVO: No hay filtros → mostramos toast
      this.modalMessage = 'Por favor, selecciona al menos un filtro para continuar.';
      this.showModal = true;
    }
  }
  // Método para cerrar el modal
  closeModal() {
    this.showModal = false;
  }
  clearFilters() {
    this.filters = {
      origen: '',
      destino: '',
      operador: '',
      equipo: '',
      terminal: '',
      contenedor: '',
      cliente: '',
      tipoViajeLleno: false,
      tipoViajeVacio: false
    };

    // Emitimos filtros completamente vacíoViaje:
    this.filtersApplied.emit({ clear: true });
    this.showModal = false;
  }
  toggleCollapse() {
    this.collapsed = !this.collapsed;
  }
}
