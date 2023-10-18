import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaTecnicosComponent } from './lista-tecnicos.component';

describe('ListaTecnicosComponent', () => {
  let component: ListaTecnicosComponent;
  let fixture: ComponentFixture<ListaTecnicosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListaTecnicosComponent]
    });
    fixture = TestBed.createComponent(ListaTecnicosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
