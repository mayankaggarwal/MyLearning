https://ilearndh.udemy.com/course/python-and-django-full-stack-web-developer-bootcamp

Commands
conda create --name djangoenv django
conda activate djangoenv  # source activate djangoenv (for linux)
django-admin startproject first_project

--Adding App
python manage.py startapp first_app
add app in settings.py under INSTALLED_APPS

--Adding URL
Add function to views with name index
refer to view from first_app in urls.py in first_project
create urls.py in first_app and refer it in urls.py in first_project using include

--Adding template
Add template directory in TEMPLATES dictionary in settings.py
Add templates folder in first_project root folder
add index.html in templates folder
update index function in views.py in first_app and render index.html iwht dictionary

--models
python manage.py makemigrations app1
python manage.py migrate
python manage.py createsuperuser



Notes
On creating project following files are created
    __init__.py: this is a  blank python script that due to its special name let python know this directory can be treaded as package 
    settings.py: this is where we'll be storing all the projects settings
    urls.py: this is a python script that will store all the URL patterns for a project. Basically different pages of your application
    wsgi.py: this is a python script that acts as the web server gatway interface. It will help later on to deploy our web app to production.
    manage.py: it will be associated with many commands as we build our web app

Django project is a collection of applications and configurations that when combined together will make up the full web application
A Django application is created to perform a particular functionality for your entire web app
These Django apps can then be plugged into other Django projects so you can reuse them

On creating app following files are created
    admin.py: Register your models here which Django will then use them with Django's admin interface
    apps.py: Application specific configurations
    models.py: Applications data model
    tests.py: 
    views.py: This is where you have functions that handle requests and return responses
    Migrations folder


Django uses Model View template

urls

Templates
    These contain the static parts of HTML page, parts that are always same.
    To start create a templates directory and then a subdirectory for each specific app's templates
    Let Django know about templates by editing te DIR key inside of TEMPLATES dictionary in settings.py file
    create index.html inside templates directory
    Add template tags along with Django template variable
    templates are rendered using render() function in place of index() function in views.py file

models
    Inherited from django.db.models.Model
    class Topic(models.Model):
        top_name = models.CharFiled(max+length=264,unique=True)

    After setting up Model, 
    Add the migration
    migrate the database






