import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-equipment-general-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './equipment-general-view.html',
  styleUrl: './equipment-general-view.css',
})
export class EquipmentGeneralView {
  @Input() formData : any;
  profilePhotoPreview: string | null = null;
  profilePhotoFileName: string = '';
  constructor() {}

onImageSelected(event: Event): void {
  const input = event.target as HTMLInputElement;
  if (input.files && input.files[0]) {
    const file = input.files[0];

    // Preview local inmediato
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.formData.imagePreview = e.target.result;
    };
    reader.readAsDataURL(file);

    // Guardar archivo para enviar al backend
    this.formData.imageFile = file;

    // Si ya tiene una URL guardada, la mantenemos hasta que se guarde
    // Si quieres mostrar el preview en lugar de la URL actual:
    // this.formData.imageURL = null;
  }
}

}
