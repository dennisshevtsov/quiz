import { TestBed } from '@angular/core/testing';

import { By } from '@angular/platform-browser';

import { RouterOutlet        } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';

import { AppComponent } from './app.component';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
                   imports: [RouterTestingModule],
                   declarations: [AppComponent],
                 })
                 .compileComponents();
  });

  it('should create component', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;

    expect(app).toBeTruthy();
  });

  it('should contain router-outlet', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const outlet  = fixture.debugElement.query(By.directive(RouterOutlet));

    expect(outlet).not.toBeNull();
    expect(outlet.componentInstance).not.toBeNull();
  });
});
