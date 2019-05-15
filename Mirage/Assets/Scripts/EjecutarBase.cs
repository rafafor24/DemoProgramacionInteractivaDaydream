using UnityEngine;

public class EjecutarBase : MonoBehaviour
{
    private Renderer elRenderer;
    private Color colorinicial;
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
        var theScript=gameObject.transform.parent.GetComponentInChildren<Base>();
        theScript.ejecutarTodos();
    }
}
