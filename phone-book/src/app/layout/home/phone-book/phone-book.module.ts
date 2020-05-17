import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PhoneBookComponent } from './components/phone-book/phone-book.component';
import { PhoneBookListComponent } from './components/phone-book-list/phone-book-list.component';
import { AddEditPhoneBookComponent } from './components/add-edit-phone-book/add-edit-phone-book.component';
import { SharedModule } from '@shared/shared.module';
import { PhoneBookRoutes } from './phone-book.routing';

@NgModule({
  imports: [CommonModule, SharedModule, PhoneBookRoutes],
  declarations: [PhoneBookComponent, PhoneBookListComponent, AddEditPhoneBookComponent],
})
export class PhoneBookModule {}
