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
        TextMesh elTotal = GameObject.FindGameObjectWithTag("TodoElCodigo").GetComponent<TextMesh>();
        elTotal.text = "";
        //valor de cada variable a codigo java
        var variables = GameObject.FindGameObjectsWithTag("Variable");
        foreach (GameObject variable in variables)
        {
            var scriptVar = variable.GetComponent<Variable>();
            elTotal.text += "int "+scriptVar.getNombre()+" = " + scriptVar.getValue() + ";\n";
        }

        elRenderer.material.color = Color.blue;
        bases = GameObject.FindGameObjectsWithTag("Base");
        foreach (GameObject bas in bases)
        {
            var theScript = bas.GetComponent<Base>();
            theScript.mostrarCodigo();
            theScript.mostrarEnEjecucion();
            theScript.ejecutarTodos();
            theScript.agregarCodigoTotal();
            yield return new WaitForSeconds(1.3f);            
        }        

        foreach (GameObject bas in bases)
        {
            var theScript = bas.GetComponent<Base>();
            theScript.noMostrarEnEjecucion();
        }
    }
}
