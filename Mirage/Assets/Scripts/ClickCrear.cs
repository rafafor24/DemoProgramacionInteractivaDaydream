using UnityEngine;
using UnityEngine.UI;

public class ClickCrear : MonoBehaviour
{
    private Renderer elRenderer;
    public GameObject myPrefab;
    private Color colorinicial;
    private Text textoVar;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        colorinicial = elRenderer.material.color;
    }

    public void OnEnter()
    {
        elRenderer.material.color = Color.yellow;
    }

    public void OnExit()
    {
        elRenderer.material.color = colorinicial;
    }

    public void OnClick()
    {
        elRenderer.material.color = Color.blue;
        textoVar = GameObject.Find("VarShowX").GetComponent<Text>();
        if(textoVar.text!="")
        {
            var instanciaX=Instantiate(myPrefab, new Vector3(-7f, 4.5f, -2), Quaternion.identity);
            var theScriptX = instanciaX.GetComponentInChildren<AsignSelect>();
            theScriptX.texto = "X="+textoVar.text;
            textoVar.text = "";
        }
        textoVar = GameObject.Find("VarShowY").GetComponent<Text>();
        if (textoVar.text != "")
        {
            var instanciaY = Instantiate(myPrefab, new Vector3(-7f, 4.5f, 0), Quaternion.identity);
            var theScriptY = instanciaY.GetComponentInChildren<AsignSelect>();
            theScriptY.texto = "Y="+textoVar.text;
            textoVar.text = "";
        }
        textoVar = GameObject.Find("VarShowZ").GetComponent<Text>();
        if (textoVar.text != "")
        {
            var instanciaZ = Instantiate(myPrefab, new Vector3(-7f, 4.5f, 2), Quaternion.identity);
            var theScriptZ = instanciaZ.GetComponentInChildren<AsignSelect>();
            theScriptZ.texto = "Z=" + textoVar.text;
            textoVar.text = "";
        }
        textoVar = GameObject.Find("VarShowW").GetComponent<Text>();
        if (textoVar.text != "")
        {
            var instanciaW = Instantiate(myPrefab, new Vector3(-7f, 4.5f, 4), Quaternion.identity);
            var theScriptW = instanciaW.GetComponentInChildren<AsignSelect>();
            theScriptW.texto = "W=" + textoVar.text;
            textoVar.text = "";
        }
    }
}
