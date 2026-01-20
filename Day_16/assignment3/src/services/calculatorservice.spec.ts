import { TestBed } from '@angular/core/testing';

import { Calculatorservice } from './calculatorservice';

describe('Calculatorservice', () => {
  let service: Calculatorservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Calculatorservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
