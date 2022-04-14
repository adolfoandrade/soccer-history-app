import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoccerTeamComponent } from './soccer-team.component';

describe('SoccerTeamComponent', () => {
  let component: SoccerTeamComponent;
  let fixture: ComponentFixture<SoccerTeamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SoccerTeamComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SoccerTeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
