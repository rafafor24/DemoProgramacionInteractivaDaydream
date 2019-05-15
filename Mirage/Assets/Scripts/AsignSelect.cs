using UnityEngine;
using UnityEngine.UI;

public class AsignSelect : MonoBehaviour
{
    private Renderer elRenderer;
    public string texto;
    private TextMesh miTextMesh;
    private Material materialinicial;
    public bool clickeado;
    public Material seleccionado;
    public Material click;
    private int posInBase;//1,2,3,4
    public bool inBase;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        miTextMesh = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        miTextMesh.text = texto;
        clickeado = false;        
        materialinicial = elRenderer.material;
        posInBase = 0;
        inBase = false;
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
        if (inBase)
        {
            if (!clickeado)
            {
                elRenderer.material = click;
                clickeado = true;
                gameObject.transform.parent.tag = "AsignacionEnBase";
            }
            else if (clickeado)
            {
                elRenderer.material = materialinicial;
                clickeado = false;
                gameObject.transform.parent.tag = "Asignacion";
            }
        }
        else
        {
            if (!clickeado)
            {
                elRenderer.material = click;
                clickeado = true;
                gameObject.transform.parent.tag = "AsignacionAMover";
            }        
            else if(clickeado)
            {
                elRenderer.material = materialinicial;
                clickeado = false;
                gameObject.transform.parent.tag = "Asignacion";
            }
        }

        
    }

    public void materialOriginal()
    {
        elRenderer.material = materialinicial;

    }

    public void setPosInBase(int pos,bool inbase)
    {
        posInBase = pos;
        inBase = inbase;
    }
    public int getPosInBase()
    {
        return posInBase;
    }
}
