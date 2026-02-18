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

  constructor() {}

}
