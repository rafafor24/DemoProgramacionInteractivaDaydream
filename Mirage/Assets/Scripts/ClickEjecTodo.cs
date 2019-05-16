using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEjecTodo : MonoBehaviour
{
    private Renderer elRenderer;
    private GameObject[] bases;
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
        StartCoroutine(Example());
    }

    IEnumerator Example()
    {
        elRenderer.material.color = Color.blue;
        bases = GameObject.FindGameObjectsWithTag("Base");
        foreach (GameObject bas in bases)
        {
            var theScript = bas.GetComponent<Base>();
            theScript.ejecutarTodos();
            yield return new WaitForSeconds(5);
        }
    }
}
