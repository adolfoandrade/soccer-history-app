import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateSoccerTeamComponent } from './update-soccer-team.component';

describe('UpdateSoccerTeamComponent', () => {
  let component: UpdateSoccerTeamComponent;
  let fixture: ComponentFixture<UpdateSoccerTeamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UpdateSoccerTeamComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateSoccerTeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
