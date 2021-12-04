import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { CardDetail } from './card-detail.model';

@Injectable({
  providedIn: 'root'
})
export class CardDetailService {

  constructor (private http: HttpClient){};

  readonly apiUrl = `${environment.baseURL}/api/v1/CardDetailController`

  cardData: CardDetail = new CardDetail();

  cardDetail : CardDetail[];

  postCardDetail(){
    return this.http.post(this.apiUrl, this.cardData);
  }

  putCartDetail(){
    return this.http.put(`${this.apiUrl}/${this.cardData.paymentId}`, this.cardData);
  }

  deleteCardDetail(id: string){
    return this.http.delete(`${this.apiUrl}/${id}`);
  }

  refreshCardDetails(){
    this.http.get(this.apiUrl)
    .toPromise()
    .then(res => this.cardDetail = res as CardDetail[])
  }
}
