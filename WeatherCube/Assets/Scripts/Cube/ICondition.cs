public interface ICondition<in TParameter> {
	bool Check(TParameter param);
}

public interface ICondition {
	bool Check(object obj);
}
