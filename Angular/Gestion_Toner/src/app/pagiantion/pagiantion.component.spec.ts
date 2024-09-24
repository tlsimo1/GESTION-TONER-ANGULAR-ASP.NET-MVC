import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PagiantionComponent } from './pagiantion.component';

describe('PagiantionComponent', () => {
  let component: PagiantionComponent;
  let fixture: ComponentFixture<PagiantionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PagiantionComponent]
    });
    fixture = TestBed.createComponent(PagiantionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
