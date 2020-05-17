import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DeleteConfirmationComponent } from './components/delete-confirmation/delete-confirmation.component';
@NgModule({
  imports: [CommonModule, MDBBootstrapModule],
  declarations: [DeleteConfirmationComponent],
  exports: [MDBBootstrapModule, FormsModule, ReactiveFormsModule, DeleteConfirmationComponent],
})
export class SharedModule {}
