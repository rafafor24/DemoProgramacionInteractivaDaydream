using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCiclo : MonoBehaviour
{
    private Renderer elRenderer;
    private Material materialInicial;
    public bool inCiclo;
    public Material ciclo;
    public Material noCiclo;
    public Material seleccion;
    
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        materialInicial = elRenderer.material;
        inCiclo = false;        
    }

    public void OnEnter()
    {
        elRenderer.material = seleccion;
    }

    public void OnExit()
    {
        if (!inCiclo)
        {
            elRenderer.material = ciclo;
        }
        else
        {
            elRenderer.material = noCiclo;
        }
    }

    public void OnClick()
    {
        elRenderer.material.color = Color.blue;
        if (!inCiclo)
        {
            elRenderer.material = noCiclo;
            materialInicial = noCiclo;
            inCiclo = true;
            var scriptBase = gameObject.transform.parent.GetChild(0).GetComponent<Base>();
            gameObject.transform.parent.GetChild(0).GetComponent<Renderer>().material = ciclo;
            scriptBase.setInCiclo(true);
        }
        else if (inCiclo)
        {
            elRenderer.material = ciclo;
            materialInicial = ciclo;
            inCiclo = false;
            var scriptBase = gameObject.transform.parent.GetChild(0).GetComponent<Base>();            
            gameObject.transform.parent.GetChild(0).GetComponent<Renderer>().material = noCiclo;
            scriptBase.setInCiclo(false);

        }
    }
}
