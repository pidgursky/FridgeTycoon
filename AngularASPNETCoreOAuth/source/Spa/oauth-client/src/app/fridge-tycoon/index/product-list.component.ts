import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { finalize, first } from 'rxjs/operators'
import { AuthService } from '../../core/authentication/auth.service';
import { FridgeTycoonService } from '../fridge-tycoon.service';
import { Router, ActivatedRoute } from '@angular/router';


@Component({
  selector: 'top-secret-index',
  templateUrl: './product-list.component.html',
  styleUrls: ['./index.component.scss']
})
export class ProductListComponent implements OnInit {  

  products=null;
  busy: boolean;
  fridgeId: string;

  constructor(
    private authService: AuthService, 
    private fridgeTycoonService: FridgeTycoonService, 
    private spinner: NgxSpinnerService,
    private route: ActivatedRoute
    ) {
  }

  ngOnInit() {   
    this.fridgeId=this.route.snapshot.params['fridgeId']; 
    this.busy = true;
    this.spinner.show();
    this.fridgeTycoonService.getProductsByFridge(this.authService.authorizationHeaderValue, this.fridgeId)
    .pipe(finalize(() => {
      this.spinner.hide();
      this.busy = false;
    })).subscribe(
    result => {         
      this.products = result;
   });
  }

  deleteProduct(id: string) {
    const product = this.products.find(x => x.id === id);
    if (!product) return;
    this.fridgeTycoonService.deleteProduct(this.authService.authorizationHeaderValue, id)
        .pipe(first())
        .subscribe(() => this.products = this.products.filter(x => x.id !== id));
}
}
