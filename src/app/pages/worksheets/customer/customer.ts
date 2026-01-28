import { Component, OnInit } from '@angular/core';
import { CustomerService } from './customer.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './customer.html',
  styleUrl: './customer.css',
})
export class Customer implements OnInit {
  customers: any[] = [];
  filteredCustomers: any[] = [];

  loading = true;
  errorMessage = '';
  searchTerm = '';

  constructor(private customerService: CustomerService, private router: Router) { }

  async ngOnInit() {
    try {
      const res: any = await this.customerService.getallCustomer();
      console.log("RESP API:", res);
      this.customers = res.Data ?? [];
      this.filteredCustomers = [...this.customers];
    } catch (err) {
      this.errorMessage = 'Error al cargar clientes';
      console.error(err);
    } finally {
      this.loading = false;
    }
  }
  searchCustomers() {
    const term = this.searchTerm.toLowerCase().trim();

    this.filteredCustomers = this.customers.filter(c =>
      c.name.toLowerCase().includes(term) ||
      c.rfc.toLowerCase().includes(term)
    );
  }
  newClient() {
    this.router.navigate(['/dashboard/customer/new']);
  }


}
