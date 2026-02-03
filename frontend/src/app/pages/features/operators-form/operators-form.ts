import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-operators-from',
  imports: [CommonModule, FormsModule],
  templateUrl: './operators-form.html',
  styleUrl: './operators-form.css',
})
export class OperatorsFrom {
  // Modelo del formulario
  curpError: string | null = null;
  selectedCertificadoForaneo = '';
  profilePhotoPreview: string | null = null;
  profilePhotoFileName: string = '';
  formData = {
    name: '',
    fatherLastName: '',
    motherLastName: '',
    rfc: '',
    curp: '',
    nss: '',
    birthDate: '',
    sex: '',
    maritalStatus: '',
    position: '',
    hireDate: '',
    downDate: '',
    dailySalary: '',
    isUnionMember: false,
    status: '',
    licenseNumber: '',
    licenseExpiration: '',
    licenseType: '',
    medicalCertificateExpiration: '',
    medicalCertificateFolio: '',
    okCompania: '',
    okTelefono: '',
    okTelefonoEmergencia: '',
    okDireccion: '',
    okTipoSangre: '',
    okNivelEstudios: '',
    okIne: '',
    okFkCertificadoForaneo: null,
    okRol: '',
    okFotoUrl: '',
    okCodigoPostal: '',

    // VIGENCIAS Y ESTADOS
    okVencimientoVigencias: '',
    okIdTerminalBloqueo: '',
    okFechaInicioBloqueo: '',
    okFechaFinBloqueo: '',
    okIncapacitado: false,
    okFechaInicioIncapacidad: '',
    okFechaFinIncapacidad: '',
  };
  // Opciones de selects
  sexes = ['Masculino', 'Femenino'];
  maritalStatuses = ['Soltero', 'Casado', 'Unión Libre'];
  positions = ['Operador', 'Monitorista', 'Gerente', 'Mecánico', 'Auxiliar'];

  onSubmit() {
    if (this.formData.name && this.formData.fatherLastName && this.formData.rfc) {
      console.log('Formulario de operador enviado:', this.formData);
      alert('Operador guardado con éxito');
    } else {
      alert('Completa los campos obligatorios (*)');
    }
  }
  onlyLetters(event: KeyboardEvent) {
    const pattern = /[A-Za-zÁÉÍÓÚáéíóúÑñ\s]/;
    const inputChar = String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
  onlyNumbers(event: KeyboardEvent) {
    const pattern = /[0-9]/;
    const inputChar = String.fromCharCode(event.charCode);

    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }

  formatCurp(event: any) {
    let value = event.target.value.toUpperCase().replace(/[^A-Z0-9]/g, '');
    if (value.length > 18) value = value.substring(0, 18);
    event.target.value = value;
    this.formData.curp = value;
  }

  validateCurp() {
    const curp = this.formData.curp?.trim().toUpperCase();
    if (!curp) {
      this.curpError = null;
      return;
    }

    const curpRegex = /^[A-Z]{4}[0-9]{6}[HM][A-Z]{5}[0-9A-Z][0-9]$/;
    if (!curpRegex.test(curp)) {
      this.curpError = 'Formato de CURP inválido (deben ser 18 caracteres)';
      return;
    }

    // Validación básica extra (opcional): fecha de nacimiento
    const year = curp.substring(4, 6);
    const month = curp.substring(6, 8);
    const day = curp.substring(8, 10);
    const currentYear = new Date().getFullYear() % 100;

    if (Number(year) > currentYear + 10 || Number(month) < 1 || Number(month) > 12 || Number(day) < 1 || Number(day) > 31) {
      this.curpError = 'Fecha de nacimiento en CURP parece inválida';
      return;
    }

    this.curpError = null;
  }
  onlyLettersType(event: KeyboardEvent) {
    const pattern = /[A-Za-z]/;
    const inputChar = String.fromCharCode(event.charCode || event.keyCode);

    // Bloquea si ya hay 1 letra (maxlength=1 lo ayuda, pero reforzamos)
    if (this.formData.licenseType.length >= 1 || !pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
  onCertificadoForaneoSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      console.log('Certificado Foráneo seleccionado:', file.name);
      this.selectedCertificadoForaneo = file.name;
      // Aquí puedes guardar el archivo en formData si lo necesitas
    }
  }
  onProfilePhotoSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.profilePhotoFileName = file.name;

      // Crear previsualización
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.profilePhotoPreview = e.target.result; // base64 para mostrar
      };
      reader.readAsDataURL(file);

      // Opcional: guardar el archivo real si lo vas a subir al backend
      // this.formData.profilePhotoFile = file;
    }
  }
}
