using System;
using UnityEngine;
[CreateAssetMenu(fileName = "RotationConfig", menuName = "ConditionConfigs/RotationConfig")]
public class RotationConfig : ConditionObjectPair<RotationReference,RotationCondition>, ICondition
{
	public bool Check(object obj) => Condition.Check((ColorReference)obj);
}

