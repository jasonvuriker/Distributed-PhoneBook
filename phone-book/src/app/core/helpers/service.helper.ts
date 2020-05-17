import { InjectorHelper } from './injector.helper';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

/**
 *
 */
export interface KeyValuePair {
  key: string;
  value: string;
}

export class ServiceHelper {
  /**
   * Static HTTP client
   */
  static get http(): HttpClient {
    return InjectorHelper.injector.get(HttpClient);
  }

  /**
   *
   */
  static get<TResponse>(url: string, keyMap?: KeyValuePair[]): Observable<TResponse> {
    let data: { [key: string]: string } = {};
    if (keyMap) {
      keyMap.filter((val) => val.value).forEach((val) => (data[val.key] = val.value));
    }
    return this.http.get<TResponse>(url, {
      params: data,
    });
  }

  static byId<TResponse>(url: string): Observable<TResponse> {
    return this.http.get<TResponse>(url);
  }

  /**
   * Post request
   */
  static post<TResponse>(url: string, model: any): Observable<TResponse> {
    return this.http.post<TResponse>(url, model);
  }

  /**
   * Put request
   */
  static put<TResponse>(url: string, model: any): Observable<TResponse> {
    return this.http.put<TResponse>(url, model);
  }

  /**
   *
   */
  static delete<TResponse>(url: string): Observable<TResponse> {
    return this.http.delete<TResponse>(url);
  }
}
