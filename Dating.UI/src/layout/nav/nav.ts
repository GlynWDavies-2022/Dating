import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav',
  imports: [FormsModule, RouterLink, RouterLinkActive],
  templateUrl: './nav.html',
  styleUrl: './nav.css',
})

export class Nav {

  protected accountService = inject(AccountService);

  protected credentials: any = {};

  login(): void {

    this.accountService.login(this.credentials).subscribe({
      next: result => {
        console.log(result);
        this.credentials = {};
      },
      error: error => console.log(error)
    });

  }

  logout(): void {
  }

}
