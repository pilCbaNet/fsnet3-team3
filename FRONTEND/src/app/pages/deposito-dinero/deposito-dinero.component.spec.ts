import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DepositoDineroComponent } from './deposito-dinero.component';

describe('DepositoDineroComponent', () => {
  let component: DepositoDineroComponent;
  let fixture: ComponentFixture<DepositoDineroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DepositoDineroComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DepositoDineroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
