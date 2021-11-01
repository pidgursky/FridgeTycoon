import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LayoutComponent } from './layout.component';
import { IndexComponent } from './index.component';
import { AddEditComponent } from './add-edit.component';
import { AddEditProductComponent } from './add-edit-product.component';
import { ProductListComponent } from './product-list.component';



const routes: Routes = [
    {
        path: '', component: LayoutComponent,
        children: [
            { path: '', component: IndexComponent },
            { path: 'add', component: AddEditComponent },
            { path: 'edit/:id', component: AddEditComponent },
            { path: '', component: ProductListComponent },
            { path: 'addp/:fridgeId', component: AddEditProductComponent },
            { path: 'product-list/edit/:id', component: AddEditProductComponent }            
           
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class UsersRoutingModule { }