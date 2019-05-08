using UnityEngine;

public class EventListenerEjecutarComandos : MonoBehaviour
{
    private Renderer elRenderer;
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
        elRenderer.material.color = new Color(0.26f, 0.61f, 0.8f);
    }

    public void OnClick()
    {
        elRenderer.material.color = Color.green;
        var theScript=gameObject.transform.parent.GetComponentInChildren<EventListenerPlataforma>();
        theScript.ejecutarTodos();
        print("Onclickdeesferaflotante");
    }
}
