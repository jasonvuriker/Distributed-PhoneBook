import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PhoneBook } from '../../models/phone-book.model';
import { NgOnDestroy } from '@shared/services/ng-on-destroy.service';
import { PhoneBookService } from '../../services/phone-book.service';
import { takeUntil } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-add-edit-phone-book',
  templateUrl: './add-edit-phone-book.component.html',
  styleUrls: ['./add-edit-phone-book.component.scss'],
})
export class AddEditPhoneBookComponent implements OnInit {
  /**
   *
   */
  @Input()
  data: PhoneBook = new PhoneBook();

  /**
   *
   */
  @Output()
  finish = new EventEmitter();

  /**
   *
   */
  form: FormGroup;

  /**
   *
   */
  constructor(private fb: FormBuilder, private $destroy: NgOnDestroy, private $data: PhoneBookService, private $toastr: ToastrService) {}

  /**
   *
   */
  ngOnInit() {
    this.initForm();
  }

  /**
   *
   */
  initForm() {
    this.form = this.fb.group({
      name: [this.data.name, Validators.required],
      phone: [this.data.phone, Validators.required],
    });
  }

  save() {
    if (this.form.valid) {
      this.data.name = this.form.value.name;
      this.data.phone = this.form.value.phone;
      this.$data
        .save(this.data)
        .pipe(takeUntil(this.$destroy))
        .subscribe((res) => {
          this.$toastr.info(this.data?.id ? 'Succussfully updated' : 'Successfully created');
          this.finish.emit(null);
        });
    }
  }
}
