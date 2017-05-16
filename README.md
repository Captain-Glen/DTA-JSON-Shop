DTA-JSON-Shop
an online checkout pricing service

This service uses the MVC design pattern.  It has two controllers, cart and 
product.  Each have a Model and a List<Product> / List<Cart> as a DataSource.  
To preserve state a singleton class has been used for the DataSources.

The service loads the products from the JSON endpoint provided (which means it 
needs an internet connection).  It also allows full CRUD (GET, PUT, POST, DELETE) options on products, including 
creating new ones.

The cart controller allows full CRUD also.  POST adds to the cart.  GET, gets 
your cart total.  PUT allows you to edit your cart quantity.  DELETE allows 
you to remove a product completely from your cart.

I have built the serivce in Microsoft WebApi MVC.  I used a sample project 
from MSDN as the skelleton.

But don't worry I have ported it to MONO on Ubuntu and tested that it 
compiles and still works.

------------------------------------------------------------------------------
SETUP Instructions
------------------------------------------------------------------------------

To setup on Windows download the code from github via your browser and double 
click the .sln file.  Then press F5.

To setup on Ubuntu you need to install mono-complete apache2 and monodevelop (if 
you want an IDE to view the code) as well as git to get the code. 

DO NOT use the mono packages in the Ubuntu repos, as they are out of date and 
won't work!

install mono-complete
$sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
$echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list
$sudo apt-get update
$sudo apt-get install mono-complete

install Monodevelop
$sudo add-apt-repository ppa:alexlarsson/flatpak
$sudo apt update
$sudo apt install flatpak
$flatpak install --user --from https://download.mono-project.com/repo/monodevelop.flatpakref

run Monodevelop (if you want a GUI to view my code)
$flatpak run com.xamarin.MonoDevelop

install apache2
$sudo apt-get install apache2

install git
$sudo apt-get install git

Getting the code
$mkdir GLENsCode
$cd GLENsCode
$git init
$pull git://github.com/Captain-Glen/DTA-JSON-Shop.git

compiling the code (you must be in GLENsCode directory)
$xbuild

running the code
$cd JSONShop
MONO_IOMAP=all xsp4 --root . --port 8082

now go to localhost:8082 and check out my api :D

------------------------------------------------------------------------------
Design Choices
------------------------------------------------------------------------------
 
Why Microsoft .NET?
Because I only had 4 hours and haven't used Ruby on Rails yet.

If I were to use an open source soultion, I would use act.framework or Ruby 
on Rails.  I spent a bit of time watching tutorials on these before deciding 
to just use .NET.

Despite using Microsoft .NET, I still think my api is quite an achievement.
Particularly porting to Ubuntu MONO.  I feel that being able port Microsoft 
.NET applications (including the latest version of the .NET framwork, which my
api uses) to a LAMP stack could help DTA save the government billions of 
dollars.

Why no unit tests?
Again I only had 4 hours.  Normally I build a proof of concept first, then I 
rebuild a "clean" version of the application where I copy the code over and 
write unit tests.  If I was gonig to put the time to rebuild this, I would try 
learning act.framework.
