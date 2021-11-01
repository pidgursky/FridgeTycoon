import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { FridgeTycoonService } from '../fridge-tycoon.service';
import { AuthService } from 'src/app/core/authentication/auth.service';


@Component({ templateUrl: 'add-edit.component.html' })
export class AddEditComponent implements OnInit {
    form!: FormGroup;
    id!: string;
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
        this.id = this.route.snapshot.params['id'];
        this.isAddMode = !this.id;
        this.form = this.formBuilder.group({
            name: ['', Validators.required],
            model: ['', Validators.required],
            volume: [0, Validators.required]                   
        });
        
        if (!this.isAddMode) {
            this.fridgeTycoonService.getFridge(this.authService.authorizationHeaderValue, this.id)
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
            this.createFridge();
        } else {
            this.updateFridge();
        }
    }
    private createFridge() {
        this.fridgeTycoonService.createFridge(this.authService.authorizationHeaderValue, this.form.value)
            .pipe(first())
            .subscribe(
                () => {
                    this.router.navigate(['../'], { relativeTo: this.route });
                },
                (response) => this.handleError(response))
            .add(() => this.loading = false);
    }

    private updateFridge() {
        this.form.value.id = this.route.snapshot.params['id'];
        this.fridgeTycoonService.updateFridge(this.authService.authorizationHeaderValue, this.form.value)
            .pipe(first())
            .subscribe(
                () => {
                    this.router.navigate(['../../'], { relativeTo: this.route });
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