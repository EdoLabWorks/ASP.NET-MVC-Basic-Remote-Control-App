# ASP.NET-Basic-Remote-Control-App
A bare-bones self-contained remote control app.

Control any executable process in your PC using your mobile device.

Just point the file path of the process you want to control to a particular virtual device from the app and you should be able to start or stop it from a web browser.

A simple sample is included under the Model folder to start off your process control. A procedure link is also included on how to access the app from any browser from other devices.

For now, just uncomment the following code section under Lib/ControlProcess.cs

~~
 case 1:
    x = 1;

    //There are many ways you to start, control and stop a process/dll driver methods, this is just a simple example 
    //Ideally it's better to use a class container to control any processes

    /*** process to start, uncomment to enable ***/
    //SimpleProcessControl.StartProcess(); //start a process

    Device[x].ON();
    break;
  case 2:
    x = 1;
    Device[x].OFF();

    //Follow similar pattern to other devices

    /*** process to stop, uncomment to enable ***/
    //SimpleProcessControl.KillProcess(); //stop a process
                   
    break;
  case 3:
  ~~

This project is based on C# ASP.NET MVC under Apache License. 
