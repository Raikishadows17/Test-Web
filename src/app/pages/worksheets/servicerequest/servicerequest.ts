import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-servicerequest',
  imports: [],
  templateUrl: './servicerequest.html',
  styleUrl: './servicerequest.css',
})
export class Servicerequest {
  constructor(private router: Router) { }
  newService() {
    this.router.navigate(['/dashboard/service-request/new']);
  }
}
