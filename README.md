# Keylogger
This software is meant to demonstrate how a keylogger could function. It captures the keystrokes of the user and uploads them to a remote server. This repository contains the keylogger. The server can be found at: https://github.com/VojtechMensik/KeyloggerServer
# How to use
In order to enable the program to run you will need to create a file **enable.txt** in the same directory as the .exe file. **To close the program remove the enable.txt file or move it to another directory**.
The captured keystrokes are stored  in **%appdata%\SystemData** directory. To setup the server, you can use xampp to host the server locally. Import the **database.sql** file to create a database for storing the captured keystokes. 
Once you have setup the server, write the full address in the **enable.txt** file, for example: http://localhost/upload.php.
# Disclamer
 The software provided herein is intended for educational purposes only. It is designed to serve as a learning tool for individuals interested in understanding the functioning and potential vulnerabilities of computer systems.
Users are solely responsible for their actions and should ensure compliance with all applicable laws, regulations, and ethical standards. The developer and publisher of this keylogger software shall not be held liable for any misuse, damages, or legal issues arising from its use.

**This program is based on and uses code from an online programming course https://www.itnetwork.cz/csharp/winforms/csharp-windows-forms-zdrojove-kody/keylogger**
