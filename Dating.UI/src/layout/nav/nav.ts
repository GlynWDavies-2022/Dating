import { Component, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../core/services/account-service';

@Component({
  selector: 'app-nav',
  imports: [FormsModule],
  templateUrl: './nav.html',
  styleUrl: './nav.css',
})

export class Nav {

  private accountService = inject(AccountService);

  protected credentials: any = {};

  protected loggedIn = signal(false);

  login(): void {

    this.accountService.login(this.credentials).subscribe({
      next: result => {
        console.log(result);
        this.loggedIn.set(true);
        this.credentials = {};
      },
      error: error => console.log(error)
    });

  }

  logout(): void {
    this.loggedIn.set(false);
  }

}
