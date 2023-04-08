import { TestBed } from '@angular/core/testing';

import { By                      } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatIconModule      } from '@angular/material/icon';
import { MatListModule      } from '@angular/material/list';
import { MatSidenavModule   } from '@angular/material/sidenav';
import { MatToolbarModule   } from '@angular/material/toolbar';

import { RouterOutlet        } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';

import { AppComponent } from './app.component';

describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
                   imports: [
                    BrowserAnimationsModule,
                    MatIconModule,
                    MatListModule,
                    MatSidenavModule,
                    MatToolbarModule,
                    RouterTestingModule,
                  ],
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
