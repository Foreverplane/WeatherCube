using System;
using Zenject;
[Serializable]
public abstract class ConditionObjectPair<TObject, TCondition> : ScriptableObjectInstaller
{
	public TObject Object;
	public TCondition Condition;
}
