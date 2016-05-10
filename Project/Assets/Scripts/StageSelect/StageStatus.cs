using UnityEngine;
using System.Collections;

public class StageStatus : MonoBehaviour
{

    [SerializeField]
    int _selectGameNum;

    static GameObject _instance = null;

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
