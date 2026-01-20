import { TestBed } from '@angular/core/testing';

import { Arrayservice } from './arrayservice';

describe('Arrayservice', () => {
  let service: Arrayservice;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Arrayservice);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
