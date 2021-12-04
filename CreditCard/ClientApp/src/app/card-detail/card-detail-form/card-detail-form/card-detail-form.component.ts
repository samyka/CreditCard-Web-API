import { Component, OnInit } from '@angular/core';
import { CardDetailService } from '../shared/card-detail.service';
import { ToastrService } from 'ngx-toastr';
import { CardDetail } from '../shared/card-detail.model';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-card-detail-form',
    templateUrl: 'card-detail-form.component.html'
})
export class CardDetailFormComponent implements OnInit{


  constructor(
    private service: CardDetailService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    if (this.service.cardData.paymentId == "")
      this.insertRecord(form);
    else
      this.updateRecord(form);
  }

  insertRecord(form: NgForm) {
    this.service.postCardDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshCardDetails();
        this.toastr.success('Submitted successfully', 'Card Detail Register')
      },
      err => { console.log(err); }
    );
  }

  updateRecord(form: NgForm) {
    this.service.putCartDetail().subscribe(
      res => {
        this.resetForm(form);
        this.service.refreshCardDetails();
        this.toastr.info('Updated successfully', 'Card Detail Register')
      },
      err => { console.log(err); }
    );
  }


  resetForm(form: NgForm) {
    form.form.reset();
    this.service.cardData = new CardDetail();
  }
}
