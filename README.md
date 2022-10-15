# WeatherCube

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
