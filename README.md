# STMDestroyer2016

### Overview

Our project implements a 2D computer game "Destroyer-2016". 
A player, who controls the destroyer by STM32F407 Discovery board, must destroy all enemy submarines.

### Description

This respository consists of two main parts: STM32F4 and Unity Project. <br>
STM32F4 is used as controller. The STM32 accelerometer detects movement and it can be interpreted by the computer. <br>
Programming language: C <br> <br>
The game was created in Unity. Games are programmed using scripts there. <br>
The destroyer of player can move along the width of the screen. This ship drops bombs to annihilate of submarines. Underwater crafts product torpedos and send them up. The player initially has 100% life but one hit reduces the "health points" of ship by 20%. Bonuses sometimes fall from the sky. Player may get more "health" or lose control of the ship by swapping sites. <br>
The current number of levels: 3.

### Tools 

•	Unity 5.3.4f1 Personal <br>
•	CoIDE-1.7.8 (CooCox) <br>
•	MS Visual Studio <br>
•	GIMP

### How to run 

Game path: *.exe file in ".../Release" directory 
Click on execute file, eventually change resolution or control settings and click on "Play!" button.

Control:

UP		Horizontal position of board/microUSB from leftside/miniUSB from rightside/user sees back of board<br>
DOWN	Horizontal position of board/microUSB from leftside/miniUSB from rightside/user sees front of board<br>
LEFT	Vertical position of board/miniUSB higher than microUSB<br>
RIGHT	Vertical position of board/microUSB and minijack higher than miniUSB port<br>

Depending on the inclination of the device, the destroyer will move to the left or right. 
Blue button will cause the drop of depth charges.

### How to compile

Connect your device to your computer with 2 wires (mini USB-USB A to power and microUSB-USB A to gamepad mode)

STM as controller:

1. Download "STM32 ST-Link Utility" (<a href='http://download.freedownloadmanager.org/Windows-PC/STM32-ST-Link-Utility/FREE-3.8.0.html'>link</a>) <br>
2. Click on file and install programm <br>
3. Run the programm after installation <br>
4. Go to "Target" section and choose "Program" <br>
5. You see new window. Look on "File path" and click "Browse" button to find  "stm32f429_project.hex" (end of path: "...\Release\STM Controller") <br>
6. Press "Start" button <br>
7. Now STM32 is ready for use as gamepad

### Future improvements

The explosion of the torpedo is under the water instead of on the ship. We are going to change it.

### Attributions

STM as HID USB device: <a href='http://stm32f4-discovery.net/2014/09/library-34-stm32f4-usb-hid-device/'>Author: Tilen Majerle</a>
<br>
Destroyer image: <a href='https://www.the-blueprints.com/blueprints/ships/destroyers-us/55629/view/uss_dd-946_edson_%5Bdestroyer%5D_(1970)/'>link</a>
<br>
Submarine image: <a href='http://thumb101.shutterstock.com/display_pic_with_logo/458122/275076917/stock-vector-contour-image-of-diesel-submarines-illustration-on-white-background-275076917.jpg'>link</a>
<br>
Bomb Exploding Sound: <a href='http://soundbible.com/1986-Bomb-Exploding.html'>link</a>
(license: https://creativecommons.org/licenses/by/3.0/pl/)

### License

License: MIT

### Credits

•	Jan Augustyniak <br>
•	Dominik Garczyk

<br>
The project was conducted during the Microprocessor Lab course held by the Institute of Control and Information Engineering, Poznan University of Technology. 
<br><br>
Supervisor: Michal Fularz 


