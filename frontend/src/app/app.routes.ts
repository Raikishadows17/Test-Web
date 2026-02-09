import { Routes, Router } from '@angular/router';
import { inject } from '@angular/core';

import { LoginPage } from './pages/login/login';
import { HomePage } from './pages/home/home';
import { Servicerequest } from './pages/worksheets/servicerequest/servicerequest';
import { authGuard } from './auth/auth.guard';
import { Customer } from './pages/worksheets/customer/customer';
import { Equipment } from './pages/worksheets/equipment/equipment';
import { DashboardStrategic } from './pages/worksheets/dashboard-strategic/dashboard-strategic';
import { EquipmentCatalogForm } from './pages/features/equipment-catalog-form/equipment-catalog-form';
import { OperatorsFrom } from './pages/features/operators-form/operators-form';
import { ServiceOrdersForm } from './pages/features/service-orders-form/service-orders-form';
import { Operators } from './pages/worksheets/operators/operators';
import { ClientsContractsForm } from './pages/features/clients-contracts-form/clients-contracts-form';
import { DashboardAnalysis } from './pages/worksheets/dashboard-analysis/dashboard-analysis';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },

  {
    path: 'dashboard',
    component: HomePage,
    children: [
      { path: 'strategic', component: DashboardStrategic },
      { path: 'analysis', component: DashboardAnalysis },
      {
        path: 'service-request',
        children: [
          { path: '', component: Servicerequest },
          { path: 'new', component: ServiceOrdersForm },
          { path: 'edit/:id', component: ServiceOrdersForm }
        ]
      },
      { path: 'customer',
        children: [
          { path: '', component: Customer },
          { path: 'new', component: ClientsContractsForm }
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
          { path: 'new', component: OperatorsFrom }
        ]
      },
    ]
  },
  { path: '**', redirectTo: 'login' }
];
