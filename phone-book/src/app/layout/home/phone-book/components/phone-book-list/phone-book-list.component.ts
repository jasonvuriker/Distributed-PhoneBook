import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { PhoneBookService } from '../../services/phone-book.service';
import { Observable, of, timer, fromEvent, Subject } from 'rxjs';
import { GridResult } from '@core/models/grid-result.model';
import { PhoneBook } from '../../models/phone-book.model';
import { GridState } from '@core/configs/grid.settings';
import { ModalDirective } from 'angular-bootstrap-md';
import { DeleteConfirmationComponent } from '@shared/components/delete-confirmation/delete-confirmation.component';
import { NgOnDestroy } from '@shared/services/ng-on-destroy.service';
import { takeUntil, take, debounce, map, distinctUntilChanged, debounceTime, switchMap } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-phone-book-list',
  templateUrl: './phone-book-list.component.html',
  styleUrls: ['./phone-book-list.component.scss'],
})
export class PhoneBookListComponent implements OnInit {
  /**
   *
   */
  @ViewChild(ModalDirective)
  modal: ModalDirective;

  /**
   *
   */
  @ViewChild(DeleteConfirmationComponent)
  deleteConfirmation: DeleteConfirmationComponent;

  /**
   *
   */
  searchBox$ = new Subject<string>();

  /**
   *
   */
  data$: Observable<GridResult<PhoneBook>>;

  /**
   *
   */
  state: GridState = { skip: 0, take: 10 };

  /**
   *
   */
  selectedModel: PhoneBook;

  /**
   *
   */
  constructor(private $data: PhoneBookService, private $destroy: NgOnDestroy, private $toastr: ToastrService) {
    this.initSearchInput();
  }

  /**
   *
   */
  ngOnInit() {
    this.loadData();
  }

  /**
   *
   */
  loadData() {
    this.data$ = this.$data.collection(this.state);
  }

  /**
   *
   */
  open(e) {
    this.selectedModel = e || new PhoneBook();
    this.modal.show();
  }

  /**
   *
   */
  close() {
    this.selectedModel = null;
    this.modal.hide();
  }

  /**
   *
   */
  onFinish(e) {
    this.selectedModel = null;
    this.loadData();
    this.modal.hide();
  }

  /**
   *
   */
  deleteConfirm(e) {
    this.selectedModel = e;
    this.deleteConfirmation.modal.show();
  }

  /**
   *
   */
  delete() {
    if (this.selectedModel) {
      this.$data.delete(this.selectedModel.id).pipe(takeUntil(this.$destroy)).subscribe(this.deleteSuccess);
      this.deleteConfirmation.modal.hide();
    }
  }

  /**
   *
   */
  deleteSuccess(response): void {
    this.selectedModel = null;
    this.loadData();
    this.$toastr.info('Deleted');
  }

  /**
   *
   */
  initSearchInput() {
    this.searchBox$
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        takeUntil(this.$destroy),
        switchMap((value) => this.$data.collection(this.state, value))
      )
      .subscribe((d) => (this.data$ = of(d)));
  }
}
