using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMusica : MonoBehaviour
{
    private Renderer elRenderer;
    private Material colorinicial;
    public AudioSource source;
    public Material seleccionado;
    public Material click;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        colorinicial = elRenderer.material;
    }

    public void OnEnter()
    {
        elRenderer.material = seleccionado;
    }

    public void OnExit()
    {
        elRenderer.material = colorinicial;
    }

    public void OnClick()
    {
        elRenderer.material = click;
        var scriptAudio=source.GetComponent<PlayMusic>();
        scriptAudio.cambiarMusica();
    }
}
