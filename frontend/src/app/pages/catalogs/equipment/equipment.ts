import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EquipmentService } from './equipment.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-equipment',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './equipment.html',
  styleUrls: ['./equipment.css'],
  
})
export class Equipment implements OnInit {
  equipments: any[] = [];
  filteredEquipments: any[] = [];
  expandedIndex: number | null = null;
  loading = true;
  errorMessage = '';
  searchTerm = '';
  filterForaneo = '';
  filterEquipType = '';
  filterStatus = '';
  filterTerminal = '';
  currentPage = 1;
  pageSize = 15;


  equipmentTypes: string[] = [];
  equipmentStatuses: string[] = [];
  terminals: string[] = [];

  constructor(private equipmentService: EquipmentService, private router: Router) { }

  async ngOnInit() {
    try {
        const res: any = await this.equipmentService.getAllEquipments();
        this.equipments = res.Data ?? [];
        this.filteredEquipments = [...this.equipments];
        this.extractFilterOptions();
      } catch (err) {
        this.errorMessage = 'Error al cargar equipos';
        console.error(err);
      } finally {
        this.loading = false;
      }
  }

    get paginatedEquipments(): any[] {
      const start = (this.currentPage - 1) * this.pageSize;
      return this.filteredEquipments.slice(start, start + this.pageSize);
    }

    get totalPages(): number {
      return Math.ceil(this.filteredEquipments.length / this.pageSize);
    }
  
  searchEquipment() {
    this.applyFilters();
  }
  newEquipment() {
    this.router.navigate(['/dashboard/equipment/new']);
  }

  toggleDetail(index: number) {
  this.expandedIndex = this.expandedIndex === index ? null : index;
  }

  extractFilterOptions() {
    this.equipmentTypes = [...new Set(
      this.equipments.map(e => e.equipmentType?.name).filter(Boolean)
    )] as string[];

    this.equipmentStatuses = [...new Set(
      this.equipments.map(e => e.equipmentStatus?.name).filter(Boolean)
    )] as string[];

    this.terminals = [...new Set(
      this.equipments.map(e => e.terminal?.nameTerminal).filter(Boolean)
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

    this.filteredEquipments = this.equipments.filter(c => {
      const matchSearch = !term ||
        (c.economicNumber ?? '').toLowerCase().includes(term) ||
        (c.plates ?? '').toLowerCase().includes(term);

      const matchForaneo = !this.filterForaneo ||
        (this.filterForaneo === 'si' && c.tripType?.id === 2) ||
        (this.filterForaneo === 'no' && c.tripType?.id !== 2);

      const matchType = !this.filterEquipType ||
        c.equipmentType?.name === this.filterEquipType;

      const matchStatus = !this.filterStatus ||
        c.equipmentStatus?.name === this.filterStatus;

      const matchTerminal = !this.filterTerminal ||
        c.terminal?.nameTerminal === this.filterTerminal;

      return matchSearch && matchForaneo && matchType && matchStatus && matchTerminal;
    });
  }

}
