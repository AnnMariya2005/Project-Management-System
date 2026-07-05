import { Routes } from '@angular/router';

import { Login } from './pages/login/login';
import { Dashboard } from './pages/dashboard/dashboard';

import { DashboardLayout } from './layout/dashboard-layout/dashboard-layout';

import { UserList } from './pages/users/user-list/user-list';
import { UserForm } from './pages/users/user-form/user-form';

import { ProjectList } from './pages/projects/project-list/project-list';
import { ProjectForm } from './pages/projects/project-form/project-form';

import { TaskList } from './pages/tasks/task-list/task-list';
import { TaskForm } from './pages/tasks/task-form/task-form';
import { ChangePassword } from './pages/change-password/change-password';
export const routes: Routes = [

{
path:'',
redirectTo:'login',
pathMatch:'full'
},

{
path:'login',
component:Login
},

{
  path:'change-password',
  component:ChangePassword
},

{
path:'',
component:DashboardLayout,

children:[

{
path:'dashboard',
component:Dashboard
},

{
path:'users',
component:UserList
},

{
path:'users/add',
component:UserForm
},

{
path:'users/edit/:id',
component:UserForm
},

{
  path:'projects',
  component:ProjectList
},
{
  path:'projects/add',
  component:ProjectForm
},
{
  path:'projects/edit/:id',
  component:ProjectForm
},
{
  path: 'tasks',
  component: TaskList
},
{
  path: 'tasks/add',
  component: TaskForm
},
{
  path: 'tasks/edit/:id',
  component: TaskForm
}


]

}

];