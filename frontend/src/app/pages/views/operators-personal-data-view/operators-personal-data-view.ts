import { CommonModule } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-operators-personal-data-view',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './operators-personal-data-view.html',
  styleUrl: './operators-personal-data-view.css',
})
export class OperatorsPersonalDataView implements OnInit {
  @Input() formData: any;
  curpError: string | null = null;
  profilePhotoPreview: string | null = null;
  profilePhotoFileName = '';


  async ngOnInit() {
    if (this.formData.photoUrl) {
      this.profilePhotoPreview = this.formData.photoUrl;
    }
  }

  onlyNumbers(event: KeyboardEvent) {
    const pattern = /[0-9]/;
    const inputChar = String.fromCharCode(event.charCode);
    if (!pattern.test(inputChar)) event.preventDefault();
  }

  onlyLetters(event: KeyboardEvent) {
    const pattern = /[A-Za-zÁÉÍÓÚáéíóúÑñ\s]/;
    const inputChar = String.fromCharCode(event.charCode);
    if (!pattern.test(inputChar)) event.preventDefault();
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

    const month = curp.substring(6, 8);
    const day = curp.substring(8, 10);
    if (Number(month) < 1 || Number(month) > 12 || Number(day) < 1 || Number(day) > 31) {
      this.curpError = 'Fecha de nacimiento en CURP parece inválida';
      return;
    }

    this.curpError = null;
  }

  
  formatCurp(event: any) {
    let value = event.target.value.toUpperCase().replace(/[^A-Z0-9]/g, '');
    if (value.length > 18) value = value.substring(0, 18);
    event.target.value = value;
    this.formData.curp = value;
  }

  onProfilePhotoSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.profilePhotoFileName = file.name;
      this.formData.photoFile = file;

      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.formData.photoPreview = e.target.result;
      };
      reader.readAsDataURL(file);
    }
  }
}