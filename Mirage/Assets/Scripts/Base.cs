using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour
{
    private Renderer elRenderer;
    private GameObject objetoAMover;
    private int cantAsignaciones;
    private string[] listaComandos = { "", "", "", "" };
    public bool condicion;
    private string strCond;
    private Text textoVar;
    private Color colorinicial;
    public bool inCiclo;
    public Material seleccion;
    public Material ciclo;
    public Material noCiclo;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        colorinicial = elRenderer.material.color;
        cantAsignaciones = 0;
        condicion = true;
        strCond = "";
        inCiclo = false;
        transform.parent.LookAt(new Vector3(0f, 0f, -2f));

    }

    void Update()
    {
       
    }

    public void setInCiclo(bool set)
    {
        inCiclo = set;
    }

    public bool getInCiclo()
    {
        return inCiclo;
    }

    public void setColor(Color set)
    {
        colorinicial = set;
    }

    public Color getColor()
    {
        return colorinicial;
    }

    public void OnEnter()
    {
        elRenderer.material = seleccion;
    }

    public void OnExit()
    {
        if (inCiclo)
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
        objetoAMover = GameObject.FindGameObjectWithTag("CondicionAMover");
        if (objetoAMover)
        {
            strCond = objetoAMover.GetComponentInChildren<TextMesh>().text;
            objetoAMover.transform.position = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y + 8.5f, gameObject.transform.position.z);
            objetoAMover.transform.rotation = new Quaternion(0, -180, 0, 0);
            objetoAMover.transform.GetChild(0).transform.position = new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y + 8.5f, gameObject.transform.position.z);
            objetoAMover.transform.GetChild(0).transform.rotation = new Quaternion(0, -180, 0, 0);
            objetoAMover.tag = "Condicion";
            var scriptCond = objetoAMover.GetComponentInChildren<CondSelect>();
            scriptCond.clickeado = false;
            scriptCond.setInBase(true);
            scriptCond.materialOriginal();
        }
        
        if (cantAsignaciones <= 3)
        {
            
            objetoAMover = GameObject.FindGameObjectWithTag("AsignacionAMover");
            if (objetoAMover)
            {
                listaComandos[cantAsignaciones] = objetoAMover.GetComponentInChildren<TextMesh>().text;
                objetoAMover.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8.5f, gameObject.transform.position.z);
                objetoAMover.transform.rotation = new Quaternion(0, -180, 0, 0);
                objetoAMover.transform.GetChild(0).transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8.5f, gameObject.transform.position.z);
                objetoAMover.transform.GetChild(0).transform.rotation = new Quaternion(0, -180, 0, 0);
                objetoAMover.tag = "Asignacion";
                var theScript = objetoAMover.GetComponentInChildren<AsignSelect>();
                theScript.clickeado = false;
                theScript.setPosInBase(cantAsignaciones + 1, true);
                Renderer rendObjeto = objetoAMover.GetComponentInChildren<Renderer>();
                theScript.materialOriginal();
                cantAsignaciones++;
            }            
        }
        else
        {
            elRenderer.material.color = Color.red;
        }
    }

    public void ejecutarTodos()
    {
        
        if (inCiclo)
        {       
            int maximo = 0;
            evaluarCondicion();
            while (condicion&&maximo<100)
            {
                evaluarCondicion();
                foreach (string comando in listaComandos)
                {
                    ejecutar(comando);
                }
                maximo++;
            }
        }
        else
        {
            if (strCond != "")
            {
                evaluarCondicion();
            }
            if (condicion)
            {
                foreach (string comando in listaComandos)
                {
                    ejecutar(comando);
                }
            }
        }        
    }

    public void deleteCube(int pos)
    {
        cantAsignaciones--;
        listaComandos[pos-1] = "";
        while (4 - pos != 0)
        {
            listaComandos[pos - 1] = listaComandos[pos];
            pos++;
        }
        print(listaComandos);
    }

    private void evaluarCondicion()
    {
        if (strCond == "T")
        {
            condicion = true;
        }
        else if (strCond == "F")
        {
            condicion = false;
        }
        else
        {
            bool negacion=false;
            string operador = "";
            bool result=false;
            var i=0;
            var j=0;
            if (strCond.StartsWith("!"))
            {
                negacion = true;
                strCond = strCond.Substring(1);
            }

            if (strCond.Contains("="))
            {
                operador = "=";
            }
            else if (strCond.Contains(">"))
            {
                operador = ">";
            }
            else if (strCond.Contains("<"))
            {
                operador = "<";
            }
            string[] ladosOperador = strCond.Split(operador[0]);


            //forma no generalizada leyendo las 4 variables iniciales, se pude crear metodo que lea variables existentes creadas por el usuario
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

            if (operador == "=")
            {
                result = i == j;
            }
            else if (operador==">")
            {
                result = i > j;
            }
            else if (operador == "<")
            {
                result = i < j;
            }

            if (negacion)
            {
                condicion = !result;
            }
            else
            {
                condicion = result;
            }
        }
    }


    public void deleteCond()
    {
        condicion = true;
        strCond = "";
    }

    private void ejecutar(string entrada)
    {
        if (entrada != "")
        {
            bool esCte = false;
            var i = 0;
            var j = 0;
            string[] dividirPorIgual = entrada.Split("="[0]);
            textoVar = GameObject.Find("VarShow" + dividirPorIgual[0]).GetComponent<Text>();
            string operador = "";
            if (dividirPorIgual[1].Contains("+"))
            {
                operador = "+";
            }
            else if (dividirPorIgual[1].Contains("-"))
            {
                operador = "-";
            }
            else if (dividirPorIgual[1].Contains("*"))
            {
                operador = "*";
            }
            else if (dividirPorIgual[1].Contains("/"))
            {
                operador = "/";
            }
            else
            {
                esCte = true;
                i = int.Parse(dividirPorIgual[1]);
            }
            if (!esCte)
            {
                string[] ladosOperador = dividirPorIgual[1].Split(operador[0]);
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

                if (operador == "+")
                {
                    i = i + j;
                }
                else if (dividirPorIgual[1].Contains("-"))
                {
                    i = i - j;
                }
                else if (dividirPorIgual[1].Contains("*"))
                {
                    i = i * j;
                }
                else if (dividirPorIgual[1].Contains("/"))
                {
                    i = i / j;
                }
                else
                {
                    i = i + i;
                }
            }            
                textoVar.text = "" + i;
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.otherCollider.name);

            /*var ausio = contact.otherCollider.gameObject.GetComponent<AudioSource>();
            print(contact.otherCollider.name);
            var clips = Resources.Load("MusicaSonidos/Impacto") as AudioClip;
            if (ausio)
            {
                print("enif");

                ausio.clip = clips;
                ausio.Play();
                var clip2 = Resources.Load("MusicaSonidos/ClickCubo") as AudioClip;
                ausio.clip = clip2;
            }*/

        }
    }


}
