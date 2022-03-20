from django.shortcuts import render
from django.http import HttpResponse

# Create your views here.
def index(request):
    return HttpResponse('<em>My Second Project</em>')

def help(request):
    my_dict = {'mytag':'Help Page'}
    return render(request,'second_app/help.html',context=my_dict)