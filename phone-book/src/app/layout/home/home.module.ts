import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { SharedModule } from '@shared/shared.module';
import { HomeRoutes } from './home.routing';

@NgModule({
  imports: [CommonModule, SharedModule, HomeRoutes],
  declarations: [HomeComponent],
})
export class HomeModule {}
