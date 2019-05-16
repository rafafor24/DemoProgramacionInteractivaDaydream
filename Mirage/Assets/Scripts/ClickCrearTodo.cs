using UnityEngine;
using UnityEngine.UI;

public class ClickCrearTodo : MonoBehaviour
{
    private Renderer elRenderer;
    public GameObject myPrefab;
    private Color colorinicial;
    private Text textoVar;
    public GameObject spawner;
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
        textoVar = GameObject.FindGameObjectWithTag("Valor").GetComponent<Text>();
        var instancia = Instantiate(myPrefab, new Vector3(spawner.transform.position.x, spawner.transform.position.y+10f, spawner.transform.position.z), Quaternion.identity);
        var theScript = instancia.GetComponentInChildren<AsignSelect>();
        theScript.texto = textoVar.text;
        textoVar.text = "";  
    }
}
