using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class DisplayPoint : MonoBehaviour
{
    [SerializeField] int index;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Subscribe(GameEventType.UPDATED_UI_POINT, displayPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void displayPoint ()
    {
        if (GameManager.instance.gamePoint >= index)
        {            
            this.GetComponent<RawImage>().enabled = true;
        }
        else
        {
            this.GetComponent<RawImage>().enabled = false;
        }
    }

}
