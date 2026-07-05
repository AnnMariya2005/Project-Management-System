import { Component, OnInit, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { ProjectService, Project } from '../../../services/project';

@Component({
  selector: 'app-project-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  templateUrl: './project-list.html',
  styleUrl: './project-list.scss'
})
export class ProjectList implements OnInit {

  projects: Project[] = [];
  filteredProjects: Project[] = [];

  searchText = '';

  openedMenu: number | null = null;

  constructor(
    private projectService: ProjectService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadProjects();
  }

  loadProjects() {

    this.projectService.getProjects().subscribe({

      next: data => {

        this.projects = data;
        this.filteredProjects = data;

      },

      error: err => console.log(err)

    });

  }

 search() {

  const text = this.searchText.trim().toLowerCase();

  if (!text) {
    this.filteredProjects = [...this.projects];
    return;
  }

  this.filteredProjects = this.projects.filter(project =>
    project.projectName.toLowerCase().startsWith(text)
  );

}

  toggleMenu(id: number, event: MouseEvent) {

    event.stopPropagation();

    this.openedMenu =
      this.openedMenu === id ? null : id;

  }

  @HostListener('document:click')
  closeMenu() {
    this.openedMenu = null;
  }

  editProject(id: number) {

    this.openedMenu = null;

    this.router.navigate(['/projects/edit', id]);

  }

  deleteProject(id: number) {

    this.openedMenu = null;

    if (!confirm('Delete this project?'))
      return;

    this.projectService.deleteProject(id).subscribe({

      next: () => {

        alert('Project deleted successfully');

        this.loadProjects();

      },

      error: err => {

        console.log(err);

        alert('Unable to delete project');

      }

    });

  }

}