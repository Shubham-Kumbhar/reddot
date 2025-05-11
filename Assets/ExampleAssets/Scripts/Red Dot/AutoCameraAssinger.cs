using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCameraAssinger : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = GameManager.Instance.mainCam;
    }
}
