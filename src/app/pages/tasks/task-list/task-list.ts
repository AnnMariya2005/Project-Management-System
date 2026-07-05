import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';

import { TaskItem, TaskService } from '../../../services/task';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  templateUrl: './task-list.html',
  styleUrl: './task-list.scss'
})
export class TaskList implements OnInit {

  tasks: TaskItem[] = [];
  filteredTasks: TaskItem[] = [];
  searchText = '';

  constructor(
    private taskService: TaskService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks() {
    this.taskService.getTasks().subscribe({
      next: (data) => {
        this.tasks = data;
        this.filteredTasks = data;
      },
      error: (err) => console.error(err)
    });
  }

  searchTasks() {

  const text = this.searchText.trim().toLowerCase();

  if (!text) {
    this.filteredTasks = [...this.tasks];
    return;
  }

  this.filteredTasks = this.tasks.filter(task =>
    task.taskName.toLowerCase().startsWith(text)
  );

}

  editTask(id: number) {
    this.router.navigate(['/tasks/edit', id]);
  }

  deleteTask(id: number) {

    if (!confirm('Delete this task?')) {
      return;
    }

    this.taskService.deleteTask(id).subscribe({

      next: () => {
        alert('Task deleted successfully');
        this.loadTasks();
      },

      error: (err) => {
        console.error(err);
        alert('Unable to delete task');
      }

    });

  }

}