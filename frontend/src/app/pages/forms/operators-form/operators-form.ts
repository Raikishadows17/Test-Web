import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { OperatorsPersonalDataView } from "../../views/operators-personal-data-view/operators-personal-data-view";
import { OperatorsEmploymentDataView } from "../../views/operators-employment-data-view/operators-employment-data-view";
import { OperatorsCertificationsView } from "../../views/operators-certifications-view/operators-certifications-view";

@Component({
  selector: 'app-operators-from',
  imports: [CommonModule, FormsModule, OperatorsPersonalDataView, OperatorsEmploymentDataView, OperatorsCertificationsView],
  templateUrl: './operators-form.html',
  styleUrl: './operators-form.css',
})
export class OperatorsFrom {
  // Modelo del formulario
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

    options: {
      sexes: ['Masculino', 'Femenino'],
      maritalStatuses: ['Soltero', 'Casado', 'Unión Libre'],
      positions: ['Operador', 'Monitorista', 'Gerente', 'Mecánico', 'Auxiliar'],
      typeblood: ['A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-'],
      educationLevels: ['Primaria', 'Secundaria', 'Preparatoria', 'Licenciatura', 'Posgrado'],
    }
  };
  // Opciones de selects


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
  onlyLettersType(event: KeyboardEvent) {
    const pattern = /[A-Za-z]/;
    const inputChar = String.fromCharCode(event.charCode || event.keyCode);

    // Bloquea si ya hay 1 letra (maxlength=1 lo ayuda, pero reforzamos)
    if (this.formData.licenseType.length >= 1 || !pattern.test(inputChar)) {
      event.preventDefault();
    }
  }

}
