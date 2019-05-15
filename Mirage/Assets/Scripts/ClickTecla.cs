using UnityEngine;
using UnityEngine.UI;

public class ClickTecla : MonoBehaviour
{
    private Renderer elRenderer;
    private Text texto;
    public TextMesh textoASumar;
    private Color colorinicial;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer=gameObject.GetComponent<Renderer>();
        texto = GameObject.FindGameObjectWithTag("Valor").GetComponent<Text>();
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
        texto.text += textoASumar.text;
    }
}
