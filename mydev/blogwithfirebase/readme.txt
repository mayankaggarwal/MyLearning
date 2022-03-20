https://www.youtube.com/watch?v=Rpe8s4-qFFI
Doc
Create new app ng-blog
create new project on google firebase
copy app id and other urls in environment.ts
implement login and logout functionality in aith service
create posts components
create firebase database and collection and add entries of initial posts

Commands
ng new ng-blog --minimal
npm install firebase @angular/fire --save
ng generate module core --module=app
ng g m shared --module=app
ng g s core/auth
ng add @angular/material
ng g m material -m shared --flat
ng g c shared/navbar -m shared
ng g c posts/post-dashboard
ng g c posts/post-detail
ng g c posts/post-list
ng g s posts/post


https://ng-blog-84c45.firebaseapp.com/
https://console.firebase.google.com/project/ng-blog-84c45/overview