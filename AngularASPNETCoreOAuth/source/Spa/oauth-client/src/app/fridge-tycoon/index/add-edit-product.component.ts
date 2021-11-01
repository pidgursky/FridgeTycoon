import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { FridgeTycoonService } from '../fridge-tycoon.service';
import { AuthService } from 'src/app/core/authentication/auth.service';


@Component({ templateUrl: 'add-edit-product.component.html' })
export class AddEditProductComponent implements OnInit {
    form!: FormGroup;
    id!: string;
    fridgeId!: string;
    isAddMode: boolean;
    loading = false;
    submitted = false;

    constructor(
        private authService: AuthService,
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private fridgeTycoonService: FridgeTycoonService,
    ) {}

    ngOnInit() {
        this.fridgeId=this.route.snapshot.params['fridgeId'];
        this.isAddMode = true;
        this.form = this.formBuilder.group({
            name: ['', Validators.required],
            refrigeratory: [0, Validators.required]               
        });
        
        if (!this.isAddMode) {
            this.fridgeTycoonService.getProduct(this.authService.authorizationHeaderValue, this.id)
                .pipe(first())
                .subscribe(x => this.form.patchValue(x));
        }
    }

    
    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.loading = true;
        if (this.isAddMode) {
            this.createProduct();
        } else {
            this.updateProduct();
        }
    }
    private createProduct() {
        this.form.value.fridgeId=this.fridgeId;
        this.fridgeTycoonService.createProduct(this.authService.authorizationHeaderValue, this.form.value)
            .pipe(first())
            .subscribe(
                () => {
                    this.router.navigate(['../'], { relativeTo: this.route });
                },
                (response) => this.handleError(response))
            .add(() => this.loading = false);
    }
    private updateProduct() {
        this.form.value.id = this.route.snapshot.params['id'];
        this.fridgeTycoonService.updateProduct(this.authService.authorizationHeaderValue, this.form.value)
            .pipe(first())
            .subscribe(
                () => {
                    this.router.navigate(['../'], { relativeTo: this.route });
                },
                (response) => this.handleError(response))
            .add(() => this.loading = false);
    }
    
    private handleError(response) {
        var errors = response.error.errors;
        Object.keys(errors).forEach(element => {
            this.form.controls[element.toLowerCase()].setErrors({ 'message': errors[element][0] })
        });
    }

}