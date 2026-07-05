import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface User {
  userId: number;
  userName: string;
  fullName: string;
  email: string;
  password?: string;
  role: string;
  isActive: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private http = inject(HttpClient);

  private apiUrl = 'https://localhost:7165/api/User';

  constructor() { }

  // Get all users
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl);
  }

  // Get user by id
  getUserById(id: number): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/${id}`);
  }

  // Add user
  addUser(user: any): Observable<any> {
    return this.http.post(this.apiUrl, user);
  }

  // Update user
  updateUser(user: any): Observable<any> {
    return this.http.put(this.apiUrl, user);
  }

  // Delete user
  deleteUser(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

}