using UnityEngine;
using UnityEngine.UI;

public class CuboSelect : MonoBehaviour
{
    private Renderer elRenderer;
    public string texto;
    private TextMesh miTextMesh;
    private Material materialinicial;
    public bool clickeado;
    public Material seleccionado;
    public Material click;

    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        miTextMesh = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        miTextMesh.text = texto;
        clickeado = false;        
        materialinicial = elRenderer.material;
    }

    public void OnEnter()
    {
        if (!clickeado)
        {
            elRenderer.material = seleccionado;
        }        
    }

    public void OnExit()
    {
        if (!clickeado)
        {
            elRenderer.material = materialinicial;
        }
        
    }

    public void OnClick()
    {
        if (!clickeado)
        {
            elRenderer.material = click;
            clickeado = true;
            gameObject.transform.parent.tag = "AsignacionAMover";
        }
        else
        {
            elRenderer.material = materialinicial;
            clickeado = false;
            gameObject.transform.parent.tag = "Asignacion";
        }
    }

    public void materialOriginal()
    {
        elRenderer.material = materialinicial;

    }
}
