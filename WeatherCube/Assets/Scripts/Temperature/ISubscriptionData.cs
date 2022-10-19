using System;
public interface ISubscriptionData {
	void Subscribe(Action<object> obj);
}
