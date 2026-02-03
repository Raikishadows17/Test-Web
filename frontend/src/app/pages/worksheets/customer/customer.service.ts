import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../../../environments/environment";
import { firstValueFrom } from "rxjs";


@Injectable({
   providedIn: 'root'
})
export class CustomerService {
  constructor (private http: HttpClient){}

  getallCustomer(){
    return firstValueFrom(
      this.http.get(`${environment.apiURL}/api/Customer`)
    );
  }
}
