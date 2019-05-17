using UnityEngine;
using System;
public class Base : MonoBehaviour
{
    private Renderer elRenderer;
    private GameObject objetoAMover;
    private int cantAsignaciones;
    private int cantCondiciones;
    private string[] listaComandos = { "", "", "", "" };
    public int[][] matrizIdsAsign;
    public int[][] matrizIdsCond;
    public bool condicion;
    private string strCond;
    private TextMesh textoVar;
    private Color colorinicial;
    public bool inCiclo;
    public Material seleccion;
    public Material ciclo;
    public Material noCiclo;
    private int pos;
    private int[] vacio;
    void Start()
    {
        matrizIdsAsign=new int[5][];
        matrizIdsCond= new int[5][];
        vacio =new int[]{ -1,-1,-1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1};
        elRenderer = gameObject.GetComponent<Renderer>();
        colorinicial = elRenderer.material.color;
        cantAsignaciones = 0;
        cantCondiciones = 0;
        condicion = true;
        strCond = "";
        inCiclo = false;
        transform.parent.LookAt(new Vector3(0f, 0f, -2f));
        pos = 0;
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
            matrizIdsCond[cantCondiciones] = scriptCond.getIds();
            scriptCond.clickeado = false;
            scriptCond.setInBase(true);
            scriptCond.materialOriginal();
            cantCondiciones++;
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
                matrizIdsAsign[cantAsignaciones] = theScript.getIds();
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
            while (condicion&&maximo<10)
            {
                evaluarCondicion();                
                foreach (string comando in listaComandos)
                {
                    ejecutar(comando,pos);
                    pos++;
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
                    ejecutar(comando,pos);
                    pos++;
                }
            }
        }
        pos = 0;
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
        
        Array.Copy(vacio,matrizIdsAsign[pos - 1],10 );
         
        while (4 - pos != 0)
        {
            matrizIdsAsign[pos - 1] = matrizIdsAsign[pos];
            pos++;
        }
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
            int[] idsVarsEjecucion = matrizIdsCond[0];

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

            
            string[] valores = getValoresVariables(idsVarsEjecucion);
            if (valores[1] == "")
            {
                i = int.Parse(ladosOperador[0]);
            }
            else
            {
                i = int.Parse(valores[1]);
            }
            if (valores[2] == "")
            {
                j = int.Parse(ladosOperador[1]);

            }
            else
            {
                j = int.Parse(valores[2]);
            }

            //forma no generalizada leyendo las 4 variables iniciales, se pude crear metodo que lea variables existentes creadas por el usuario
            /*if (ladosOperador[0] == "X")
            {
                i = int.Parse(GameObject.Find("VarShowX").GetComponent<TextMesh>().text);
            }
            else if (ladosOperador[0] == "Y")
            {
                i = int.Parse(GameObject.Find("VarShowY").GetComponent<TextMesh>().text);
            }
            else if (ladosOperador[0] == "Z")
            {
                i = int.Parse(GameObject.Find("VarShowZ").GetComponent<TextMesh>().text);
            }
            else if (ladosOperador[0] == "W")
            {
                i = int.Parse(GameObject.Find("VarShowW").GetComponent<TextMesh>().text);
            }
            else
            {
                i = int.Parse(ladosOperador[0]);
            }

            if (ladosOperador[1] == "X")
            {
                j = int.Parse(GameObject.Find("VarShowX").GetComponent<TextMesh>().text);
            }
            else if (ladosOperador[1] == "Y")
            {
                j = int.Parse(GameObject.Find("VarShowY").GetComponent<TextMesh>().text);
            }
            else if (ladosOperador[1] == "Z")
            {
                j = int.Parse(GameObject.Find("VarShowZ").GetComponent<TextMesh>().text);
            }
            else if (ladosOperador[1] == "W")
            {
                j = int.Parse(GameObject.Find("VarShowW").GetComponent<TextMesh>().text);
            }
            else
            {
                j = int.Parse(ladosOperador[1]);
            }*/

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
        Array.Copy(vacio, matrizIdsCond[pos - 1], 10);

    }

    private void ejecutar(string entrada, int pos)
    {
        if (entrada != "")
        {
            bool esCte = false;
            var i = 0;
            var j = 0;
            int[] idsVarsEjecucion = matrizIdsAsign[pos];
            string[] dividirPorIgual = entrada.Split("="[0]);
            var variables = GameObject.FindGameObjectsWithTag("Variable");
            int result = 0;
            var contador = 0;
            foreach (GameObject variable in variables)
            {
                var scriptVar = variable.GetComponent<Variable>();
                if (scriptVar.getId() == idsVarsEjecucion[0])
                {
                    result = contador;
                    break;
                }
                contador++;
            }
            
            var variableObtenida = variables[result];
            //textoVar = variableObtenida.transform.GetChild(1).GetComponent<TextMesh>();
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
                string[] valores = getValoresVariables(idsVarsEjecucion);
                if (valores[1] == "")
                {
                    i = int.Parse(ladosOperador[0]);
                }
                else
                {
                    i = int.Parse(valores[1]);

                }
                if (valores[2] == "")
                {
                    j = int.Parse(ladosOperador[1]);
                }
                else
                {
                    j = int.Parse(valores[2]);
                }


                /*if (ladosOperador[0] == "X")
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
                }*/

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
                //textoVar.text = "" + i;
            variableObtenida.GetComponent<Variable>().setValue(""+i);


        }        
    }

    private string[] getValoresVariables(int[] idsVars)
    {
        var variables = GameObject.FindGameObjectsWithTag("Variable");
        string[] result= { "", "", "" };
        
        for(var i=0;i<3;i++)
        {
            for(var j = 0; j < variables.Length; j++)
            {
                GameObject variable = variables[j];
                var scriptVar = variable.GetComponent<Variable>();
                if (scriptVar.getId() == idsVars[i])
                {
                    result[i]= scriptVar.getValue();
                }
            }
        }
        
        return result;
    }


    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {

            /*var ausio = contact.otherCollider.gameObject.GetComponent<AudioSource>();
            var clips = Resources.Load("MusicaSonidos/Impacto") as AudioClip;
            if (ausio)
            {

                ausio.clip = clips;
                ausio.Play();
                var clip2 = Resources.Load("MusicaSonidos/ClickCubo") as AudioClip;
                ausio.clip = clip2;
            }*/

        }
    }


}
