import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Injector } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CoreModule } from '@core/core.module';
import { InjectorHelper } from '@core/helpers/injector.helper';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ValidationInterceptor } from '@core/interceptors/validation.interceptor';

@NgModule({
  declarations: [AppComponent],
  imports: [CoreModule, AppRoutingModule],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ValidationInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
  /**
   *
   * @param injector k
   */
  constructor(public injector: Injector) {
    InjectorHelper.injector = injector;
  }
}
