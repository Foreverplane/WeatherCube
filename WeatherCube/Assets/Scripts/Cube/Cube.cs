using UnityEngine;
using Zenject;
public class Cube : MonoBehaviour
{

	public class Factory : PlaceholderFactory<Cube>
	{
	}
}
