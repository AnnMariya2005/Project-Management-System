import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Project {
  projectId?: number;
  projectCode: string;
  projectName: string;
  description: string;
  manager: string;
  startDate: string;
  endDate: string;
  status: string;
  budget: number;
  notes: string;
  isActive: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class ProjectService {

  private http = inject(HttpClient);

  private apiUrl = 'https://localhost:7165/api/Project';

  // Get all projects
  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.apiUrl);
  }

  // Get project by id
  getProject(id: number): Observable<Project> {
    return this.http.get<Project>(`${this.apiUrl}/${id}`);
  }

  // Add project
  addProject(project: Project): Observable<any> {
    return this.http.post(this.apiUrl, project);
  }

  // Update project
  updateProject(project: Project): Observable<any> {
    return this.http.put(this.apiUrl, project);
  }

  // Delete project
  deleteProject(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  getProjectDropdown() {
  return this.http.get<any[]>(
    `${this.apiUrl}/dropdown`
  );
}

}