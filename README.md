# ASP.NET-Basic-Remote-Control-App
A bare-bones self-contained remote control app with integrated backend I/O control module. 

![](https://github.com/EdoLabWorks/ximgs/blob/master/AspBasicRemote.png)

Control any executable process in your PC using your mobile device.

Just point the file path of the process you want to control to a particular virtual device from the app and you should be able to start or stop it from a web browser.

A simple sample is included under the Model folder to start off your process control. A procedure link is also included on how to access the app from any browser from other devices.

For now, just uncomment the following code section under Lib/ControlProcess.cs

--
         case 1:
          x = 1;
          
         uncomment to start a process
         //SimpleProcessControl.StartProcess();
          Device[x].ON();
          break;
--
         case 2:
          x = 1;
          Device[x].OFF();
          
         uncomment to stop the process
         //SimpleProcessControl.KillProcess();  
          break;


This project is based on C# ASP.NET MVC under Apache License. 
