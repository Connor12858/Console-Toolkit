<div align="center"> <h1> Console-Toolkit </h1> </div>
A program that simulates a Command Prompt, but contains something else than the basics.

![Windows Command Prompt GIF](https://upload.wikimedia.org/wikipedia/commons/2/23/Command_Prompt_Animation.gif)

<br><br>
# Installing

<br><br>
# Network

## IP Address

It will ping all the devices on the network and tell you which are offline or online.

Basic usage would be `Network IPAddress -a true`, displaying all the online devices. By switching the true to false it will show every device.
A very simple usage, but we can save the results to a file if we wish and choose the location of the file as so.

`Network IPAddress -a true -s true` will save the docume to the default folder, when looking at the help menu it says `C:\`. 
To change the location we need to add 1 more argument to the command, `-p`, which tells the program the **Path** to save.
`Network IPAddress -a false -s true -p C:\Users\canop\OneDrive\Desktop` would output a list of all the devices and their status to a file on my Desktop.

The program will generate it's own filename so just add a path to the folder, some paths would require admin access, like special folders.

## IP Info

Can retrieve information such as the city the provider of the network is based, and the long and lat for the city. This also includes the timezone and possibly host names 
(if the external application allows me). Using a 3rd party nuget package called [IPInfo](https://ipinfo.io/) and a secret key from my account.

Very basic to use, `Network IPInfo -ip 99.123.456.789` will give the information on the address provided. It does not allow local ip's such as 127.0.0.1 or 
10.0.0.1 to be used as it would return nothing and waste a call for the month. Using a public ip address, which can be found at [What is my IP](https://whatismyipaddress.com/)
and reading the **IPv4** for a your own public ip.

<br><br>
# File


## Purge

Deletes all the files in a folder, or all files with a certain extension.

To remove everything use `File Purge -p "Path\to\folder"`, default is to remove everything. If you do not want to remove everything we can add 1 more argument,
`-d false`. This will by default remove all documents that end with a .txt extension, to change the extension to delete add `-t png`. This 
would delete everything that ends in .png, **It automatically adds the '.'. DO NOT ADD IT.**

`File Purge -p "C:\Users\canop\OneDrive\Photos" -d false -t jpg` would remove all my .jpg photos but not my .png photos. Highly recommended to always put a " around the path
or at least ' so the program will concat it if it contains spaces.

<br><br>
# Games

## PinGuesser
 
To play enter `Games PinGuesser`. It is a homemade digital version of the [Mastermind Board Game](https://en.wikipedia.org/wiki/Mastermind_(board_game))