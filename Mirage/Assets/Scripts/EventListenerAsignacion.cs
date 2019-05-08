using UnityEngine;
using UnityEngine.UI;

public class EventListenerAsignacion : MonoBehaviour
{
    private Renderer elRenderer;
    public string texto;
    private TextMesh miTextMesh;
    public bool clickeado;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        miTextMesh = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        miTextMesh.text = texto;
        clickeado = false;
    }

    public void OnEnter()
    {
        if (!clickeado)
        {
            elRenderer.material.color = Color.red;
        }        
    }

    public void OnExit()
    {
        if (!clickeado)
        {
            elRenderer.material.color = new Color(0.73f, 0.494f, 0.807f);
        }
        
    }

    public void OnClick()
    {
        if (!clickeado)
        {
            elRenderer.material.color = Color.green;
            clickeado = true;
            gameObject.transform.parent.tag = "AsignacionAMover";
        }
        else
        {
            elRenderer.material.color = Color.blue;
            clickeado = false;
            gameObject.transform.parent.tag = "Asignacion";
        }
    }
}
