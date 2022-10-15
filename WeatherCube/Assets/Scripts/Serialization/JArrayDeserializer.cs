using Newtonsoft.Json.Linq;
public class JArrayDeserializer<T> : JDeserializer<T> {
	public override T Deserialize(string json) {
		var j = JArray.Parse(json);
		var responseJson = j[0].ToString();
		var deserialize = base.Deserialize(responseJson);
		return deserialize;
	}
}
