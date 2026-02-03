import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { routes } from '../../app.routes';

interface MenuItem {
  icon?: string;
  label: string;
  route?: string;
  children?: MenuItem[];
  isOpen?: boolean;
}

@Component({
  selector: 'app-sidebar',
  imports: [CommonModule],
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
})

export class Sidebar {
  @Input() collapsed = false;
  @Output() toggle = new EventEmitter<void>();

  constructor(private router: Router) { }

  menuItems: MenuItem[] = [
    {
      icon: 'dashboard',
      label: 'DASHBOARD STRATEGIC',
      isOpen: false,
      children: [
        {
          label: 'Tablero',
          route: '/dashboard/strategic'
        }
      ]
    },
    {
      icon: 'assignment',
      label: 'HOJA DE TRABAJO',
      isOpen: false,
      children: [
        {
          label: 'Solicitudes de servicio',
          route: '/dashboard/service-request'
        },
        { label: 'Operadores',
          route: '/dashboard/operator'
         },
        { label: 'Equipos',
          route: '/dashboard/equipment'
        },
        { label: 'Clientes',
          route: '/dashboard/customer'
        },
        { label: 'Tarifas' },
        { label: 'Concilación servicio' },
        { label: 'Facturación' },
      ]
    },
    {
      icon: 'dashboard',
      label: 'DASHBOARD ANALYSIS',
      isOpen: false,
      children: [
        { label: 'Tablero',
          route: '/dashboard/analysis'
         }
      ]
    },
    {
      icon: 'person',
      label: 'ADMIN',
      isOpen: false,
      children: [
        { label: 'Configuración' },
        { label: 'Cerrar Sesion' }
      ]
    },
  ];
  toggleMenu() {
    this.collapsed = !this.collapsed;
  }
  toggleSidebar() {
    this.toggle.emit();
  }

  toggleItem(item: MenuItem) {
    if (!this.collapsed && item.children) {
      item.isOpen = !item.isOpen;
      return;
    }
    if (item.route) {
      this.router.navigateByUrl(item.route);
    }
  }
  goHome() {
    this.router.navigate(['/dashboard']);
  }
  navigate(route?: string) {
    if (!route) return;
    this.router.navigateByUrl(route);
  }

}
