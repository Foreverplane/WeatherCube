using UnityEngine;
[CreateAssetMenu(fileName = "RotationCondition", menuName = "Condition/RotationCondition")]
public class RotationCondition : ScriptableObject, ICondition<ColorReference> {

	public ColorReference ColorReference;
	public bool Check(ColorReference colorReference) {
		return colorReference==ColorReference;
	}
}

