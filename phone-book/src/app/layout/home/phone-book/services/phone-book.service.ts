import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { GridState } from '@core/configs/grid.settings';
import { Observable } from 'rxjs';
import { GridResult } from '@core/models/grid-result.model';
import { PhoneBook } from '../models/phone-book.model';
import { UrlHelper } from '@core/helpers/url.helper';
import { UrlSettings } from '@core/configs/url.setting';

@Injectable({
  providedIn: 'root',
})
export class PhoneBookService {
  /**
   *
   */
  private readonly baseUrl = UrlHelper.settings.apiUrl;

  /**
   *
   */
  constructor(private http: HttpClient) {}

  /**
   *
   */
  collection(state: GridState, searchKey: string = ''): Observable<GridResult<PhoneBook>> {
    return this.http.get<GridResult<PhoneBook>>(this.baseUrl + UrlSettings.PHONEBOOK_API + 'PhoneBook/Collection?searchText=' + searchKey);
  }

  /**
   *
   */
  add(model: PhoneBook): Observable<any> {
    return this.http.post<any>(this.baseUrl + UrlSettings.PHONEBOOK_API + 'PhoneBook/Create', model, { observe: 'response' });
  }

  /**
   *
   */
  update(model: PhoneBook): Observable<any> {
    return this.http.put<any>(this.baseUrl + UrlSettings.PHONEBOOK_API + 'PhoneBook/Update', model, { observe: 'response' });
  }

  /**
   *
   */
  delete(id: number): Observable<any> {
    return this.http.delete<any>(this.baseUrl + UrlSettings.PHONEBOOK_API + 'PhoneBook/Delete?Id=' + id);
  }

  /**
   *
   */
  save(model: PhoneBook): Observable<any> {
    return model.id ? this.update(model) : this.add(model);
  }
}
