import { Component, OnInit } from '@angular/core';
import { Car } from '../models/car';
import { CarService } from '../services/car.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {

  constructor(private carService: CarService) { }

  ngOnInit(): void {
    this.getCars();
  }

  cars: Car[] = [];
  selectedCar?: Car;

  getCars(): void {
    this.carService.getCars().subscribe(m => this.cars = m);
  }

  onSelect(car: Car): void {
    this.selectedCar = car;
  }
}
