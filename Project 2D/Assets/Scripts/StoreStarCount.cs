using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreStarCount : MonoBehaviour
{
    public int totalStars = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
