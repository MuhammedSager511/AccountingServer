import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { LayoutsComponent } from './components/layouts/layouts.component';
import { HomeComponent } from './components/home/home.component';
import { inject } from '@angular/core';
import { AuthService } from './services/auth.service';
import { UsersComponent } from './components/users/users.component';
import { ConfrimEmailComponent } from './components/confrim-email/confrim-email.component';
import { CompaniesComponent } from './components/companies/companies.component';
import { CashRegistersComponent } from './components/cash-registers/cash-registers.component';
import { CashRegisterDetailComponent } from './components/cash-register-detail/cash-register-detail.component';
import { BanksComponent } from './components/banks/banks.component';
import { BankDetailsComponent } from './components/bank-details/bank-details.component';


export const routes: Routes = [
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "confrim-email/:email",
        component : ConfrimEmailComponent

    },
    {
        path: "",
        component: LayoutsComponent,
        canActivateChild: [()=> inject(AuthService).isAuthenticated()],
        children: [
            {
                path: "",
                component: HomeComponent
            },
            {
                path: "users",
                component: UsersComponent
            },
            {
                path: "companies",
                component: CompaniesComponent
            },
            {
                path: "cash-registers",
                children: [
                    {
                        path: "",
                        component: CashRegistersComponent
                    },
                    {
                        path: "details/:id",
                        component: CashRegisterDetailComponent
                    }
                ]
                
            },
            {
                path: "banks",
                children: [
                    {
                        path: "",
                        component: BanksComponent
                    },
                    {
                        path: "details/:id",
                        component: BankDetailsComponent
                    }
                ]
            },
        ]
    }
];
