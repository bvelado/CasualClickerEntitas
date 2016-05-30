using UnityEngine;
using System.Collections;

public class GenerateGoldInput : MonoBehaviour {

	public void ButtonPressed()
    {
        Pools.pool.CreateEntity().AddGenerateGoldInput(1);
    }
}
