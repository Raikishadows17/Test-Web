import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-equipment-visual-photo-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './equipment-visual-photo-view.html',
  styleUrl: './equipment-visual-photo-view.css',
})
export class EquipmentVisualPhotoView {
  @Input() formData : any;
  selectedFacturaCompra = '';
  selectedTituloCompra = '';
  selectedDocSeguro = '';

  // Métodos para selección de archivos
  onFacturaCompraSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedFacturaCompra = file.name;
    }
  }

  onTituloCompraSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedTituloCompra = file.name;
    }
  }

  onDocFileSelected(event: any, docKey: string) {
    const file = event.target.files[0];
    if (!file) return;
    this.formData.docs[docKey].file = file;
    this.formData.docs[docKey].fileName = file.name;
  }

  getImageUrl(url: string): string {
    if (!url) return '';
    if (url.startsWith('data:')) return url; // preview base64
    return `${environment.apiURL}${url}`;
  }

  onDocSeguroSelected(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedDocSeguro = file.name;
    }
  }

  onGalleryImageSelected(event: any, position: string) {
    const file = event.target.files[0];
    if (!file) return;

    const reader = new FileReader();
    reader.onload = (e: any) => {
      switch (position) {
        case 'front': this.formData.imageURLFront = e.target.result; break;
        case 'side':  this.formData.imageURLSide = e.target.result; break;
        case 'back':  this.formData.imageURLBack = e.target.result; break;
        case 'up':    this.formData.imageURLUp = e.target.result; break;
      }
    };
    reader.readAsDataURL(file);

    if (!this.formData.imageFiles) this.formData.imageFiles = {};
    this.formData.imageFiles[position] = file;
  }

}
