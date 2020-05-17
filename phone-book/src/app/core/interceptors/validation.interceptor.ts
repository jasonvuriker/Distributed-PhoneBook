import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpInterceptor,
  HttpHandler,
  HttpSentEvent,
  HttpHeaderResponse,
  HttpProgressEvent,
  HttpResponse,
  HttpUserEvent,
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable({ providedIn: 'root' })
export class ValidationInterceptor implements HttpInterceptor {
  /**
   *
   */
  constructor(private toastr: ToastrService) {}

  /**
   *
   */
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpSentEvent | HttpHeaderResponse | HttpProgressEvent | HttpResponse<any> | HttpUserEvent<any>> {
    return next.handle(req).pipe(
      catchError((err) => {
        const errors = this.formatErrors(err);
        errors.forEach((e) => this.toastr.warning(e.message));
        return throwError(errors);
      })
    );
  }

  /**
   *
   */
  private formatErrors(err) {
    if (err.error && err.error.errors) {
      return err.error.errors;
    }
    return ['Something went wrong'];
  }
}
