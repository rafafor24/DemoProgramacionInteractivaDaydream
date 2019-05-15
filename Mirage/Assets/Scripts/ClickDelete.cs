using UnityEngine;

public class ClickDelete : MonoBehaviour
{
    private Renderer elRenderer;
    private GameObject objetoAMover;
    public int cantObjetos;
    private Material materialinicial;
    public Material seleccionado;
    public Material click;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        materialinicial = elRenderer.material;
        cantObjetos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEnter()
    {
        elRenderer.material.color = Color.yellow;
    }

    public void OnExit()
    {
        elRenderer.material = materialinicial;
        elRenderer.material.color = Color.gray;

    }

    public void OnClick()
    {
        elRenderer.material.color = Color.blue;
        if (cantObjetos <= 40)
        {
            objetoAMover = GameObject.FindGameObjectWithTag("AsignacionAMover");
            if (objetoAMover)
            {
                objetoAMover.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8.5f, gameObject.transform.position.z);
                objetoAMover.transform.rotation = new Quaternion(0, -180, 0, 0);
                objetoAMover.transform.GetChild(0).transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8.5f, gameObject.transform.position.z);
                objetoAMover.transform.GetChild(0).transform.rotation = new Quaternion(0, -180, 0, 0);
                objetoAMover.transform.localScale = new Vector3(0.6F, 0.6F, 0.6F);
                objetoAMover.tag = "Asignacion";
                var theScript = objetoAMover.GetComponentInChildren<AsignSelect>();
                theScript.clickeado = false;
                Renderer rendObjeto = objetoAMover.GetComponentInChildren<Renderer>();
                theScript.materialOriginal();
                cantObjetos++;
            }
            objetoAMover = GameObject.FindGameObjectWithTag("CondicionAMover");
            if (objetoAMover)
            {
                objetoAMover.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8.5f, gameObject.transform.position.z);
                objetoAMover.transform.rotation = new Quaternion(0, -180, 0, 0);
                objetoAMover.transform.GetChild(0).transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 8.5f, gameObject.transform.position.z);
                objetoAMover.transform.GetChild(0).transform.rotation = new Quaternion(0, -180, 0, 0);
                objetoAMover.transform.localScale = new Vector3(0.6F, 0.6F, 0.6F);
                objetoAMover.tag = "Condicion";
                var theScript = objetoAMover.GetComponentInChildren<AsignSelect>();
                theScript.clickeado = false;
                Renderer rendObjeto = objetoAMover.GetComponentInChildren<Renderer>();
                theScript.materialOriginal();
                cantObjetos++;
            }

        }
        else
        {
            elRenderer.material.color = Color.red;
        }
    }
}
