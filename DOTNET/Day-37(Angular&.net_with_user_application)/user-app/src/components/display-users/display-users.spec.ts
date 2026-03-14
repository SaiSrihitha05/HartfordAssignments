import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayUsers } from './display-users';

describe('DisplayUsers', () => {
  let component: DisplayUsers;
  let fixture: ComponentFixture<DisplayUsers>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DisplayUsers]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplayUsers);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
