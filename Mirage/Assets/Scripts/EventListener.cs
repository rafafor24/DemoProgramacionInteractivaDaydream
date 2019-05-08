using UnityEngine;
using UnityEngine.UI;

public class EventListener : MonoBehaviour
{
    private Renderer elRenderer;
    private Text texto;
    public TextMesh textoASumar;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer=gameObject.GetComponent<Renderer>();
        texto = GameObject.FindGameObjectWithTag("Valor").GetComponent<Text>();
    }

    public void OnEnter()
    {
        elRenderer.material.color = Color.red;
    }

    public void OnExit()
    {
        elRenderer.material.color = new Color(0.26f,0.61f,0.8f);
    }

    public void OnClick()
    {
        elRenderer.material.color = Color.green;
        texto.text += textoASumar.text;
    }
}
