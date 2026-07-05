import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { Component, OnInit, inject, ChangeDetectorRef } from '@angular/core';
import { UserService } from '../../../services/user';

@Component({
  selector: 'app-user-form',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  templateUrl: './user-form.html',
  styleUrl: './user-form.scss'
})
export class UserForm implements OnInit {

  private service = inject(UserService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);
  private cdr = inject(ChangeDetectorRef);

  isEdit = false;

  user: any = {
    userId: 0,
    userName: '',
    fullName: '',
    email: '',
    passwordHash: '',
    role: 'User',
    isActive: true
  };

  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('id');

    if (id) {

      this.isEdit = true;

      this.service.getUserById(+id).subscribe({

            next: (data) => {

              Object.assign(this.user, data);

              this.user.passwordHash = '';

              this.cdr.detectChanges();

            },

            error: (err) => {

              console.error(err);

            }

          });

    }

  }

  save() {

    if (this.isEdit) {

      this.service.updateUser(this.user).subscribe({

        next: () => {

          alert('User updated successfully');

          this.router.navigate(['/users']);

        },

        error: (err) => {

          console.error(err);

          alert('Unable to update user');

        }

      });

    }
    else {

      this.user.createdBy = 'Admin';

      this.service.addUser(this.user).subscribe({

        next: () => {

          alert('User added successfully');

          this.router.navigate(['/users']);

        },

        error: (err) => {

          console.error(err);

          alert('Unable to add user');

        }

      });

    }

  }

}