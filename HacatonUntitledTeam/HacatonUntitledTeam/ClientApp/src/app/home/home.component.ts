import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  searchFormGroup!: FormGroup;  // переменная для формирование поиска данных
  goodTitle = 'Гречка';

  // констркутор
  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.searchFormGroup = this.fb.group({
      product: [this.goodTitle, [Validators.required]],
    });
  }

  // событие при котормо будет отправка параметра
  submit(): void {
    console.log(this.searchFormGroup.value);
  }

  // геттер для доступа к форме
  get product(): any { return this.searchFormGroup.controls.product; }
}
