import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
      {
        path: '',
        loadChildren: () =>
          import('./phone-book/phone-book.module').then(
            (m) => m.PhoneBookModule
          ),
      },
    ],
  },
];

export const HomeRoutes = RouterModule.forChild(routes);
