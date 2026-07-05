import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import {
  Router,
  RouterModule,
  ActivatedRoute
} from '@angular/router';

import {
  ProjectService,
  Project
} from '../../../services/project';

@Component({
  selector: 'app-project-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule
  ],
  templateUrl: './project-form.html',
  styleUrl: './project-form.scss'
})
export class ProjectForm implements OnInit {

  projectForm!: FormGroup;

  isEdit = false;

  projectId = 0;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private projectService: ProjectService
  ) {

    this.projectForm = this.fb.group({

      projectName: ['', Validators.required],

      projectCode: ['', Validators.required],

      manager: ['', Validators.required],

      client: [''],

      startDate: ['', Validators.required],

      endDate: ['', Validators.required],

      status: ['', Validators.required],

      description: ['']

    });

  }

  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('id');

    if (id) {

      this.isEdit = true;

      this.projectId = +id;

      this.projectService.getProject(this.projectId).subscribe({

        next: (project) => {

          this.projectForm.patchValue({

            projectName: project.projectName,
            projectCode: project.projectCode,
            manager: project.manager,
            startDate: project.startDate
              ? project.startDate.substring(0, 10)
              : '',
            endDate:
                project.endDate &&
                project.endDate.substring(0, 10) !== '0001-01-01'
                  ? project.endDate.substring(0, 10)
                  : '',
            status: project.status,
            description: project.description

          });

        },

        error: (err) => {

          console.error(err);

          alert('Unable to load project');

        }

      });

    }

  }

  save(): void {

    console.log('Save clicked');

    if (this.projectForm.invalid) {

      this.projectForm.markAllAsTouched();

      alert('Please fill all required fields.');

      console.log(this.projectForm.value);

      return;

    }

    const project: Project = {

      projectId: this.projectId,

      projectCode: this.projectForm.value.projectCode,

      projectName: this.projectForm.value.projectName,

      description: this.projectForm.value.description,

      manager: this.projectForm.value.manager,

      startDate: this.projectForm.value.startDate,

      endDate: this.projectForm.value.endDate,

      status: this.projectForm.value.status,

      budget: 0,

      notes: '',

      isActive: true

    };

    if (this.isEdit) {

      this.projectService.updateProject(project).subscribe({

        next: () => {

          alert('Project updated successfully');

          this.router.navigate(['/projects']);

        },

        error: (err) => {

          console.error(err);

          alert('Unable to update project');

        }

      });

    }
    else {

      this.projectService.addProject(project).subscribe({

        next: () => {

          alert('Project added successfully');

          this.router.navigate(['/projects']);

        },

        error: (err) => {

          console.error(err);

          alert('Unable to save project');

        }

      });

    }

  }

  cancel(): void {

    this.router.navigate(['/projects']);

  }

}