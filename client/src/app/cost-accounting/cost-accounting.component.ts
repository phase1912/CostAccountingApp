import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CostAccountingService } from '../../services/cost-accounting.service';
import { CalculateCostAccountingModel } from '../../models/calculate-cost-accounting.model';

@Component({
  selector: 'app-cost-accounting',
  templateUrl: './cost-accounting.component.html',
  styleUrls: ['./cost-accounting.component.scss']
})
export class CostAccountingComponent {
  form: FormGroup;
  result: any;

  constructor(private fb: FormBuilder, private service: CostAccountingService) {
    this.form = this.fb.group({
      companyName: ['', Validators.required],
      sharesToSell: ['', Validators.required],
      salePricePerShare: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.form.valid) {
      const request = new CalculateCostAccountingModel({
        companyName: this.form.controls['companyName']?.value,
        salePricePerShare: this.form.controls['salePricePerShare']?.value,
        sharesToSell: this.form.controls['sharesToSell']?.value
      });

      this.service.calculateCostLifo(request).subscribe(
        (response) => (this.result = response),
        (error) => {
          console.error(error)
          alert(error.error);
        }
      );
    }
    else {
      alert("Input all fields!");
    }
  }
}
