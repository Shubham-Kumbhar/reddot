using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public Image LoadingImage;
    void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(gameObject);
        LoadingImage.gameObject.SetActive(false);
    }

    public void Loading(Action OnStart = null, Action OnComplete = null)
    {
        LoadingImage.gameObject.SetActive(true);
        LoadingImage.transform.DORotate(new Vector3(0, 0, 360f), 0.3f,RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(3, LoopType.Restart).OnStart(() => OnStart?.Invoke()).OnComplete(() => { LoadingImage.gameObject.SetActive(false); OnComplete?.Invoke(); });
    }
}
