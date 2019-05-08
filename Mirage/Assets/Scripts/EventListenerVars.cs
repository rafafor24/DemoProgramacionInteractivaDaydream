using UnityEngine;
using UnityEngine.UI;

public class EventListenerVars : MonoBehaviour
{
    private Renderer elRenderer;
    private Text textoVar;
    private Text textoAPoner;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        string str = gameObject.transform.parent.name.Substring(12);
        //Debug.Log("varShow"+str);
        textoVar = GameObject.Find("VarShow"+str).GetComponent<Text>();
        textoAPoner = GameObject.FindGameObjectWithTag("Valor").GetComponent<Text>();
    }

    public void OnEnter()
    {
        elRenderer.material.color = Color.red;
    }

    public void OnExit()
    {
        elRenderer.material.color = new Color(0.26f, 0.61f, 0.8f);
    }

    public void OnClick()
    {
        elRenderer.material.color = Color.green;
        textoVar.text = textoAPoner.text;
        textoAPoner.text = "";
    }
}
