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
  getServiceOptions(){
    return firstValueFrom(
      this.http.get(`${environment.apiURL}/api/Service/ServiceCreationOption`)
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
