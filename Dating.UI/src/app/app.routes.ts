import { Routes } from '@angular/router';
import { Home } from '../features/home/home';
import { MemberList } from '../features/members/member-list/member-list';
import { MemberDetails } from '../features/members/member-details/member-details';
import { Lists } from '../features/lists/lists';
import { Messages } from '../features/messages/messages';
import { authGuard } from '../core/guards/auth-guard';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'members', component: MemberList, canActivate: [authGuard] },
  { path: 'members/:id', component: MemberDetails },
  { path: 'lists', component: Lists },
  { path: 'messages', component: Messages },
  { path: '**', component: Home },
];
