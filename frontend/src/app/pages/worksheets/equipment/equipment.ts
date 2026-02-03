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

  loading = true;
  errorMessage = '';
  searchTerm = '';

  constructor(private equipmentService: EquipmentService, private router: Router) { }

  async ngOnInit() {
    try {
      const res: any = await this.equipmentService.getAllEquipments();
      console.log("RESP API:", res);
      this.equipments = res.Data ?? [];
      this.filteredEquipments = [...this.equipments];
    } catch (err) {
      this.errorMessage = 'Error al cargar clientes';
      console.error(err);
    } finally {
      this.loading = false;
    }
  }
  searchEquipment() {
    const term = this.searchTerm.toLowerCase().trim();

    this.filteredEquipments = this.equipments.filter(c =>
      c.numero_Economico.toLowerCase().includes(term) ||
      c.plates.toLowerCase().includes(term)
    );
  }
  newEquipment() {
    this.router.navigate(['/dashboard/equipment/new']);
  }

}
