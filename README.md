# Flight-Simulator-Desktop-App

## Intro
Before beginning, I must introduce the program that we used as a a server to our program - Flight Gear. Flight Gear is a free,
open-source program that anyone can download onto their computer (works for Mac, Windows and Linux). This program simulates a plane in 
various modes, such as taking off, landing and flying. It has many features such as viewing the plane from different angles, changing the 
time of day and even change the location! 

Take a look at their website: https://www.flightgear.org/


## About
Our application serves as a client to the Flight Gear. Our program has two main functionalities: 1)controlling the plane using the rudder, 
aileron, throttle and elevator (for further understanding of how aviation works, check out https://en.wikipedia.org/wiki/Flight_control_surfaces). And 2)presenting the route that the plane took in a graphical form. 

## Downloading Flight Gear
In order for this program to actually do anything, you have to download the Flight Gear. Check out their website above and you can easily download it from there.

## How To Run Flight Gear
Before even starting our program, we have to start the Flight Gear. A few things you need to know in order for things to work properly:
- I uploaded a file called generic_small.xml. This needs to be downloaded and put into the following folder on your computer: 
C:\Program Files\FlightGear 2018.3.1\data\Protocol
- In order for the Flight Gear to have the necessary sockets, we need to go onto the Flight Gear program, into Settings, then scroll down to additional settings and paste the following two lines with a newline between them: `--telnet=socket,in,10,<ip>,<port>,tcp` and 
`--generic=socket,out,10,<ip>,<port>,tcp,generic_small`. (Of course the IP and port must have actual ips and ports and not just the words...) I also add the following line `fgfs --altitude=5000 --heading=0 --vc=110` so that the plane starts from the air, but this is 
optional.
- Click Fly! 

## How To Run Flight Simulator
Ok, now on to our program! 
Open the executable file called FlightSimulator. 
The first thing we have to do upon opening our program is connect to the Flight Gear. Doing that is simple - just click the Connect button! There is the option of
changing the ip and port using the Settings, if you would like a specific port and IP. 

Now, is the interesting part of the program. First, you should see on your left the route that the plane is taking, with the coordinates being the longitude and latitude of the location. 
Next, you can control the plane with either the joystick or by manually inputting instructions. Feel free and play with the joystick and 
sliders and fly the plane! 
### Instructions for AutoPilot
Rudder - `set controls/flight/rudder <val>`

Throttle - `set controls/engines/current-engine/throttle`

Elevator - `set controls/flight/elevator <val>`

Aileron - `set controls/flight/aileron <val>`

where val is between 1 and -1
