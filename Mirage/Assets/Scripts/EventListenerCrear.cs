using UnityEngine;
using UnityEngine.UI;

public class EventListenerCrear : MonoBehaviour
{
    private Renderer elRenderer;
    public GameObject myPrefab;
    private Text textoVar;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
    }

    public void OnEnter()
    {
        elRenderer.material.color = Color.red;
    }

    public void OnExit()
    {
        elRenderer.material.color = new Color(0.26f, 0.81f, 0.7f);
    }

    public void OnClick()
    {
        elRenderer.material.color = Color.green;
        textoVar = GameObject.Find("VarShowX").GetComponent<Text>();
        if(textoVar.text!="")
        {
            var instanciaX=Instantiate(myPrefab, new Vector3(-7f, 4.5f, -2), Quaternion.identity);
            var theScriptX = instanciaX.GetComponentInChildren<EventListenerAsignacion>();
            theScriptX.texto = "X="+textoVar.text;
            textoVar.text = "";
        }
        textoVar = GameObject.Find("VarShowY").GetComponent<Text>();
        if (textoVar.text != "")
        {
            var instanciaY = Instantiate(myPrefab, new Vector3(-7f, 4.5f, 0), Quaternion.identity);
            var theScriptY = instanciaY.GetComponentInChildren<EventListenerAsignacion>();
            theScriptY.texto = "Y="+textoVar.text;
            textoVar.text = "";
        }
        textoVar = GameObject.Find("VarShowZ").GetComponent<Text>();
        if (textoVar.text != "")
        {
            var instanciaZ = Instantiate(myPrefab, new Vector3(-7f, 4.5f, 2), Quaternion.identity);
            var theScriptZ = instanciaZ.GetComponentInChildren<EventListenerAsignacion>();
            theScriptZ.texto = "Z=" + textoVar.text;
            textoVar.text = "";
        }
        textoVar = GameObject.Find("VarShowW").GetComponent<Text>();
        if (textoVar.text != "")
        {
            var instanciaW = Instantiate(myPrefab, new Vector3(-7f, 4.5f, 4), Quaternion.identity);
            var theScriptW = instanciaW.GetComponentInChildren<EventListenerAsignacion>();
            theScriptW.texto = "W=" + textoVar.text;
            textoVar.text = "";
        }
    }
}
