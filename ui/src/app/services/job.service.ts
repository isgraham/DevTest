import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { JobModel } from '../models/job.model';
import { environment} from '../../environments/environment'

@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private httpClient: HttpClient) { }

  public GetJobs(): Observable<JobModel[]> {
    return this.httpClient.get<JobModel[]>(environment.BaseApiUrl + 'job');
  }

  public GetJob(jobId: number): Observable<JobModel> {
    return this.httpClient.get<JobModel>(environment.BaseApiUrl + `job/${jobId}`);
  }

  public CreateJob(job: JobModel): Promise<object> {
    return this.httpClient.post(environment.BaseApiUrl + 'job', job).toPromise();
  }
}
