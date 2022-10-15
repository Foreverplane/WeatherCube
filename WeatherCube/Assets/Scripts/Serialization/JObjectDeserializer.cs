using Newtonsoft.Json.Linq;
public class JObjectDeserializer<T> : JDeserializer<T> {
	public override T Deserialize(string json) {
		var j = JObject.Parse(json);
		var responseJson = j.ToString();
		var deserialize = base.Deserialize(responseJson);
		return deserialize;
	}
}
