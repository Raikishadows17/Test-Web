import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-services-orden-evidence-view',
  imports: [CommonModule, FormsModule],
  templateUrl: './services-orden-evidence-view.html',
  styleUrl: './services-orden-evidence-view.css',
})
export class ServicesOrdenEvidenceView {
  @Input() formData: any;

  // Agregar gasto (para tab 3)
  addExpense() {
    if (this.formData.newExpense.concept && this.formData.newExpense.amount > 0) {
      this.formData.expenses.push({ ...this.formData.newExpense });

      // Limpia el formulario para el siguiente ingreso
      this.formData.newExpense = {
        date: new Date().toLocaleDateString('es-MX'),
        concept: '',
        amount: 0,
        paymentMethod: '',
        evidence: ''
      };

      console.log('Gasto agregado:', this.formData.expenses);
    } else {
      alert('Completa Concepto y Monto para agregar el gasto');
    }
  }
  get totalExpenses(): number {
    return this.formData.expenses.reduce((sum: number, exp: { amount: any; }) => sum + Number(exp.amount), 0);
  }

}
