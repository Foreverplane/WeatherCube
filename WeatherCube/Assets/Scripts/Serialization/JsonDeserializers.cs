using System;
using UnityEngine;
public class JsonDeserializers {

	public T Deserialize<T>(string jsonLike) {
		var deserializers = new JDeserializer<T>[] {
			new JArrayDeserializer<T>(),
			new JObjectDeserializer<T>(),
		};
		T result = default;
		foreach (var jDeserializer in deserializers) {
			try {
				result = result ?? jDeserializer.Deserialize(jsonLike);
			}
			catch (Exception e) {
				// Debug.LogWarning($"Cant deserialize {typeof(T).Name} with {jDeserializer.GetType().Name}");
			}
		}
		return result;
	}
}
