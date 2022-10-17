using UnityEngine;
public class FTemperature:ITemperatureConverter {

	float ITemperatureConverter.Temperature(float kValue)=>Mathf.Round(((kValue-273.15f) * 9/5 + 32)*10)/10;
	string ITemperatureConverter.Unit => "F";
}