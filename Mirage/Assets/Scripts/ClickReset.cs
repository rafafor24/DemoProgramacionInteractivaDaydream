using UnityEngine;
using UnityEngine.UI;

public class ClickReset : MonoBehaviour
{
    private Renderer elRenderer;
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
        textoVar.text = "";
        textoVar = GameObject.Find("VarShowY").GetComponent<Text>();
        textoVar.text = "";
        textoVar = GameObject.Find("VarShowZ").GetComponent<Text>();
        textoVar.text = "";
        textoVar = GameObject.Find("VarShowW").GetComponent<Text>();
        textoVar.text = "";
    }
}
