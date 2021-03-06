import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {


  form!: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void{
    this.form = this.fb.group({
      nome: ['',
      [Validators.required]],
      sobrenome: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  resetForm(): void{
    this.form.reset();
  }

}
