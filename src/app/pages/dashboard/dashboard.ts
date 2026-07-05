import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { UserService } from '../../services/user';
import { ProjectService } from '../../services/project';
import { TaskService } from '../../services/task';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule
  ],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss'
})
export class Dashboard implements OnInit {

  totalUsers = 0;
  totalProjects = 0;
  totalTasks = 0;
  completedTasks = 0;
  today = new Date();
  constructor(
    private userService: UserService,
    private projectService: ProjectService,
    private taskService: TaskService
  ) {}

  ngOnInit(): void {

    this.userService.getUsers().subscribe(data => {
      this.totalUsers = data.length;
    });

    this.projectService.getProjects().subscribe(data => {
      this.totalProjects = data.length;
    });

    this.taskService.getTasks().subscribe(data => {
      this.totalTasks = data.length;
      this.completedTasks = data.filter(x => x.status === 'Completed').length;
    });

  }

}