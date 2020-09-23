import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IProject, IProjectListItem } from '../shared/models/project';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuotesService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProjects(): Observable<IProject[]> {
    return this.http.get<IProject[]>(this.baseUrl + 'projects/detailed');
  }

  getProjectList(search?: string): Observable<IProjectListItem[]> {
    let params = new HttpParams();

    if (search) {
      params = params.append('search', search);
    }

    return this.http.get<IProjectListItem[]>(this.baseUrl + 'projects', {observe: 'response', params})
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getProject(projId: number): Observable<IProject> {
    return this.http.get<IProject>(this.baseUrl + 'projects/' + String(projId));
  }

  isEmptyObject(obj): boolean {
    return (obj && (Object.keys(obj).length === 0));
  }
}
