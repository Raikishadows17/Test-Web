import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { firstValueFrom, Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs';


@Injectable({
  providedIn: 'root'
})


export class ServicesOrdenServices {

  constructor(private http: HttpClient) { }


  getServiceCreationOptions() {
    return this.http.get<any>(`${environment.apiURL}/api/Service/ServiceCreationOption`).pipe(
      tap(options => console.log('Service Creation Options:', options)),
      catchError(error => {
        console.error('Error fetching service creation options:', error);
        alert('Failed to load service creation options. Please try again later.');

        return of({
          clients: ['Walmart', 'Samsung Lázaro Cárdenas', 'Proveedor Automotriz'],
          tripTypes: ['Local', 'Foráneo'],
          statuses: ['Programado', 'En Tránsito', 'En Planta', 'Finalizado', 'Facturado'],
          operators: ['Juan Pérez (Disponible)', 'Luis López (Disponible)', 'Ana Gómez'],
          tractors: ['ECO-55 (Kenworth)', 'ECO-90 (Freightliner)'],
          trailers: ['Chasis 40ft - CH01', 'Plana - PL02'],
          containerTypes: ['20 DC', '40 DC', '40 HC', 'Refrigerado'],
          loadStatuses: ['Lleno', 'Vacío'],
          expenseConcepts: ['Diesel', 'Casetas (Tag)', 'Maniobra', 'Talachas', 'Estadia', 'Comidas'],
          paymentMethods: ['Efectivo', 'Transferencia', 'Tag', 'Vale'],
          placesOrigin: ['Puerto Lázaro Cárdenas', 'Patio Regulador', 'Bodega Cliente'],
          placesDestination: ['CDMX Pantaco', 'Planta Querétaro', 'Guadalajara'],
          dollies: ['Dolly 01', 'Dolly 02', 'Dolly 03'],
          currencies: ['USD', 'MXN', 'EUR'],
          imoClasses: [
            { value: '1', label: 'Clase 1 - Explosivos' },
            { value: '2.1', label: 'Clase 2.1 - Gases inflamables' },
            { value: '2.2', label: 'Clase 2.2 - Gases no inflamables, no tóxicos' },
            { value: '2.3', label: 'Clase 2.3 - Gases tóxicos' },
            { value: '3', label: 'Clase 3 - Líquidos inflamables' },
            { value: '4.1', label: 'Clase 4.1 - Sólidos inflamables' },
            { value: '4.2', label: 'Clase 4.2 - Sustancias que pueden inflamarse espontáneamente' },
            { value: '4.3', label: 'Clase 4.3 - Sustancias que al contacto con agua emiten gases inflamables' },
            { value: '5.1', label: 'Clase 5.1 - Sustancias oxidantes' },
            { value: '5.2', label: 'Clase 5.2 - Peróxidos orgánicos' },
            { value: '6.1', label: 'Clase 6.1 - Sustancias tóxicas' },
            { value: '6.2', label: 'Clase 6.2 - Material infeccioso' },
            { value: '7', label: 'Clase 7 - Material radiactivo' },
            { value: '8', label: 'Clase 8 - Sustancias corrosivas' },
            { value: '9', label: 'Clase 9 - Sustancias peligrosas varias' },
            { value: 'NA', label: 'No aplica / Mercancía general' }
          ]
        });
      }
      )
    );
  }
  getAllServices(){
    return firstValueFrom(
      this.http.get(`${environment.apiURL}/api/Service`)
    );
  }
  getServiceById(id:number){
    return firstValueFrom(
      this.http.get(`${environment.apiURL}/api/Service/${id}`)
    );
  }
  createService(formData: FormData) {
    return firstValueFrom(
      this.http.post(`${environment.apiURL}/api/Service`, formData)
    );
  }
  updateService(formData: FormData) {
    return firstValueFrom(
      this.http.put(`${environment.apiURL}/api/Service`, formData)
    );
  }
}
