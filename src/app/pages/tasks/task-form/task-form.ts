import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';

import { TaskService } from '../../../services/task';
import { ProjectService } from '../../../services/project';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule
  ],
  templateUrl: './task-form.html',
  styleUrl: './task-form.scss'
})
export class TaskForm implements OnInit {

  taskForm: FormGroup;

  editMode = false;

  taskId = 0;

  // Dropdown data
  projects: any[] = [];

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private taskService: TaskService,
    private projectService: ProjectService
  ) {

    this.taskForm = this.fb.group({

      taskName: ['', Validators.required],

      projectId: [null, Validators.required],

      assignedTo: ['', Validators.required],

      priority: ['High', Validators.required],

      status: ['In Progress', Validators.required],

      startDate: ['', Validators.required],

      dueDate: ['', Validators.required],

      estimatedHours: [0, Validators.required],

      description: ['']

    });

  }

  ngOnInit(): void {

    // Load projects for dropdown
    this.projectService.getProjectDropdown().subscribe({
      next: (data) => {
        this.projects = data;
      },
      error: (err) => console.error(err)
    });

    const id = this.route.snapshot.paramMap.get('id');

    if (id) {

      this.editMode = true;

      this.taskId = +id;

      this.taskService.getTask(this.taskId).subscribe({

        next: (task) => {

          this.taskForm.patchValue({

            taskName: task.taskName,
            projectId: task.projectId,
            assignedTo: task.assignedTo,
            priority: task.priority,
            status: task.status,
            startDate: task.startDate?.substring(0, 10),
            dueDate: task.dueDate?.substring(0, 10),
            estimatedHours: task.estimatedHours,
            description: task.description

          });

        },

        error: err => console.error(err)

      });

    }

  }

  save() {

    if (this.taskForm.invalid) {

      this.taskForm.markAllAsTouched();

      return;

    }

    const task = {

      taskId: this.taskId,

      ...this.taskForm.value

    };

    if (this.editMode) {

      this.taskService.updateTask(task).subscribe({

        next: () => {

          alert('Task Updated Successfully');

          this.router.navigate(['/tasks']);

        },

        error: err => {

          console.error(err);

          alert('Unable to update task');

        }

      });

    }

    else {

      this.taskService.addTask(task).subscribe({

        next: () => {

          alert('Task Saved Successfully');

          this.router.navigate(['/tasks']);

        },

        error: err => {

          console.error(err);

          alert('Unable to save task');

        }

      });

    }

  }

  cancel() {

    this.router.navigate(['/tasks']);

  }

}