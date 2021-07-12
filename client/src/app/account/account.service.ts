import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { allowedNodeEnvironmentFlags } from 'process';
import { environment } from './../../environments/environment';
import { BehaviorSubject, Observable, of, ReplaySubject } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { IUser } from './../shared/models/user';
import { IOffice } from './../shared/models/office';
import { createOfflineCompileUrlResolver } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  loadCurrentUser(token: string): Observable<void> {
    if (token === null) {
      this.currentUserSource.next(null);
      return of(null);
    }
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);

    return this.http.get(this.baseUrl + '/account', {headers}).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      })
    );
  }

  login(values: any): Observable<void> {
    console.log(values);
    return this.http.post(this.baseUrl + '/account/login', values).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      })
    );
  }

  register(values: any): Observable<void> {
    return this.http.post(this.baseUrl + '/account/register', values).pipe(
      map((user: IUser) => {
        if (user) {
          localStorage.setItem('token', user.token);
          this.currentUserSource.next(user);
        }
      })
    );
  }

  logout(): void {
    localStorage.removeItem('token');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/');
  }

  checkEmailExists(email: string): any {
    return this.http.get(this.baseUrl + '/account/emailexists?email=' + email);
  }

  getOfficesList(): Observable<IOffice[]> {
    return this.http.get<IOffice[]>(this.baseUrl + '/account/office/list', {observe: 'response'})
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }
}
