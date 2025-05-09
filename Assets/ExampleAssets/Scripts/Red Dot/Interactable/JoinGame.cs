using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;


public class JoinGame : Interactable
{
    public GameObject StarGameCube;
    public GameObject pannel1;
    public Button YesButton;
    public Button AcceptButton;
    public GameObject pannel2;
    public TMP_InputField inputField;

    private void Start()
    {
        GameManager.Instance.MenuTrasnform = transform.parent;
        YesButton.onClick.AddListener(yesClick);
        AcceptButton.onClick.AddListener(AcceptClick);
    }
    public override void Interact()
    {
        base.Interact();
        transform.DOScale(-0.3f, 0.1f).SetEase(Ease.Linear).SetRelative().SetLoops(2, LoopType.Yoyo).OnComplete(() =>
       {
           transform.DOScale(0, 0.1f);
           StarGameCube.transform.DOScale(0, 0.1f);
           pannel1.SetActive(true);
           pannel1.transform.DOScale(1, 0.2f).From(0);
       });
    }
    void yesClick()
    {
        pannel1.transform.DOScale(0f, 0.2f).OnComplete(() =>
        {
            pannel1.SetActive(false);
            pannel2.SetActive(true);
            pannel2.transform.DOScale(1f, 0.4f).From(0);
        });

    }
    void AcceptClick()
    {
        pannel2.transform.DOScale(0, 0.4f).OnComplete(() =>
        {
            pannel2.SetActive(false);
            GameManager.Instance.InitalizeGame();
        });

    }
}
