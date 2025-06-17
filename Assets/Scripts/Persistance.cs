using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistance : MonoBehaviour
{
    private static persistance instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
}
