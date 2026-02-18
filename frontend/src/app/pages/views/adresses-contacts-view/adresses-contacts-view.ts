import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-adresses-contacts-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './adresses-contacts-view.html',
  styleUrl: './adresses-contacts-view.css',
})
export class AdressesContactsView {
  mostrarFormulario = false;
  @Input() formData: any;




  agregarDireccion() {
    if (this.formData.nuevaDireccion.nombre && this.formData.nuevaDireccion.direccion) {
      this.formData.direcciones.push({ ...this.formData.nuevaDireccion });

      // Limpiar formulario y ocultar
      this.formData.nuevaDireccion = {
        nombre: '',
        direccion: '',
        tipo: 'Fiscal',
        contacto: '',
        email: '',
        horario: '',
        mapaUrl: ''
      };
      this.mostrarFormulario = false;

      console.log('Dirección agregada:', this.formData.direcciones);
    } else {
      alert('Completa al menos Nombre y Dirección');
    }
  }

  // Eliminar (opcional, si quieres implementarlo después)
  eliminarDireccion(index: number) {
    this.formData.direcciones.splice(index, 1);
  }
  editarDireccion(index: number) {
    // Puedes implementar edición cargando datos en nuevaDireccion y mostrando formulario
    alert('Editar sucursal ' + (index + 1) + ' (funcionalidad pendiente)');
  }

}
