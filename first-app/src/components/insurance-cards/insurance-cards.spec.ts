import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsuranceCards } from './insurance-cards';

describe('InsuranceCards', () => {
  let component: InsuranceCards;
  let fixture: ComponentFixture<InsuranceCards>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InsuranceCards]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InsuranceCards);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
