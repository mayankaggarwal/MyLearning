from django.urls import path, re_path
from first_app import views

urlpatterns = [
    path('images',views.imagefile,name='images'),
    re_path(r'^$',views.index,name='index'),
]