using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerPlataforma : MonoBehaviour
{
    private Renderer elRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
       
    }

    public void OnEnter()
    {
        elRenderer.material.color = Color.black;
    }

    public void OnExit()
    {
        elRenderer.material.color = new Color(0.73f, 0.494f, 0.807f);
    }

    public void OnClick()
    {
        elRenderer.material.color = Color.green;
    }
}
