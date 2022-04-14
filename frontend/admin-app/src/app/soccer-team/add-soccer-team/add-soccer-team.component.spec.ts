import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSoccerTeamComponent } from './add-soccer-team.component';

describe('AddSoccerTeamComponent', () => {
  let component: AddSoccerTeamComponent;
  let fixture: ComponentFixture<AddSoccerTeamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSoccerTeamComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSoccerTeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
