using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class MenuInstantiate : MonoBehaviour
{
    [SerializeField] ARRaycastManager arm;
    public GameObject CarPrefab;
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    GameObject Spawn;
    public GameObject menueGameobject;
    // Start is called before the first frame update
    void Start()
    {
        Spawn = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 0)
            return;
        if (menueGameobject != null) return;
        if (arm.Raycast(Input.GetTouch(0).position, hits))
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                spawnObject(hits[0].pose.position);
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved && Spawn != null)
            {
                Spawn.transform.position = hits[0].pose.position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Spawn = null;
            }
        }
    }
    private void spawnObject(Vector3 v)
    {
        Spawn = Instantiate(CarPrefab, v, Quaternion.identity);
    }
}
