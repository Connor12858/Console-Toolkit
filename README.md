# Console-Toolkit
A program that simulates a Command Prompt, but contains something else than the basics.

# Installing

# Network

## IP Address

It will ping all the devices on the network and tell you which are offline or online.

Basic usage would be `Network IPAddress -a true`, displaying all the online devices. By switching the true to false it will show every device.
A very simple usage, but we can save the results to a file if we wish and choose the location of the file as so.

`Network IPAddress -a true -s true` will save the docume to the default folder, when looking at the help menu it says `C:\`. 
To change the location we need to add 1 more argument to the command, `-p`, which tells the program the <b>Path<b> to save.
`Network IPAddress -a false -s true -p C:\Users\canop\OneDrive\Desktop` would output a list of all the devices and their status to a file on my Desktop.

The program will generate it's own filename so just add a path to the folder, some paths would require admin access, like special folders.

## IP Info

# File

# Games

## PinGuesser