import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovimientosBtcComponent } from './movimientos-btc.component';

describe('MovimientosBtcComponent', () => {
  let component: MovimientosBtcComponent;
  let fixture: ComponentFixture<MovimientosBtcComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MovimientosBtcComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MovimientosBtcComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
