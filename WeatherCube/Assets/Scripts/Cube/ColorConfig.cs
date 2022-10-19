using UnityEngine;

[CreateAssetMenu(fileName = "ColorConfig", menuName = "ConditionConfigs/ColorConfig")]
public class ColorConfig : ConditionObjectPair<ColorReference,ColorCondition>, ICondition
{

	public bool Check(object param) => base.Condition.Check((int)(float)param);

}