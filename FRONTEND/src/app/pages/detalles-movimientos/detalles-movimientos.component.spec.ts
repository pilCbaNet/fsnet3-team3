import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetallesMovimientosComponent } from './detalles-movimientos.component';

describe('DetallesMovimientosComponent', () => {
  let component: DetallesMovimientosComponent;
  let fixture: ComponentFixture<DetallesMovimientosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetallesMovimientosComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetallesMovimientosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
