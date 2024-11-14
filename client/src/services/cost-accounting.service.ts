import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { CalculateCostAccountingModel } from '../models/calculate-cost-accounting.model';

@Injectable({
  providedIn: 'root'
})
export class CostAccountingService {
  private apiUrl = 'https://localhost:7295/api';

  constructor(private http: HttpClient) {}

  public calculateCostLifo(request: CalculateCostAccountingModel): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/cost-accounting/calculate-lifo`, request);
  }
}
