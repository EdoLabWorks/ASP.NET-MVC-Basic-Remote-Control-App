# ASP.NET-Basic-Remote-Control-App
A bare-bones self-contained remote control app with integrated backend control module. 

![](https://github.com/EdoLabWorks/ximgs/blob/master/AspBasicRemote.png)

Control any executable process in your PC using your mobile device.

Just point the file path of the process you want to control and you should be able to start or stop it from your web browser.

A sample and how-to link is included under the Model folder to start off your process control.

For now, just uncomment the following code section under Lib/ControlProcess.cs

```C#
         case 1:
          x = 1;
         
         //SimpleProcessControl.StartProcess();
          Device[x].ON();
          break;
```
```C#
         case 2:
          x = 1;
          Device[x].OFF();
         
         //SimpleProcessControl.KillProcess();  
          break;
```

This project is based on C# ASP.NET MVC under Apache License. 
