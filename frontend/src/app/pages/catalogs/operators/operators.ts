import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OperatorService } from './operators.service';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-operators',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './operators.html',
  styleUrl: './operators.css',
})
export class Operators implements OnInit {
  searchTerm = '';
  operadores: any[] = [];
  filteredOperators: any[] = [];
  expandedIndex: number | null = null;
  executives: string[] = [];
  companies: string[] = [];
  errorMessage = '';
  filterExecutive = '';
  filterCompany = '';
  filterLicense = '';
  filterStatus = '';
  filterCertForeign = '';
  loading = true;
  currentPage = 1;
  pageSize = 15;

  get paginatedOperators(): any[] {
    const start = (this.currentPage - 1) * this.pageSize;
    return this.filteredOperators.slice(start, start + this.pageSize);
  }

  get totalPages(): number {
    return Math.ceil(this.filteredOperators.length / this.pageSize);
  }

  constructor(private router: Router, private operatorService: OperatorService) {}

  async ngOnInit() {
    try {
      const res: any = await this.operatorService.getallOperator();
      this.operadores = res.Data ?? [];
      this.filteredOperators = [...this.operadores];
      this.extractFilterOptions();
    } catch (err) {
      this.errorMessage = 'Error al cargar operadores';
      console.error(err);
    } finally {
      this.loading = false;
    }
  }

  extractFilterOptions() {
    this.executives = [...new Set(
      this.operadores.map(o => o.actualExecutive?.fullName).filter(Boolean)
    )] as string[];

    this.companies = [...new Set(
      this.operadores.map(o => o.company).filter(Boolean)
    )] as string[];
  }

  newOperator() {
    this.router.navigate(['/dashboard/operator/new']);
  }

  editOperator(id: number) {
    this.router.navigate(['/dashboard/operator/edit', id]);
  }

  toggleDetail(index: number) {
    this.expandedIndex = this.expandedIndex === index ? null : index;
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.expandedIndex = null;
    }
  }

  searchOperator() {
    this.applyFilters();
  }

  applyFilters() {
    const term = this.searchTerm.toLowerCase().trim();

    this.filteredOperators = this.operadores.filter(op => {
      const matchSearch = !term ||
        (op.fullName ?? '').toLowerCase().includes(term) ||
        (op.rfc ?? '').toLowerCase().includes(term) ||
        (op.employeeNumber ?? '').toLowerCase().includes(term);

      const matchExec = !this.filterExecutive ||
        op.actualExecutive?.fullName === this.filterExecutive;

      const matchCompany = !this.filterCompany ||
        op.company === this.filterCompany;

      const matchLicense = !this.filterLicense ||
        (this.filterLicense === 'con' && op.driveLicense) ||
        (this.filterLicense === 'sin' && !op.driveLicense);

      const matchStatus = !this.filterStatus ||
        (this.filterStatus === 'activo' && !op.terminationDate) ||
        (this.filterStatus === 'baja' && op.terminationDate);

      const matchCertForeign = !this.filterCertForeign ||
        (this.filterCertForeign === 'si' && op.certificatedForeignDriver) ||
        (this.filterCertForeign === 'no' && !op.certificatedForeignDriver);

      return matchSearch && matchExec && matchCompany
        && matchLicense && matchStatus && matchCertForeign;
    });

    this.currentPage = 1;
  }

  onImageError(event: any) {
    event.target.style.display = 'none';
  }
}