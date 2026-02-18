import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-services-orden-operational-monitoring-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './services-orden-operational-monitoring-view.html',
  styleUrl: './services-orden-operational-monitoring-view.css',
})
export class ServicesOrdenOperationalMonitoringView {
  @Input() formData: any;
}
