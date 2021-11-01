import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule }   from '../shared/shared.module';
import { IndexComponent } from './index/index.component';

import { FridgeTycoonService }  from './fridge-tycoon.service';

import { FridgeTycoonRoutingModule } from './fridge-tycoon.routing-module';

@NgModule({
  declarations: [IndexComponent],
  providers: [ FridgeTycoonService],
  imports: [
    CommonModule,  
    FridgeTycoonRoutingModule,
    SharedModule
  ]
})
export class FridgeTycoonModule { }
