import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-clients-contracts-form',
  imports: [CommonModule, FormsModule],
  templateUrl: './clients-contracts-form.html',
  styleUrl: './clients-contracts-form.css',
})
export class ClientsContractsForm {
  activeTab = 1;
  selectedConstancia = '';
  mostrarFormulario = false;

  formData = {
    rfc: '',
    razonSocial: '',
    nombreComercial: '',
    industria: '',
    estatus: '',
    clienteFinal: false,
    freightForwarder: false,
    ejecutivoCuenta: '',
    terminosPago: '',
    limiteCredito: 0,
    inicioContrato: '',
    finContrato: '',
    moneda: '',
    tipoContrato: '',
    fleteLocal: 0,
    estadiaDia: 0,
    pernocta: 0,
    movimientoFalso: 0,
    repartoAdicional: 0,
    diasLibresCarga: 0,
    diasLibresDescarga: 0,
    maniobraIMO: '',
    requierePortalesCita: false,
    rutas: [
      {
        origen: 'Lázaro Cárdenas, MICH',
        destino: 'Cuautitlán, MEX',
        tipoUnidad: "Sencillo 40'",
        tarifa: 28500.00
      }
    ] as { origen: string; destino: string; tipoUnidad: string; tarifa: number }[]
  };
  nuevaDireccion = {
    nombre: '',
    direccion: '',
    tipo: 'Fiscal',
    contacto: '',
    email: '',
    horario: '',
    mapaUrl: ''
  };
  direcciones = [
    {
      nombre: 'Oficinas Centrales',
      direccion: 'Av. Reforma 222, Col. Juárez, CP 06600, CDMX',
      tipo: 'Fiscal',
      contacto: 'Lic. Finanzas',
      email: 'facturacion@cliente.com',
      horario: 'L-V 8:00 - 18:00',
      mapaUrl: ''
    }
  ];

  //Opciones
  industrias = ['Automotriz', 'Retail', 'Alimentos', 'Electrónica', 'Agro'];
  estatuses = ['Activo', 'Prospecto', 'Suspendido', 'Baja'];
  ejecutivos = ['Ana García', 'Carlos Ruiz', 'Ventas General'];
  terminosPago = ['Contado (Anticipado)', 'Crédito 15 días', 'Crédito 30 días', 'Crédito 45 días'];
  monedas = ['MXN - Pesos Mexicanos', 'USD - Dólares Americanos'];
  tiposContrato = ['Indefinido', 'Por Proyecto', 'Temporada Alta'];
  tiposUnidad = ['Sencillo 40\'', 'Doble 40\'', 'Refrigerado', 'Plana', 'Tolva', 'Otro'];

  setActiveTab(tab: number) {
    this.activeTab = tab;
  }

  onSubmit() {
    console.log('Cliente/Contrato guardado:', this.formData);
    alert('Registro guardado');
  }
  // Métodos para rutas
  addRuta() {
    this.formData.rutas.push({
      origen: '',
      destino: '',
      tipoUnidad: '',
      tarifa: 0
    });
  }

  removeRuta(index: number) {
    this.formData.rutas.splice(index, 1);
  }

  editRuta(index: number) {
    // Puedes implementar edición en línea o modal
    alert('Editar ruta ' + (index + 1) + ' (implementar funcionalidad)');
  }


  addDireccion() {
    alert('Función para agregar nueva dirección (implementar)');
  }
  onConstanciaSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedConstancia = file.name;
    }
  }
  onlyLettersWithSpaces(event: KeyboardEvent) {
    const pattern = /[A-Za-zÁÉÍÓÚáéíóúÑñ\s]/;
    const inputChar = String.fromCharCode(event.charCode || event.keyCode);

    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }

  formatRfc(event: any) {
    let value = event.target.value.toUpperCase().replace(/[^A-Z0-9]/g, ''); // Solo A-Z y 0-9
    if (value.length > 13) value = value.substring(0, 13);
    event.target.value = value;
    this.formData.rfc = value;
  }

  // Bloquea caracteres no permitidos en RFC mientras se escribe
  onlyRfcChars(event: KeyboardEvent) {
    const pattern = /[A-Z0-9]/;
    const inputChar = String.fromCharCode(event.charCode || event.keyCode);

    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
  validateRfc() {
    const rfc = this.formData.rfc?.trim().toUpperCase();
    if (!rfc) return;

    const rfcRegex = /^[A-Z]{4}[0-9]{6}[A-Z0-9]{3}$/;
    if (!rfcRegex.test(rfc)) {
      alert('RFC inválido: debe ser 4 letras + 6 números + 3 alfanuméricos (13 caracteres)');
    }
  }
  agregarDireccion() {
    if (this.nuevaDireccion.nombre && this.nuevaDireccion.direccion) {
      this.direcciones.push({ ...this.nuevaDireccion });

      // Limpiar formulario y ocultar
      this.nuevaDireccion = {
        nombre: '',
        direccion: '',
        tipo: 'Fiscal',
        contacto: '',
        email: '',
        horario: '',
        mapaUrl: ''
      };
      this.mostrarFormulario = false;

      console.log('Dirección agregada:', this.direcciones);
    } else {
      alert('Completa al menos Nombre y Dirección');
    }
  }

  // Eliminar (opcional, si quieres implementarlo después)
  eliminarDireccion(index: number) {
    this.direcciones.splice(index, 1);
  }
  editarDireccion(index: number) {
    // Puedes implementar edición cargando datos en nuevaDireccion y mostrando formulario
    alert('Editar sucursal ' + (index + 1) + ' (funcionalidad pendiente)');
  }
}
