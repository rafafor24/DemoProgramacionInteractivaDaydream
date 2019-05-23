using UnityEngine;

public class CrearTeclasVar : MonoBehaviour
{
    private Renderer elRenderer;
    public GameObject prefabTecla;
    public GameObject prefabVar;
    private Color colorinicial;
    private TextMesh textoVar;
    public GameObject contenedor;
    private int cantVars;
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        colorinicial = elRenderer.material.color;
        spawnLetters();
        cantVars = 0;
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
        textoVar = GameObject.FindGameObjectWithTag("Variables").GetComponent<TextMesh>();
        if (textoVar.text != "")
        {
            var instanciaVariable = Instantiate(prefabVar, new Vector3(-2.8f, 12.24f - (cantVars * 1.4f), -16.66f), Quaternion.identity);
            var scriptVar = instanciaVariable.GetComponent<Variable>();
            scriptVar.id=cantVars;
            scriptVar.setNombre(textoVar.text);
            scriptVar.setValue("0");
            scriptVar.isArr=false;
            cantVars++;
            textoVar.text = "";
        }


    }

private void spawnLetters()
    {
        for(var i = 0; i < 26; i++)
        {
            float posZ = 0;
            float posY = 0;

            /*if (i < 13)
            {
                posZ = -14.5f + (i * 1.68f);
                posY = -2f;
            }
            else
            {
                posZ = -14.5f + ((i - 13) * 1.68f);
                posY = -4f;
            }*/

            if (i < 7)
            {
                posZ = -14.5f + (i * 1.68f);
                posY = -2f;
            }
            else if(i<13&&i>=7)
            {
                posZ = -14.5f + ((i - 7) * 1.68f);
                posY = -4f;
            }
            else if (i >= 13 && i < 19)
            {
                posZ = -14.5f + ((i - 13) * 1.68f);
                posY = -6f;
            }
            else
            {
                posZ = -14.5f + ((i - 19) * 1.68f);
                posY = -8f;
            }

            var instanciaNueva = Instantiate(prefabTecla, new Vector3(transform.position.x, 8.66f+posY, posZ), Quaternion.identity);
            instanciaNueva.transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);
            TextMesh mesh=instanciaNueva.GetComponentInChildren<TextMesh>();            
            mesh.text = ""+System.Convert.ToChar(i+97);
            instanciaNueva.transform.Rotate(0, 90, 0, Space.World);
            instanciaNueva.transform.SetParent(contenedor.transform);
            //Minusculas
            /*var instanciaNueva2 = Instantiate(prefabTecla, new Vector3(transform.position.x, transform.position.y + posY - 4, posZ), Quaternion.identity);
            instanciaNueva2.transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);
            TextMesh mesh2 = instanciaNueva2.GetComponentInChildren<TextMesh>();
            mesh2.text = "" + System.Convert.ToChar(i + 97);
            instanciaNueva2.transform.Rotate(new Vector3(0f, 90f, 0f));*/
        }
        contenedor.transform.Rotate(0, 30, 0, Space.World);
        contenedor.transform.position = new Vector3(21.67f, 18.47f, -4.43f);

    }
}
