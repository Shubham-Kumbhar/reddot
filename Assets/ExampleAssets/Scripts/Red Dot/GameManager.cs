using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance;
    public Transform MenuTrasnform;
    public Image LoadingImage;
    public Camera mainCam;

    [Header("Well Done")]
    public GameObject WellDonePannel;
    public Button playAgainbutton;
    public Button continue1;
    [Header("ScoreBoard")]
    public GameObject ScoreBoardPannel;
    public Button Home;
    public Button DonateXp;
    [Header("Donate")]
    public GameObject DonatePannel;
    public Button continue2;
    [Header("Promote")]
    public GameObject PromotePannel;
    public Button continue3;
    [Header("Game Elements")]
    public GameObject RedDotPrefab;
    public Button EndGameButton;
    public GameObject miniMap;
    public int noOfDots = 1;
    public float randomSpawnRange = 20;

    public List<RedDot> redDots = new List<RedDot>();
    public GameObject blueZonePrefab;
    public GameObject yellowZonePrefab;
    void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(gameObject);
        LoadingImage.gameObject.SetActive(false);
        EndGameButton.onClick.AddListener(() => WellDonePannel.SetActive(true));

        playAgainbutton.onClick.AddListener(() => { WellDonePannel.SetActive(false); RestartGame(); });
        continue1.onClick.AddListener(() => { ScoreBoardPannel.SetActive(true); WellDonePannel.SetActive(false); });

        Home.onClick.AddListener(() => { ScoreBoardPannel.SetActive(false); RestartGame(); });
        DonateXp.onClick.AddListener(() => { DonatePannel.SetActive(true); ScoreBoardPannel.SetActive(false); });

        continue2.onClick.AddListener(() => { PromotePannel.SetActive(true); DonatePannel.SetActive(false); });

        continue3.onClick.AddListener(() => { PromotePannel.SetActive(false); RestartGame(); });
    }
    void RestartGame()
    {
        miniMap.SetActive(false);
        EndGameButton.gameObject.SetActive(false);
        Destroy(MenuTrasnform.gameObject);
        Debug.Log("restart");
    }
    private void Update()
    {
        DetectZones();
    }
    public void Loading(Action OnStart = null, Action OnComplete = null)
    {
        LoadingImage.gameObject.SetActive(true);
        LoadingImage.transform.DORotate(new Vector3(0, 0, 360f), 0.3f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(3, LoopType.Restart).OnStart(() => OnStart?.Invoke()).OnComplete(() => { LoadingImage.gameObject.SetActive(false); OnComplete?.Invoke(); });
    }
    public void InitalizeGame()
    {
        miniMap.SetActive(true);
        EndGameButton.gameObject.SetActive(true);

        miniMap.transform.DOScale(1, 0.3f).From(0);
        EndGameButton.transform.DOScale(1, 0.3f).From(0);
        SpawnRedDots();
    }
    public void SpawnRedDots()
    {
        for (int i = 0; i < noOfDots; i++)
        {
            var menuTrasnformPos = MenuTrasnform.position;
            var offset = new Vector3(Random.Range(-randomSpawnRange, randomSpawnRange), 0.5f, Random.Range(-randomSpawnRange, randomSpawnRange));
            var go = Instantiate(RedDotPrefab, menuTrasnformPos + offset, Quaternion.identity);
            go.transform.SetParent(MenuTrasnform);
        }
    }
    void DetectZones()
    {
        foreach (RedDot redDot in redDots)
        {
            List<RedDot> nearbyDots = new List<RedDot>();

            foreach (RedDot otherDot in redDots)
            {
                if (redDot == otherDot) continue;

                float dist = Vector3.Distance(redDot.transform.position, otherDot.transform.position);
                if (dist <= 3f)
                {
                    nearbyDots.Add(otherDot);
                }
            }

            redDot.ClearZone();

            int count = nearbyDots.Count + 1; // include self

            if (count == 1)
            {
                // No zone
            }
            else if (count <= 3)
            {
                redDot.SpawnZone(blueZonePrefab);
            }
            else
            {
                redDot.SpawnZone(yellowZonePrefab);
            }
        }
    }
}
