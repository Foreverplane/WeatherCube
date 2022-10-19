# WeatherCube

## Start game
The game starts from scene "SampleScene".  
![image](https://user-images.githubusercontent.com/28690609/196653034-b9c89f44-7981-4c4f-9410-f65582faa17b.png)

## Temperature
After the game starts you can change / test the temperature by changing GameTemperatureData.Property in GameMainInstaller in inspector (SceneContext gameobject) (1).
Also you can repeat the request by pressing the button "Request temperature" (2).    
![image](https://user-images.githubusercontent.com/28690609/196662609-4b25b56b-ff54-4319-b993-de60e4faa5ec.png)  

## Rotation and colors
To test rotation speed, you can change colors by changing CurrentColorData.Property in CubeInstaller in inspector (SceneContext-Cubes-GameObjectContext(Clone) gameobject)  
![image](https://user-images.githubusercontent.com/28690609/196664934-cb3ddf97-83ca-4b4b-b0f8-2b265dea69fb.png)  

## Explanatory GIF  
![WeatherCube_GIF_3](https://user-images.githubusercontent.com/28690609/196676029-3806f96d-439a-4a42-ad2a-1249a70461e5.gif)

## PS

I noticed that in the description of the task, in my opinion, there was not enough information about what would happen to the cube in the temperature range from 85 to 95. I assumed - let it be yellow.  
I calculated the rotation speed for yellow by interpolating between 100 and 360. The result is 230.  


<details>
  <summary>Test task</summary>

## Task

Build a small unity application that places a cube in the center of the screen. The application periodically checks the temperature in Austin, TX (zip code 78734) and changes the color and rotation of the cube depending on the current temperature in Austin.

- The application can run in the editor for this deliverable  
- Use async/await where/if needed  
- Use Unitask where/if needed  
- Choose any free weather api you want  
- Turn the cube blue if the temperature is below 60 degrees F  
- Turn the cube green if the temperature is below 85 degrees F  
- Turn the cube red if the temperature is above 95 degrees F  
- The cube should continuously rotate around it’s Y axis no matter the temperature  
- The cube should rotate 5 degrees / second if blue  
- The cube should rotate 100 degrees / second if green  
- The cube should rotate 360 degrees /second if red  

We’re not particular on the Unity version that you use and you do not need to build a player.  
We’ll just test your code in the editor.  
We’re interested first and foremost in correctness.  
HINT: Obviously, when we run the application the temperature will be fixed at that time, so how can you enable us to “test” that your requirements work given any temperature.  
We’re not looking for you to include a complicated unit test framework.  
Instead, show us how you tested your application to be confident any temperature will work even though we can only see the cube reacting to the current temperature.

 
</details>  
