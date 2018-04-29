import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  features: any[] = [];
  makes: any[] = [];
  models: any[] = [];
  vehicle = {
    make: null
  }

  constructor(
    private vehicleService: VehicleService
  ) { }

  getFeatures(): void {
    this.vehicleService.getFeatures()
      .subscribe(f => this.features = f);
  }

  getMakes(): void {
    this.vehicleService.getMakes()
      .subscribe(makes => this.makes = makes);
  }

  onMakeChange(): void {
    let selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    this.models = selectedMake ? selectedMake.models : [];
  }


  ngOnInit() {
    this.getMakes();
    this.getFeatures();
  }

}
