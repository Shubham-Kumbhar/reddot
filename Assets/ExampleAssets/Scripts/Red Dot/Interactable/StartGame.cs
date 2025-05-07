using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class StartGame : Interactable
{
    // Start is called before the first frame update
    public GameObject PeremeterPopUp;
    public override void Interact()
    {
        base.Interact();
        transform.DOScale(-0.3f, 0.1f).SetEase(Ease.Linear).SetRelative().SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            transform.DOScale(0, 0.1f).OnComplete(() => gameObject.SetActive(false));
            PeremeterPopUp.SetActive(true);
            PeremeterPopUp.transform.DOScale(1, 0.2f).From(0);
        });


    }
}
