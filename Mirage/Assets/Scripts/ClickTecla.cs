using UnityEngine;

public class ClickTecla : MonoBehaviour
{
    private Renderer elRenderer;
    private TextMesh texto;
    public TextMesh textoASumar;
    private Color colorinicial;
    private AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer=gameObject.GetComponent<Renderer>();
        texto = GameObject.FindGameObjectWithTag("Valor").GetComponent<TextMesh>();
        colorinicial = elRenderer.material.color;
        sound = GetComponent<AudioSource>();
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
        sound.Play();
        elRenderer.material.color = Color.blue;
        texto.text += textoASumar.text;
    }
}
