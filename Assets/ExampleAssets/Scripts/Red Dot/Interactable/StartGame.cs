using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class StartGame : Interactable
{
    // Start is called before the first frame update
    public GameObject PeremeterPopUp;
    public Button onPannel2Button;
    public GameObject onPannel1PopUP;
    public GameObject onPannel2PopUP;
    public Button MapPop;
    public GameObject MapPRefab;
    private void Start()
    {
        onPannel2Button.onClick.AddListener(OpenPanel2);
        MapPop.onClick.AddListener(SpawnMap);
    }
    public override void Interact()
    {
        base.Interact();
        transform.DOScale(-0.3f, 0.1f).SetEase(Ease.Linear).SetRelative().SetLoops(2, LoopType.Yoyo).OnComplete(() =>
        {
            transform.DOScale(0, 0.1f);
            PeremeterPopUp.SetActive(true);
            PeremeterPopUp.transform.DOScale(1, 0.2f).From(0);
        });
    }
    void OpenPanel2()
    {
        GameManager.Instance.Loading(
            OnStart: () =>
            {
                onPannel1PopUP.SetActive(false);
            },
            OnComplete: () =>
            {
                onPannel2PopUP.SetActive(true);
                onPannel2PopUP.transform.DOScale(1f, 0.2f);

            });
    }
    void SpawnMap()
    {
        onPannel1PopUP.SetActive(false);
        Instantiate(MapPRefab, null);
    }
}
