import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingService } from '../loading/loading.service';

@Component({
  selector: 'app-spinner',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="overlay" *ngIf="loadingService.loading$ | async">
      <div class="loader"></div>
    </div>
  `,
  styleUrls: ['../spinner/spinner.css']
})
export class SpinnerComponent {
  constructor(public loadingService: LoadingService) {}
}
