import { Component, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'angular-bootstrap-md';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'delete-confirmation',
  templateUrl: './delete-confirmation.component.html',
  styleUrls: ['./delete-confirmation.component.scss'],
})
export class DeleteConfirmationComponent implements OnInit {
  @ViewChild(ModalDirective) modal: ModalDirective;
  @Output() delete = new EventEmitter();
  constructor() {}

  ngOnInit() {}

  confirm() {
    this.delete.emit(null);
  }
}
