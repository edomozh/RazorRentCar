import { Injectable } from '@angular/core';
import { Car } from '../models/car';
import { CARS } from '../mocks/mock-cars';
import { Observable, of } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class CarService {

  constructor() { }

  getCars(): Observable<Car[]> {
    const cars = of(CARS);
    return cars;
  }
}
