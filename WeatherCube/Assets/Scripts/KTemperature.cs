public class KTemperature:ITemperatureConverter {
	float ITemperatureConverter.Temperature(float kValue) => kValue;
	string ITemperatureConverter.Unit => "K";
}
