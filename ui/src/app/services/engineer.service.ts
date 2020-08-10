import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment} from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class EngineerService {

  constructor(private httpClient: HttpClient) { }

  public GetEngineers(): Observable<string[]> {
    return this.httpClient.get<string[]>(environment.BaseApiUrl + 'engineer');
  }
}
