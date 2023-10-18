import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalTecnicoComponent } from './modal-tecnico.component';

describe('ModalTecnicoComponent', () => {
  let component: ModalTecnicoComponent;
  let fixture: ComponentFixture<ModalTecnicoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalTecnicoComponent]
    });
    fixture = TestBed.createComponent(ModalTecnicoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
