import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsContractsComponent } from './details-contracts.component';

describe('DetailsContractsComponent', () => {
  let component: DetailsContractsComponent;
  let fixture: ComponentFixture<DetailsContractsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetailsContractsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsContractsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
