using UnityEngine;
public class CTemperature:ITemperatureConverter {
	float ITemperatureConverter.Temperature(float kValue)=>Mathf.Round((kValue - 273.15f)*10)/10;
	string ITemperatureConverter.Unit => "C";
}
