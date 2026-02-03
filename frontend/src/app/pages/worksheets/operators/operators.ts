import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-operators',
  imports: [CommonModule, FormsModule],
  templateUrl: './operators.html',
  styleUrl: './operators.css',
})
export class Operators {
  constructor(private router: Router) { }
  searchTerm = '';
  operadores = [
    {
      nombre: 'Juan Carlos Pérez López',
      rfc: 'PELJ850715HDF',
      curp: 'PELJ850715HDFRRN09',
      nss: '12345678901',
      puesto: 'Operador Tracto',
      fechaIngreso: '15/03/2018',
      telefono: '477 123 4567',
      tipoSangre: 'O+',
      licencia: 'E-1234567',
      vigenciaLicencia: '28/02/2027',
      estado: 'Activo',
      fotoUrl: 'https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=150&h=150&fit=crop'
    },
    {
      nombre: 'María Guadalupe Ramírez Torres',
      rfc: 'RATM920304MDF',
      curp: 'RATM920304MDFLRN07',
      nss: '98765432109',
      puesto: 'Operador Caja Seca',
      fechaIngreso: '22/08/2020',
      telefono: '55 9876 5432',
      tipoSangre: 'A+',
      licencia: 'B-9876543',
      vigenciaLicencia: '15/06/2026',
      estado: 'Activo',
      fotoUrl: 'https://images.unsplash.com/photo-1494790108377-be9c29b29330?w=150&h=150&fit=crop'
    },
    {
      nombre: 'Luis Fernando Gómez Sánchez',
      rfc: 'GOSL790522HDF',
      curp: 'GOSL790522HDFLRS09',
      nss: '45678912345',
      puesto: 'Operador Plataforma',
      fechaIngreso: '10/11/2015',
      telefono: '442 567 8901',
      tipoSangre: 'B-',
      licencia: 'E-4567890',
      vigenciaLicencia: '30/09/2028',
      estado: 'Bloqueado',
      fotoUrl: 'https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=150&h=150&fit=crop'
    },
    {
      nombre: 'Ana Laura Martínez Rodríguez',
      rfc: 'MARA960128MDF',
      curp: 'MARA960128MDFRNA02',
      nss: '32165498701',
      puesto: 'Operador Refrigerado',
      fechaIngreso: '05/05/2022',
      telefono: '81 234 5678',
      tipoSangre: 'AB+',
      licencia: 'E-3216549',
      vigenciaLicencia: '12/12/2025',
      estado: 'Activo',
      fotoUrl: 'https://ui-avatars.com/api/?name=Ana+Laura+Martínez+Rodríguez&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'Carlos Eduardo Hernández Díaz',
      rfc: 'HEDC880909HDF',
      curp: 'HEDC880909HDFRCS04',
      nss: '65432198765',
      puesto: 'Operador Doble Remolque',
      fechaIngreso: '18/09/2019',
      telefono: '33 876 5432',
      tipoSangre: 'O-',
      licencia: 'E-6543210',
      vigenciaLicencia: '05/03/2027',
      estado: 'Activo',
      fotoUrl: 'https://ui-avatars.com/api/?name=Carlos+Eduardo+Hernández+Díaz&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'Sofía Isabel Vargas Morales',
      rfc: 'VAMS950617MDF',
      curp: 'VAMS950617MDFLSF01',
      nss: '78912345678',
      puesto: 'Operador Tracto',
      fechaIngreso: '30/01/2021',
      telefono: '477 345 6789',
      tipoSangre: 'A-',
      licencia: 'B-7891234',
      vigenciaLicencia: '20/07/2026',
      estado: 'Inactivo',
      fotoUrl: 'https://ui-avatars.com/api/?name=Sofía+Isabel+Vargas+Morales&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'José Miguel Torres Ramírez',
      rfc: 'TORJ841203HDF',
      curp: 'TORJ841203HDFJS06',
      nss: '14725836901',
      puesto: 'Operador Plataforma',
      fechaIngreso: '07/04/2017',
      telefono: '55 654 3210',
      tipoSangre: 'B+',
      licencia: 'E-1472583',
      vigenciaLicencia: '14/11/2028',
      estado: 'Activo',
      fotoUrl: 'https://ui-avatars.com/api/?name=José+Miguel+Torres+Ramírez&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'Laura Patricia López García',
      rfc: 'LOGL900415MDF',
      curp: 'LOGL900415MDFLRP03',
      nss: '36985214703',
      puesto: 'Operador Caja Seca',
      fechaIngreso: '25/10/2023',
      telefono: '81 987 6543',
      tipoSangre: 'AB-',
      licencia: 'E-3698521',
      vigenciaLicencia: '08/04/2026',
      estado: 'Bloqueado',
      fotoUrl: 'https://ui-avatars.com/api/?name=Laura+Patricia+López+García&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'Pedro Antonio Ramírez Ortiz',
      rfc: 'RAOP870522HDF',
      curp: 'RAOP870522HDFPR08',
      nss: '25874196305',
      puesto: 'Operador Refrigerado',
      fechaIngreso: '12/06/2016',
      telefono: '33 456 7890',
      tipoSangre: 'O+',
      licencia: 'E-2587419',
      vigenciaLicencia: '19/08/2027',
      estado: 'Activo',
      fotoUrl: 'https://ui-avatars.com/api/?name=Pedro+Antonio+Ramírez+Ortiz&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'Elena Cristina Sánchez Mendoza',
      rfc: 'SAME930809MDF',
      curp: 'SAME930809MDFLEL05',
      nss: '74185296307',
      puesto: 'Operador Tracto',
      fechaIngreso: '03/02/2020',
      telefono: '442 123 9876',
      tipoSangre: 'A+',
      licencia: 'B-7418529',
      vigenciaLicencia: '25/01/2026',
      estado: 'Activo',
      fotoUrl: 'https://ui-avatars.com/api/?name=Elena+Cristina+Sánchez+Mendoza&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'Miguel Ángel Díaz Castro',
      rfc: 'DICM880310HDF',
      curp: 'DICM880310HDFMG02',
      nss: '96385274109',
      puesto: 'Operador Doble Remolque',
      fechaIngreso: '19/07/2018',
      telefono: '477 876 5432',
      tipoSangre: 'B-',
      licencia: 'E-9638527',
      vigenciaLicencia: '11/10/2028',
      estado: 'Activo',
      fotoUrl: 'https://ui-avatars.com/api/?name=Miguel+Ángel+Díaz+Castro&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'Verónica Guadalupe Ortiz Ramírez',
      rfc: 'ORVG950604MDF',
      curp: 'ORVG950604MDFVR07',
      nss: '85274196301',
      puesto: 'Operador Plataforma',
      fechaIngreso: '28/09/2021',
      telefono: '55 321 0987',
      tipoSangre: 'AB+',
      licencia: 'E-8527419',
      vigenciaLicencia: '03/05/2026',
      estado: 'Inactivo',
      fotoUrl: 'https://ui-avatars.com/api/?name=Verónica+Guadalupe+Ortiz+Ramírez&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'Francisco Javier Morales Vega',
      rfc: 'MOVF821115HDF',
      curp: 'MOVF821115HDFJF04',
      nss: '36914785203',
      puesto: 'Operador Caja Seca',
      fechaIngreso: '14/12/2014',
      telefono: '81 567 8901',
      tipoSangre: 'O-',
      licencia: 'E-3691478',
      vigenciaLicencia: '17/02/2027',
      estado: 'Bloqueado',
      fotoUrl: 'https://ui-avatars.com/api/?name=Francisco+Javier+Morales+Vega&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'Daniela Alejandra Castro Luna',
      rfc: 'CALD970228MDF',
      curp: 'CALD970228MDFDN01',
      nss: '14796325809',
      puesto: 'Operador Refrigerado',
      fechaIngreso: '09/03/2022',
      telefono: '33 234 5678',
      tipoSangre: 'A-',
      licencia: 'B-1479632',
      vigenciaLicencia: '29/09/2025',
      estado: 'Activo',
      fotoUrl: 'https://ui-avatars.com/api/?name=Daniela+Alejandra+Castro+Luna&size=128&background=random&rounded=true&bold=true'
    },
    {
      nombre: 'Roberto Carlos Vega Hernández',
      rfc: 'VEHR880907HDF',
      curp: 'VEHR880907HDFRB06',
      nss: '25836914705',
      puesto: 'Operador Tracto',
      fechaIngreso: '21/05/2019',
      telefono: '442 789 0123',
      tipoSangre: 'B+',
      licencia: 'E-2583691',
      vigenciaLicencia: '06/06/2028',
      estado: 'Activo',
      fotoUrl: 'https://ui-avatars.com/api/?name=Roberto+Carlos+Vega+Hernández&size=128&background=random&rounded=true&bold=true'
    }
  ];
  filteredOperators = [...this.operadores];

  newOperator() {
    this.router.navigate(['/dashboard/operator/new']);
  }
  searchOperator() {
    const term = this.searchTerm.toLowerCase().trim();

    this.filteredOperators = this.operadores.filter(op =>
      op.nombre.toLowerCase().includes(term) ||
      op.rfc.toLowerCase().includes(term)
    );
  }
  onImageError(event: any) {
    event.target.src = 'https://via.placeholder.com/50?text=?';
  }
}
