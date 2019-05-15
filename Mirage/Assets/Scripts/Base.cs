using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    private Renderer elRenderer;
    private GameObject objetoAMover;
    private int cantObjetos;
    private string[] listaComandos = { "", "", "", "" };
    private Text textoVar;
    private Color colorinicial;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        colorinicial = elRenderer.material.color;
        cantObjetos = 0;
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
        print("Onclickdeplataforma");
        if (cantObjetos <= 3)
        {
            elRenderer.material.color = Color.blue;
            objetoAMover = GameObject.FindGameObjectWithTag("AsignacionAMover");
            listaComandos[cantObjetos] = objetoAMover.GetComponentInChildren<TextMesh>().text;
            objetoAMover.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y+8.5f, gameObject.transform.position.z);
            objetoAMover.transform.rotation = new Quaternion(0,-180,0,0);
            objetoAMover.tag = "Asignacion";
            var theScript = objetoAMover.GetComponentInChildren<CuboSelect>();
            theScript.clickeado = false;
            Renderer rendObjeto = objetoAMover.GetComponentInChildren<Renderer>();
            theScript.materialOriginal();
            cantObjetos++;
        }
        else
        {
            elRenderer.material.color = Color.red;
        }
    }

    public void ejecutarTodos()
    {
        foreach(string comando in listaComandos)
        {
            ejecutar(comando);
        }
    }

    private void ejecutar(string entrada)
    {
        if (entrada != "")
        {
            string[] ladosIgual = entrada.Split("="[0]);
            print(ladosIgual[0] + "---" + ladosIgual[1]);
            string operador = "";
            if (ladosIgual[1].Contains("+"))
            {
                operador = "+";
            }
            else if (ladosIgual[1].Contains("-"))
            {
                operador = "-";
            }
            else if (ladosIgual[1].Contains("*"))
            {
                operador = "*";
            }
            else if (ladosIgual[1].Contains("/"))
            {
                operador = "/";
            }
            else
            {
                operador = "";
            }
            string[] ladosOperador = ladosIgual[1].Split(operador[0]);
                print(ladosOperador[0] + "---" + ladosOperador[1]);
                textoVar = GameObject.Find("VarShow"+ ladosIgual[0]).GetComponent<Text>();
            var i = 0;
            var j = 0;
            if (ladosOperador[0] == "X")
            {
                i = int.Parse(GameObject.Find("VarShowX").GetComponent<Text>().text);
            }
            else if (ladosOperador[0] == "Y")
            {
                i = int.Parse(GameObject.Find("VarShowY").GetComponent<Text>().text);
            }
            else if (ladosOperador[0] == "Z")
            {
                i = int.Parse(GameObject.Find("VarShowZ").GetComponent<Text>().text);
            }
            else if (ladosOperador[0] == "W")
            {
                i = int.Parse(GameObject.Find("VarShowW").GetComponent<Text>().text);
            }
            else
            {
                i = int.Parse(ladosOperador[0]);
            }

            if (ladosOperador[1] == "X")
            {
                j = int.Parse(GameObject.Find("VarShowX").GetComponent<Text>().text);
            }
            else if (ladosOperador[1] == "Y")
            {
                j = int.Parse(GameObject.Find("VarShowY").GetComponent<Text>().text);
            }
            else if (ladosOperador[1] == "Z")
            {
                j = int.Parse(GameObject.Find("VarShowZ").GetComponent<Text>().text);
            }
            else if (ladosOperador[1] == "W")
            {
                j = int.Parse(GameObject.Find("VarShowW").GetComponent<Text>().text);
            }
            else
            {
                j = int.Parse(ladosOperador[1]);
            }

            
            if (operador=="+")
            {
                i = i+j;
            }
            else if (ladosIgual[1].Contains("-"))
            {
                i = i - j;
            }
            else if (ladosIgual[1].Contains("*"))
            {
                i = i * j;
            }
            else if (ladosIgual[1].Contains("/"))
            {
                i = i / j;
            }
            else
            {
                i = i + i;
            }
                textoVar.text = "" + i;
        }        
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            listaComandos[cantObjetos-1] = contact.otherCollider.GetComponentInChildren<TextMesh>().text;
            //print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            //print(listaComandos[0] + listaComandos[1]);
            // Visualize the contact point
            //Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}
