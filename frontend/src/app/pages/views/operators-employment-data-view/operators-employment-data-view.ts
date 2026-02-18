import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-operators-employment-data-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './operators-employment-data-view.html',
  styleUrl: './operators-employment-data-view.css',
})
export class OperatorsEmploymentDataView {
  @Input() formData: any;

}
