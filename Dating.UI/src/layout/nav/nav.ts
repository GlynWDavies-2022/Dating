import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastService } from '../../core/services/toast-service';

@Component({
  selector: 'app-nav',
  imports: [FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrl: './nav.css',
})

export class Nav {

  private router = inject(Router);

  protected accountService = inject(AccountService);

  protected toastService = inject(ToastService);

  protected credentials: any = {};

  login(): void {

    this.accountService.login(this.credentials).subscribe({
      next: result => {
        this.router.navigateByUrl('/members');
        this.toastService.success('Logged in successfully!');
        this.credentials = {};
      },
      error: error => {
        console.log(error);
        this.toastService.error(error.error);
      }
    });

  }

  logout(): void {
    this.accountService.logout();
    this.router.navigateByUrl('/');
    this.toastService.info('You have been logged out!');
  }

}
