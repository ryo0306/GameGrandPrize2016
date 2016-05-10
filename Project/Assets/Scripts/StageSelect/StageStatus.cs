using UnityEngine;
using System.Collections;

public class StageStatus : MonoBehaviour
{

    [SerializeField]
    int _selectGameNum = 1;

    static GameObject _instance = null;

    public void Start()
    {
        _selectGameNum = 1;
    }

    public int SelectGameNum
    {
        get { return _selectGameNum; }

        set { _selectGameNum = value; }
    }

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
