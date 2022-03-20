import { UserDashboardModule } from './user-dashboard/user-dashboard.module';
import { ArticleEditComponent } from './article-edit/article-edit.component';
import { ArticleCreateComponent } from './article-create/article-create.component';
import { ContactusComponent } from './contactus/contactus.component';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { RoutegaurdService } from './routegaurd.service';
import { NotfoundComponent } from './notfound/notfound.component';
import { ArticleComponent } from './article/article.component';
import { BlogComponent } from './blog/blog.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { IntroComponent } from './intro/intro.component';
import { GalleryComponent } from './gallery/gallery.component';
import { ServicesComponent } from './services/services.component';
import { TestimonialsComponent } from './testimonials/testimonials.component';
import { ClientsComponent } from './clients/clients.component';
import { PricingComponent } from './pricing/pricing.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full'},
  { path: 'home', component: HomeComponent},
  { path: 'login', component: LoginComponent},
  { path: 'signup', component: SignupComponent},
  { path: 'contactus', component: ContactusComponent},
  { path: 'about' , component: IntroComponent },
  { path: 'gallery', component: GalleryComponent},
  { path: 'services', component: ServicesComponent},
  { path: 'testimonials', component: TestimonialsComponent},
  { path: 'clients', component: ClientsComponent},
  { path: 'pricing', component: PricingComponent},
  { path: 'dashboard', loadChildren: () => UserDashboardModule},
  { path: 'blog', component: BlogComponent, canActivate: [RoutegaurdService] },
  { path: 'article/:id', component: ArticleComponent},
  { path: 'article-edit/:id', component: ArticleEditComponent, canActivate: [RoutegaurdService]},
  { path: 'article-create', component: ArticleCreateComponent, canActivate: [RoutegaurdService]},
  { path: '404', component: NotfoundComponent},
  { path: '**', redirectTo: '/404'},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, {
    enableTracing: false
  })
],
  exports: [RouterModule]
})
export class AppRoutingModule { }
