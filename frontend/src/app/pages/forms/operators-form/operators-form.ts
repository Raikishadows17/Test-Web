import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { OperatorsPersonalDataView } from '../../views/operators-personal-data-view/operators-personal-data-view';
import { OperatorsEmploymentDataView } from '../../views/operators-employment-data-view/operators-employment-data-view';
import { OperatorsCertificationsView } from '../../views/operators-certifications-view/operators-certifications-view';
import { OperatorService } from '../../catalogs/operators/operators.service';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-operators-form',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    OperatorsPersonalDataView,
    OperatorsEmploymentDataView,
    OperatorsCertificationsView,
  ],
  templateUrl: './operators-form.html',
  styleUrl: './operators-form.css',
})
export class OperatorsForm implements OnInit {
  activeTab = 1;
  isEdit = false;
  operatorId: number | null = null;

  formData = {
    // Datos personales
    names: '',
    middleName: '',
    lastName: '',
    rfc: '',
    curp: '',
    nss: '',
    ine: '',
    birthDate: '',
    gender: '',
    maritalStatus: '',
    bloodType: '',
    educationLevel: '',
    photoUrl: '',
    email: '',
    employeeNumber: '',

    // Datos complementarios
    phone: '',
    emergencyPhone: '',
    address: '',
    zipCode: '',

    // Datos laborales
    empCatId: null as number | null,
    entryDate: '',
    terminationDate: '',
    salary: '',
    company: '',
    guild: false,
    comments: '',

    // Licencias y certificaciones
    driveLicense: '',
    driveLicenseDateExp: '',
    certificatedForeignDriver: false,
    medicalCertificateFolio: '',
    medicalCertificateExp: '',

    photoPreview: '',
    licenseFileName: '',
    foreignCertFileName: '',

    // Archivos
    photoFile: null as File | null,
    licenseFile: null as File | null,
    foreignCertificateFile: null as File | null,
    driveLicenseUrl: '',
    foreignCertificateUrl: '',

    options: {
      sexes: ['Masculino', 'Femenino'],
      maritalStatuses: ['Soltero', 'Casado', 'Unión Libre'],
      employeeCategories: [] as { id: number; name: string }[],
      typeblood: ['A+', 'A-', 'B+', 'B-', 'AB+', 'AB-', 'O+', 'O-'],
      educationLevels: ['Primaria', 'Secundaria', 'Preparatoria', 'Licenciatura', 'Posgrado'],
    },
  };

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private operatorService: OperatorService
  ) {}

  async ngOnInit() {
    // TODO: cargar employeeCategories desde API
    // this.formData.options.employeeCategories = await this.categoryService.getAll();

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEdit = true;
      this.operatorId = +id;
      await this.loadOperator(this.operatorId);
    }
  }

  async loadOperator(id: number) {
    try {
      const res: any = await this.operatorService.getOperatorById(id);
      const op = res.Data;
      if (!op) return;

      this.formData.names = op.names ?? '';
      this.formData.middleName = op.middleName ?? '';
      this.formData.lastName = op.lastName ?? '';
      this.formData.rfc = op.rfc ?? '';
      this.formData.curp = op.curp ?? '';
      this.formData.nss = op.nss ?? '';
      this.formData.ine = op.ine ?? '';
      this.formData.birthDate = op.birthDate?.substring(0, 10) ?? '';
      this.formData.gender = op.gender ?? '';
      this.formData.maritalStatus = op.maritalStatus ?? '';
      this.formData.bloodType = op.bloodType ?? '';
      this.formData.educationLevel = op.educationLevel ?? '';
      this.formData.photoUrl = op.photoUrl ?? '';
      this.formData.email = op.email ?? '';
      this.formData.employeeNumber = op.employeeNumber ?? '';
      this.formData.driveLicenseUrl = op.driveLicenseUrl ?? '';
      this.formData.foreignCertificateUrl = op.foreignCertificateUrl ?? '';
      this.formData.photoUrl = op.photoUrl ?? '';
      if (op.photoUrl) {
        this.formData.photoPreview = `${environment.apiURL}${op.photoUrl}`;
      }

      this.formData.empCatId = 2 //Harcdeado por que el operador siempre es el id de en EmployeeCategory
      this.formData.entryDate = op.entryDate?.substring(0, 10) ?? '';
      this.formData.terminationDate = op.terminationDate?.substring(0, 10) ?? '';
      this.formData.salary = op.salary ?? '';
      this.formData.company = op.company ?? '';
      this.formData.guild = op.guild ?? false;
      this.formData.comments = op.comments ?? '';

      this.formData.driveLicense = op.driveLicense ?? '';
      this.formData.driveLicenseDateExp = op.driveLicenseDateExp?.substring(0, 10) ?? '';
      this.formData.certificatedForeignDriver = op.certificatedForeignDriver ?? false;
      this.formData.medicalCertificateFolio = op.medicalCertificateFolio ?? '';
      this.formData.medicalCertificateExp = op.medicalCertificateExp?.substring(0, 10) ?? '';
    } catch (err) {
      console.error('Error al cargar operador:', err);
    }
  }

  async onSubmit() {
    if (!this.formData.names || !this.formData.middleName || !this.formData.rfc) {
      alert('Completa los campos obligatorios (*)');
      return;
    }

    const fd = new FormData();

    // Datos personales
    fd.append('names', this.formData.names);
    fd.append('middleName', this.formData.middleName);
    fd.append('lastName', this.formData.lastName);
    fd.append('rfc', this.formData.rfc);
    fd.append('curp', this.formData.curp);
    fd.append('nss', this.formData.nss);
    fd.append('ine', this.formData.ine);
    fd.append('email', this.formData.email);
    fd.append('employeeNumber', this.formData.employeeNumber);
    if (this.formData.birthDate) fd.append('birthDate', this.formData.birthDate);
    fd.append('gender', this.formData.gender);
    fd.append('maritalStatus', this.formData.maritalStatus);
    fd.append('bloodType', this.formData.bloodType);
    fd.append('educationLevel', this.formData.educationLevel);

    // Datos laborales
    if (this.formData.empCatId) fd.append('empCatId', this.formData.empCatId.toString());
    if (this.formData.entryDate) fd.append('entryDate', this.formData.entryDate);
    if (this.formData.terminationDate) fd.append('terminationDate', this.formData.terminationDate);
    if (this.formData.salary) fd.append('salary', this.formData.salary.toString());
    fd.append('company', this.formData.company);
    fd.append('guild', this.formData.guild.toString());
    fd.append('comments', this.formData.comments);

    // Licencias
    fd.append('driveLicense', this.formData.driveLicense);
    if (this.formData.driveLicenseDateExp) fd.append('driveLicenseDateExp', this.formData.driveLicenseDateExp);
    fd.append('certificatedForeignDriver', this.formData.certificatedForeignDriver.toString());
    fd.append('medicalCertificateFolio', this.formData.medicalCertificateFolio);
    if (this.formData.medicalCertificateExp) fd.append('medicalCertificateExp', this.formData.medicalCertificateExp);

    // Archivos
    if (this.formData.photoFile) fd.append('photoFile', this.formData.photoFile);
    if (this.formData.licenseFile) fd.append('licenseFile', this.formData.licenseFile);
    if (this.formData.foreignCertificateFile) fd.append('foreignCertificateFile', this.formData.foreignCertificateFile);

    try {
      if (this.isEdit && this.operatorId) {
        fd.append('empId', this.operatorId.toString());
        await this.operatorService.updateOperator(fd);
        alert('Operador actualizado con éxito');
      } else {
        await this.operatorService.createOperator(fd);
        alert('Operador creado con éxito');
      }
      this.router.navigate(['/dashboard/operators']);
    } catch (err) {
      console.error('Error al guardar:', err);
      alert('Error al guardar operador');
    }
  }

  setActiveTab(tab: number) {
    this.activeTab = tab;
  }
}