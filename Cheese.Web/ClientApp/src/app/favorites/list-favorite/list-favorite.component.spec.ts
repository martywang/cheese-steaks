import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListFavoriteComponent } from './list-favorite.component';

describe('ListFavoriteComponent', () => {
  let component: ListFavoriteComponent;
  let fixture: ComponentFixture<ListFavoriteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListFavoriteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListFavoriteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
