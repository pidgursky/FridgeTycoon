import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize, first } from 'rxjs/operators'
import { AuthService } from '../../core/authentication/auth.service';
import { FridgeTycoonService } from '../fridge-tycoon.service';

@Component({
  selector: 'top-secret-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  fridges=null;
  busy: boolean;

  constructor(private authService: AuthService, private fridgeTycoonService: FridgeTycoonService, private spinner: NgxSpinnerService) {
  }

  ngOnInit() {    
    this.busy = true;
    this.spinner.show();
    this.fridgeTycoonService.fetchFridgeTycoonData(this.authService.authorizationHeaderValue)
    .pipe(finalize(() => {
      this.spinner.hide();
      this.busy = false;
    })).subscribe(
    result => {         
      this.fridges = result;
   });
  }

  deleteFridge(id: string) {
    const fridge = this.fridges.find(x => x.id === id);
    if (!fridge) return;
    this.fridgeTycoonService.deleteFridge(this.authService.authorizationHeaderValue, id)
        .pipe(first())
        .subscribe(() => this.fridges = this.fridges.filter(x => x.id !== id));
}
}
