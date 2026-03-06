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
  expandedIndex: number | null = null;
  loading = true;
  errorMessage = '';
  searchTerm = '';
  filterEstatus = '';
  filterExecutive = '';
  currentPage = 1;
  pageSize = 15;

  executives: string[] = [];

  get paginatedCustomers(): any[] {
    const start = (this.currentPage - 1) * this.pageSize;
    return this.filteredCustomers.slice(start, start + this.pageSize);
  }

  get totalPages(): number {
    return Math.ceil(this.filteredCustomers.length / this.pageSize);
  }


  constructor(private customerService: CustomerService, private router: Router) {}

  async ngOnInit() {
    try {
      const res: any = await this.customerService.getallCustomer();
      this.customers = res.Data ?? [];
      this.filteredCustomers = [...this.customers];
      this.extractFilterOptions();
    } catch (err) {
      this.errorMessage = 'Error al cargar clientes';
      console.error(err);
    } finally {
      this.loading = false;
    }
  }

  searchCustomers() {
    this.applyFilters();
  }

  newClient() {
    this.router.navigate(['/dashboard/customer/new']);
  }

  editCustomer(id: number) {
    this.router.navigate(['/dashboard/customer/edit', id]);
  }

  toggleDetail(index: number) {
    this.expandedIndex = this.expandedIndex === index ? null : index;
  }

  extractFilterOptions() {
    this.executives = [...new Set(
      this.customers.map(c => c.actualExecutive?.fullName).filter(Boolean)
    )] as string[];
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.expandedIndex = null;
    }
  }

  applyFilters() {
    const term = this.searchTerm.toLowerCase().trim();

    this.filteredCustomers = this.customers.filter(c => {
      const matchSearch = !term ||
        (c.nickname ?? '').toLowerCase().includes(term) ||
        (c.rfcCompany ?? '').toLowerCase().includes(term) ||
        (c.companyName ?? '').toLowerCase().includes(term);

      const matchStatus = !this.filterEstatus ||
        (this.filterEstatus === 'con' && c.contractActual) ||
        (this.filterEstatus === 'sin' && !c.contractActual);

      const matchExec = !this.filterExecutive ||
        c.actualExecutive?.fullName === this.filterExecutive;

      return matchSearch && matchStatus && matchExec;
    });

    this.currentPage = 1;
  }
}