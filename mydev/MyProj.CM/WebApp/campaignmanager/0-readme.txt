1. Added bootstrap4
2. Added JQuery
3. Added popper.js
https://medium.com/@oyewusioyekunle/how-to-add-bootstrap-to-your-angular-project-angular-8-6379fd6a0f46
4. Added fontawesome
5. 



npm install bootstrap --save
npm install jquery --save
npm install popper.js --save
npm install font-awesome --save
ng generate module em-shared-component
ng g c shared/components/em-header --module=shared/components/em-shared-component.module
ng g c shared/components/em-footer --module=shared/components/em-shared-component.module
ng generate module em-media
ng generate module connect-media

ng g c components/cmpwebapp/app-selector --module=components/cmpwebapp/connect-media.module
ng g s shared/services/em-session
ng g s shared/services/em-login
ng g s shared/services/em-user-data
ng g s shared/services/em-authorzation
npm install ngx-cookie-service --save

npm i @ng-bootstrap/ng-bootstrap --save