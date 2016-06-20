using UnityEngine;
using UnityEngine.UI;

public class UIContainer : MonoBehaviour {

    static UIContainer _instance;
    public static UIContainer Instance
    {
        get
        {
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);
    }

    [Header("Player Gold Amount")]
    public ViewController PlayerGoldAmount;

    [Header("Buildings")]
    public ViewController MainGenerator;

    [Space(8)]
    public ViewController CornerShop;
    public ViewController GasStation;
    public ViewController Factory;
}
