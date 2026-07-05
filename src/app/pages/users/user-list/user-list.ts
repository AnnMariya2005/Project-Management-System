import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { UserService, User } from '../../../services/user';

@Component({
  selector: 'app-user-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ],
  templateUrl: './user-list.html',
  styleUrl: './user-list.scss'
})
export class UserList implements OnInit {

  users: User[] = [];
  filteredUsers: User[] = [];
  searchText = '';

  private service = inject(UserService);
  private router = inject(Router);

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {

    this.service.getUsers().subscribe({

      next: (data) => {

        this.users = data;
        this.filteredUsers = data;

      },

      error: (err) => {

        console.error(err);

      }

    });

  }

  search() {

  const text = this.searchText.trim().toLowerCase();

  if (!text) {
    this.filteredUsers = [...this.users];
    return;
  }

  this.filteredUsers = this.users.filter(user =>
    user.userName.toLowerCase().startsWith(text)
  );

}

  editUser(id: number): void {

    console.log('Edit clicked', id);

    this.router.navigate(['/users/edit', id]);

  }

  deleteUser(id: number): void {

    console.log('Delete clicked', id);

    if (!confirm('Delete this user?')) {
      return;
    }

    this.service.deleteUser(id).subscribe({

      next: () => {

        alert('User deleted successfully');

        this.loadUsers();

      },

      error: (err) => {

        console.error(err);

        alert('Unable to delete user');

      }

    });

  }

}