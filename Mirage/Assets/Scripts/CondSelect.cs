using UnityEngine;
using UnityEngine.UI;

public class CondSelect : MonoBehaviour
{
    private Renderer elRenderer;
    public string texto;
    private TextMesh miTextMesh;
    private Material materialinicial;
    public bool clickeado;
    public Material seleccionado;
    public Material click;
    private AudioSource sound;
    private int posInBase;//1,2,3,4
    private GameObject jugador;
    public bool inBase;
    private int[] ids;
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        miTextMesh = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        miTextMesh.text = texto;
        clickeado = false;
        materialinicial = elRenderer.material;
        sound = GetComponent<AudioSource>();
        jugador = GameObject.Find("Head");
        inBase = false;
    }

    public void setIds(int[] param)
    {
        ids = param;
    }

    public int[] getIds()
    {
        return ids;
    }
    void Update()
    {
        miTextMesh.transform.LookAt(new Vector3(0f, 0.9f, -2f));

        miTextMesh.transform.Rotate(new Vector3(0f, 180f, 0f));
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
        sound.Play();

        if (inBase)
        {
            if (!clickeado)
            {
                elRenderer.material = click;
                clickeado = true;
                gameObject.transform.parent.tag = "CondicionEnBase";
            }
            else if (clickeado)
            {
                elRenderer.material = materialinicial;
                clickeado = false;
                gameObject.transform.parent.tag = "Condicion";
            }
        }
        else
        {
            if (!clickeado)
            {
                elRenderer.material = click;
                clickeado = true;
                gameObject.transform.parent.tag = "CondicionAMover";
            }
            else if (clickeado)
            {
                elRenderer.material = materialinicial;
                clickeado = false;
                gameObject.transform.parent.tag = "Condicion";
            }
        }


    }

    public void materialOriginal()
    {
        elRenderer.material = materialinicial;

    }

    public void setInBase( bool inbase)
    {
        inBase = inbase;
    }
    public bool getInBase()
    {
        return inBase;
    }
}
