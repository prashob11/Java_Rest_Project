1. Import Project to the Eclipse (Import -> General -> Existing Projects into Workspace)
2. Add system JRE to the project (right mouse click in the project in Eclipse -> Properties -> follow the instructions from Add_JRE_System_Library.png)
3. Add the "javarest" module to Tomcat (double click on Tomcat server (1) on the Servers tab in Eclipse - then follow the instructions from Add_JRE_System_Library.png)
4. Build and run (Tomcat 8.5 Server on localhost). Check if http://127.0.0.1:8080/javarest/about works.