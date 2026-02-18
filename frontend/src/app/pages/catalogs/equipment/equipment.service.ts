import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom } from "rxjs";
import { environment } from "../../../../environments/environment";


@Injectable({
   providedIn: 'root'
})
export class EquipmentService {
  constructor(private http: HttpClient) {}

  getAllEquipments() {
    return firstValueFrom(
      this.http.get(`${environment.apiURL}/api/Equipment`)
    );
  }
}
