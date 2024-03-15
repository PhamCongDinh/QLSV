import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HometeacherComponent } from './hometeacher.component';

describe('HometeacherComponent', () => {
  let component: HometeacherComponent;
  let fixture: ComponentFixture<HometeacherComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HometeacherComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HometeacherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
