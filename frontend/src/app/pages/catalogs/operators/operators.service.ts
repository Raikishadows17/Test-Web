import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../../../environments/environment";
import { firstValueFrom } from "rxjs";


@Injectable({
   providedIn: 'root'
})
export class OperatorService {
  constructor (private http: HttpClient){}

  getallOperator(){
    return firstValueFrom(
      this.http.get(`${environment.apiURL}/api/Employee/Operator`)
    );
  }


  getOperatorById(id: number) {
    return firstValueFrom(
      this.http.get(`${environment.apiURL}/api/Employee/Operator/${id}`)
    );
  }

  createOperator(formData: FormData) {
    return firstValueFrom(
      this.http.post(`${environment.apiURL}/api/Employee/Operator`, formData)
    );
  }

  updateOperator(formData: FormData) {
    return firstValueFrom(
      this.http.put(`${environment.apiURL}/api/Employee/Operator`, formData)
    );
  }


}
