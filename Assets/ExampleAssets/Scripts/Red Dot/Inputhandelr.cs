using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Inputhandelr : MonoBehaviour
{

    public Camera _cam;
    public LayerMask Buttons;
    public float clickDistance = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit1;
            Ray ray1 = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var startGame = hit.transform.GetComponent<StartGame>();
                var joinGame = hit.transform.GetComponent<JoinGame>();
                startGame?.Interact();
                joinGame?.Interact();
            }
            if (Physics.Raycast(ray1, out hit1, clickDistance))
            {
                Debug.Log(hit.transform);
                RedDot dot = hit1.transform.GetComponent<RedDot>();
                if (dot)
                {
                    GameManager.Instance.redDots.Remove(dot);
                    Destroy(dot.gameObject);
                }
            }
        }
    }
}
