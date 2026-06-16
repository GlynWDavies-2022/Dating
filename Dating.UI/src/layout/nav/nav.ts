import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav',
  imports: [FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrl: './nav.css',
})

export class Nav {

  private router = inject(Router);

  protected accountService = inject(AccountService);

  protected credentials: any = {};

  login(): void {

    this.accountService.login(this.credentials).subscribe({
      next: result => {
        this.router.navigateByUrl('/members');
        this.credentials = {};
      },
      error: error => console.log(error)
    });

  }

  logout(): void {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
