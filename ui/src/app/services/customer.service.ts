import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerModel } from '../models/customer.model';
import { environment} from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }

  public GetCustomers(): Observable<CustomerModel[]> {
    return this.httpClient.get<CustomerModel[]>(environment.BaseApiUrl + 'customer');
  }

  public GetCustomer(customerId: number): Observable<CustomerModel> {
    return this.httpClient.get<CustomerModel>(environment.BaseApiUrl + `customer/${customerId}`);
  }

  public CreateCustomer(customer: CustomerModel): Promise<object> {
    return this.httpClient.post(environment.BaseApiUrl + 'customer', customer).toPromise();
  }

  public GetCustomerTypes(): Observable<string[]> {
    return this.httpClient.get<string[]>(environment.BaseApiUrl + 'customer/getcustomertypes');
  }
}
