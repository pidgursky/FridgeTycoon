import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Shell } from '../shell/shell.service';
import { IndexComponent } from './index/index.component';
import { AuthGuard } from '../core/authentication/auth.guard';
import { AddEditComponent } from './index/add-edit.component';
import { ProductListComponent } from './index/product-list.component';
import { AddEditProductComponent } from './index/add-edit-product.component';


const routes: Routes = [
Shell.childRoutes([
    { path: 'fridgeTycoon', component: IndexComponent, canActivate: [AuthGuard] },
    { path: 'fridgeTycoon/add', component: AddEditComponent, canActivate: [AuthGuard] },
    { path: 'fridgeTycoon/edit/:id', component: AddEditComponent, canActivate: [AuthGuard] },
    { path: 'fridgeTycoon/product/:fridgeId', component: ProductListComponent, canActivate: [AuthGuard] },
    { path: 'fridgeTycoon/addp/:fridgeId', component: AddEditProductComponent, canActivate: [AuthGuard] }        
        
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class FridgeTycoonRoutingModule { }