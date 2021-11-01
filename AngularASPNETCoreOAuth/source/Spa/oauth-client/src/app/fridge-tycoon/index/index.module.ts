import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { FridgeTycoonRoutingModule } from '../fridge-tycoon.routing-module';
import { LayoutComponent } from './layout.component';
import { IndexComponent } from './index.component';
import { AddEditComponent } from './add-edit.component';
import { AddEditProductComponent } from './add-edit-product.component';
import { ProductListComponent } from './product-list.component';



@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        FridgeTycoonRoutingModule
    ],
    declarations: [
        LayoutComponent,
        IndexComponent,
        AddEditComponent,
        AddEditProductComponent,
        ProductListComponent
    ]
})
export class UsersModule { }