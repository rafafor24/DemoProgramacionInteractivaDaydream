using UnityEngine;
using UnityEngine.UI;

public class VarAsign : MonoBehaviour
{
    private Renderer elRenderer;
    private Text textoVar;
    private Text textoAPoner;
    private Color colorinicial;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        //string str = gameObject.transform.parent.name.Substring(12);
        colorinicial = elRenderer.material.color;
        string str = gameObject.transform.parent.GetChild(1).GetComponent<TextMesh>().text;
        //Debug.Log("varShow"+str);
        textoVar = GameObject.Find("VarShow"+str).GetComponent<Text>();
        textoAPoner = GameObject.FindGameObjectWithTag("Valor").GetComponent<Text>();
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
        textoVar.text = textoAPoner.text;
        textoAPoner.text = "";
    }
}
