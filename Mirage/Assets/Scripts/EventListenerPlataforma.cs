using UnityEngine;
using UnityEngine.UI;

public class EventListenerPlataforma : MonoBehaviour
{
    private Renderer elRenderer;
    private GameObject objetoAMover;
    private int cantObjetos;
    private string[] listaComandos = { "", "", "", "" };
    private Text textoVar;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        cantObjetos = 0;
    }

    public void OnEnter()
    {
        elRenderer.material.color = Color.black;
    }

    public void OnExit()
    {
        elRenderer.material.color = new Color(0.73f, 0.494f, 0.807f);
    }

    public void OnClick()
    {
        print("Onclickdeplataforma");
        if (cantObjetos <= 3)
        {
            elRenderer.material.color = Color.green;
            objetoAMover = GameObject.FindGameObjectWithTag("AsignacionAMover");
            objetoAMover.transform.position = new Vector3(gameObject.transform.position.x + cantObjetos - 3.5f, 8.5f, gameObject.transform.position.z + cantObjetos - 1.5f);
            objetoAMover.tag = "Asignacion";
            var theScript = objetoAMover.GetComponentInChildren<EventListenerAsignacion>();
            theScript.clickeado = false;
            Renderer rendObjeto = objetoAMover.GetComponentInChildren<Renderer>();
            rendObjeto.material.color= elRenderer.material.color = new Color(0.73f, 0.494f, 0.807f);
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
                var i = int.Parse(ladosOperador[0]);
                var j = int.Parse(ladosOperador[1]);
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
