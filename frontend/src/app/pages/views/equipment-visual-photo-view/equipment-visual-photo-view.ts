import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-equipment-visual-photo-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './equipment-visual-photo-view.html',
  styleUrl: './equipment-visual-photo-view.css',
})
export class EquipmentVisualPhotoView {
  @Input() formData : any;
}
