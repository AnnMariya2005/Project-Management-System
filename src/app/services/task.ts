import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface TaskItem {
  taskId?: number;
  taskName: string;
  projectId: number;
  assignedTo: string;
  priority: string;
  status: string;
  startDate: string;
  dueDate: string;
  estimatedHours: number;
  description: string;
}

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private http = inject(HttpClient);

  private apiUrl = 'https://localhost:7165/api/Task';

  getTasks(): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(this.apiUrl);
  }

  getTask(id: number): Observable<TaskItem> {
    return this.http.get<TaskItem>(`${this.apiUrl}/${id}`);
  }

  addTask(task: TaskItem): Observable<any> {
    return this.http.post(this.apiUrl, task);
  }

  updateTask(task: TaskItem): Observable<any> {
    return this.http.put(this.apiUrl, task);
  }

  deleteTask(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
  
}