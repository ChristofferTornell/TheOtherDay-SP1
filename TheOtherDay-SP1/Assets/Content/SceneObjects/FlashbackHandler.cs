using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashbackHandler : MonoBehaviour
{

    void Start()
    {
        GlobalData.instance.flashBack = true;
    }

    void OnDestroy()
    {
        GlobalData.instance.flashBack = false;
    }
}
