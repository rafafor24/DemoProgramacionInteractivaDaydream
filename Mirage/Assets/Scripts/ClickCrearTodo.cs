using UnityEngine;
using UnityEngine.UI;
using System;

public class ClickCrearTodo : MonoBehaviour
{
    private Renderer elRenderer;
    public GameObject myPrefab;
    private Color colorinicial;
    private TextMesh textoVar;
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
        textoVar = GameObject.FindGameObjectWithTag("Valor").GetComponent<TextMesh>();
        var scriptTablero = textoVar.GetComponent<SelectVar>();
        int[] losids = scriptTablero.getAllIds();
        var instancia = Instantiate(myPrefab, new Vector3(spawner.transform.position.x, spawner.transform.position.y+10f, spawner.transform.position.z), Quaternion.identity);
        if (spawner.name == "SpawnAsig")
        {
            var scriptCubo = instancia.GetComponentInChildren<AsignSelect>();            
            scriptCubo.texto = textoVar.text;
            int[] parapasar=new int[100];
            Array.Copy(losids, parapasar,100);
            scriptCubo.setIds(parapasar);
            textoVar.text = "";
        }
        else
        {
            var scriptCubo = instancia.GetComponentInChildren<CondSelect>();
            scriptCubo.texto = textoVar.text;
            int[] parapasar = new int[100];
            Array.Copy(losids, parapasar, 100);
            scriptCubo.setIds(parapasar);
            textoVar.text = "";
        }
        scriptTablero.resetIds();
    }
}
