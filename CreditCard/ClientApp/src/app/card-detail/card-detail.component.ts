import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CardDetailService } from './card-detail-form/shared/card-detail.service';
import { CardDetail } from './card-detail-form/shared/card-detail.model';

@Component({
    templateUrl: 'card-detail.component.html',
    styleUrls: ['card-detail.component.scss']
})
export class CardDetailComponent implements OnInit {


  constructor(public service: CardDetailService,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.service.refreshCardDetails() ;
  }

  populateForm(selectedRecord: CardDetail) {
    this.service.cardData = Object.assign({}, selectedRecord);
  }

  onDelete(id: string) {
    if (confirm('Are you sure to delete this record?')) {
      this.service.deleteCardDetail(id)
        .subscribe(
          res => {　
            res = this.service.cardData;
            this.service.refreshCardDetails();
            this.toastr.error("Deleted successfully", 'Card Detail Register');
          },
          err => { console.log(err) }
        )
    }
  }


}
