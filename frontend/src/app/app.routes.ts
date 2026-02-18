import { Routes, Router } from '@angular/router';
import { inject } from '@angular/core';

import { LoginPage } from './pages/login/login';
import { HomePage } from './pages/home/home';
import { Servicerequest } from './pages/catalogs/servicerequest/servicerequest';
import { authGuard } from './auth/auth.guard';
import { Customer } from './pages/catalogs/customer/customer';
import { Equipment } from './pages/catalogs/equipment/equipment';
import { DashboardStrategic } from './pages/catalogs/dashboard-strategic/dashboard-strategic';
import { EquipmentCatalogForm } from './pages/forms/equipment-catalog-form/equipment-catalog-form';
import { OperatorsFrom } from './pages/forms/operators-form/operators-form';
import { ServiceOrdersForm } from './pages/forms/service-orders-form/service-orders-form';
import { Operators } from './pages/catalogs/operators/operators';
import { ClientsContractsForm } from './pages/forms/clients-contracts-form/clients-contracts-form';
import { DashboardAnalysis } from './pages/catalogs/dashboard-analysis/dashboard-analysis';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
  {
    path: 'login',
    component: LoginPage,
    canActivate: [() => {
      const router = inject(Router);
      const hasToken = localStorage.getItem('token');

      return hasToken ? router.parseUrl('/dashboard') : true;
    }]
  },
  {
    path: 'dashboard',
    component: HomePage,
    canActivate: [authGuard],
    children: [
      { path: 'strategic', component: DashboardStrategic },
      { path: 'analysis', component: DashboardAnalysis },
      {
        path: 'service-request',
        children: [
          { path: '', component: Servicerequest },
          { path: 'new', component: ServiceOrdersForm },
          { path: 'edit/:folio', component: ServiceOrdersForm }
        ]
      },
      { path: 'customer',
        children: [
          { path: '', component: Customer },
          { path: 'new', component: ClientsContractsForm },
          { path: 'edit/:id', component: ClientsContractsForm }
        ]
      },
      { path: 'equipment',
        children: [
          { path: '', component: Equipment },
          { path: 'new', component: EquipmentCatalogForm },
          { path: 'edit/:id', component: EquipmentCatalogForm }
        ]
       },
      {
        path: 'operator',
        children: [
          { path: '', component: Operators },
          { path: 'new', component: OperatorsFrom },
          { path: 'edit/:id', component: OperatorsFrom }
        ]
      },
    ]
  },
  { path: '**', redirectTo: 'login' }
];
