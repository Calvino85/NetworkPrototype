using MLAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Shooter : NetworkedBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(!IsLocalPlayer)
        {
            GetComponent<FirstPersonController>().enabled = false;
            Destroy(transform.Find("FirstPersonCharacter").gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsLocalPlayer && Input.GetMouseButtonDown(0))
        {
            Camera camera = GetComponentInChildren<Camera>();
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                if (hit.transform.GetComponent<FirstPersonController>() != null)
                    Destroy(hit.transform.gameObject);
        }
    }
}
