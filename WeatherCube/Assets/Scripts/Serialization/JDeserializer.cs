using Newtonsoft.Json;
public abstract class JDeserializer<T> {
	public virtual T Deserialize(string json) {
		return JsonConvert.DeserializeObject<T>(json);
	}
}
