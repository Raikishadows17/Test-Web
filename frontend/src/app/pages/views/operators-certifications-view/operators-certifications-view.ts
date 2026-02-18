import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-operators-certifications-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './operators-certifications-view.html',
  styleUrl: './operators-certifications-view.css',
})
export class OperatorsCertificationsView {
  @Input() formData: any;
  selectedCertificadoForaneo = '';
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
  onCertificadoForaneoSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      console.log('Certificado Foráneo seleccionado:', file.name);
      this.selectedCertificadoForaneo = file.name;
      // Aquí puedes guardar el archivo en formData si lo necesitas
    }
  }
}
