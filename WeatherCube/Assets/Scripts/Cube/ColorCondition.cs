using DynamicExpresso;
using UnityEngine;
[CreateAssetMenu(fileName = "ColorCondition", menuName = "Condition/ColorCondition")]
public class ColorCondition:  ScriptableObject, ICondition<int> {
	private const string X = "x";

	public StringReference Condition;
	
	public bool Check(int param) {
		var target = new Interpreter().SetVariable(X, param);
		return target.Eval<bool>(Condition.Value);
	}
}