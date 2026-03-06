import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-operators-certifications-view',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './operators-certifications-view.html',
  styleUrl: './operators-certifications-view.css',
})
export class OperatorsCertificationsView {
  @Input() formData: any;

  onlyNumbers(event: KeyboardEvent) {
    const pattern = /[0-9]/;
    const inputChar = String.fromCharCode(event.charCode);
    if (!pattern.test(inputChar)) event.preventDefault();
  }

  onLicenseFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.formData.licenseFileName = file.name;
      this.formData.licenseFile = file;
    }
  }

  getImageUrl(path: string): string {
    return `${environment.apiURL}${path}`;
  }

  onForeignCertFileSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.formData.foreignCertFileName = file.name;
      this.formData.foreignCertificateFile = file;
    }
  }
}