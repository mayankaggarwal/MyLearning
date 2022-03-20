Reference:
https://www.youtube.com/watch?v=LYmJOdCuXrs

Steps:
1. Create new angular web site
2. download single page html template
3. copy index.html of template in app-root compoenent
4. copy css from template in style.css
5. copy images from template in assets
6. update path of images
7. create component of each section from main content in app-root component
8. Add font awesome i.e. npm package and in angular.json


Add Notfound component
update two routes '/404' and '**'

Adding pagination in blog

Adding Login, signup
1. adding components login, signup and contactus
2. add service routeguard and implement CanActivate
3. include route guard in routing
4. add css in login, signup and contactus css
5. add html in all three components
6. Add reative forms module in app module
7. Add formGroup and formControl all three components
8. Add in-memory-data service and implement missing functionality
9. Add authentication service and implement functionality
10. Implement login and signup using login component , signup component and authenication service
11. Add logout button

Adding libraries
1. Add js from template in assets
2. Add npm packages
3. Add paths in angular.json
4. Update navigation component for jquery

Adding Blog editor
1. Add two components for article create and article edit
2. Add routing for these two components
3. Update in memory web api to fetch posts from in memory webapi instead of configuration
4. update configuration service
5. add ngx-markdown
6. Update article edit html
7. Edit article create html with one side edit section and one side markdown preview section
8. Add addPost in config service
9. Update post component to show markdown
10. Call addPost of config service from create article component

Static to Dynamic menu populated from DB
1. Add navmenu component
2. delete navigation from navigation component
3. create database menu in in memory database
4. create method getSettings in config service
5. update ts of navigation and navmenu component

User dashboard Module
Create feature module UserDashboard

Commands:
ng new mywebsite
ng g c intro
ng g c gallery
ng g c services
ng g c clients
ng g c footer
ng g c header
ng g c testimonials
ng g c pricing
ng g c navigation
npm install --save font-awesome
#if routing is not already added
ng generate module app-routing --flat --module=app

ng g c Notfound
ng g s pager
ng g c pagination

Adding Login, signup
ng g c login
ng g c signup
ng g c contactus
ng g s routeguard
npm install angular-in-memory-web-api --save
ng g s in-memory-data
ng g s authentication

Adding libraries
npm i jquery --save
npm i wowjs --save


Adding Blog editor
ng g c article-edit
ng g c article-create
npm install ngx-markdown --save

Static to Dynamic menu populated from DB
ng g c navmenu

User dashboard Module
ng generate module UserDashboard --routing

Notes:
