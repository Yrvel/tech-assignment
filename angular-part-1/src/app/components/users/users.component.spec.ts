import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AddressFormattedPipe } from 'src/app/pipes/address-formatted.pipe';
import { CompanyFormattedPipe } from 'src/app/pipes/company-formatted.pipe';
import { UserService } from 'src/app/services/user.service';
import { UserServiceStub } from 'src/app/services/users.service.mock';

import { UsersComponent } from './users.component';

describe('UsersComponent', () => {
  let component: UsersComponent;
  let fixture: ComponentFixture<UsersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [],
      declarations: [ UsersComponent, AddressFormattedPipe, CompanyFormattedPipe ],
      providers: [{ provide: UserService, useClass: UserServiceStub }],
    })
    .compileComponents();

    fixture = TestBed.createComponent(UsersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have "listUsers" populated ', () => {
    expect(component.listUsers?.length).toBeGreaterThan(0);
  });

  it('should call getUsers() of UserService on component Init', () => {
    spyOn(component.userService, 'getUsers').and.callThrough();
    component.ngOnInit();
    expect(component.userService.getUsers).toHaveBeenCalled();
  });
});
