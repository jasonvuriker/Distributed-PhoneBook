import { Routes, RouterModule } from '@angular/router';
import { PhoneBookComponent } from './components/phone-book/phone-book.component';
import { PhoneBookListComponent } from './components/phone-book-list/phone-book-list.component';
import { AddEditPhoneBookComponent } from './components/add-edit-phone-book/add-edit-phone-book.component';

const routes: Routes = [
  {
    path: '',
    component: PhoneBookComponent,
    children: [
      {
        path: '',
        component: PhoneBookListComponent,
      },
      {
        path: 'add',
        component: AddEditPhoneBookComponent,
      },
      {
        path: 'edit/:id',
        component: AddEditPhoneBookComponent,
      },
    ],
  },
];

export const PhoneBookRoutes = RouterModule.forChild(routes);
