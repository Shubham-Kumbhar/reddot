using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputhandelr : MonoBehaviour
{

    public Camera _cam;
    public LayerMask Buttons;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
              var startGame =  hit.transform.GetComponent<StartGame>();
              var joinGame =  hit.transform.GetComponent<JoinGame>();
              startGame?.Interact();
              joinGame?.Interact();
            }
        }
    }
}
