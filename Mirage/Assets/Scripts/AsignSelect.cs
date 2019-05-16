using UnityEngine;
using UnityEngine.UI;

public class AsignSelect : MonoBehaviour
{
    private Renderer elRenderer;
    public string texto;
    private TextMesh miTextMesh;
    private Material materialinicial;
    public bool clickeado;
    public Material seleccionado;
    public Material click;
    private int posInBase;//1,2,3,4
    private AudioSource sound;
    public bool inBase;
    private GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        elRenderer = gameObject.GetComponent<Renderer>();
        miTextMesh = gameObject.transform.GetChild(0).GetComponent<TextMesh>();
        miTextMesh.text = texto;
        clickeado = false;        
        materialinicial = elRenderer.material;
        posInBase = 0;
        sound = GetComponent<AudioSource>();
        inBase = false;
        jugador = GameObject.Find("Head");
    }

    void Update()
    {
        miTextMesh.transform.LookAt(new Vector3(0f, 0.9f, -2f));

        miTextMesh.transform.Rotate(new Vector3(0f, 180f, 0f));
    }

    public void OnEnter()
    {
        if (!clickeado)
        {
            elRenderer.material = seleccionado;
        }        
    }

    public void OnExit()
    {
        if (!clickeado)
        {
            elRenderer.material = materialinicial;
        }
    }

    public void OnClick()
    {
        sound.Play();
        if (inBase)
        {
            if (!clickeado)
            {
                elRenderer.material = click;
                clickeado = true;
                gameObject.transform.parent.tag = "AsignacionEnBase";
            }
            else if (clickeado)
            {
                elRenderer.material = materialinicial;
                clickeado = false;
                gameObject.transform.parent.tag = "Asignacion";
            }
        }
        else
        {
            if (!clickeado)
            {
                elRenderer.material = click;
                clickeado = true;
                gameObject.transform.parent.tag = "AsignacionAMover";
            }        
            else if(clickeado)
            {
                elRenderer.material = materialinicial;
                clickeado = false;
                gameObject.transform.parent.tag = "Asignacion";
            }
        }

        
    }

    public void materialOriginal()
    {
        elRenderer.material = materialinicial;

    }

    public void setPosInBase(int pos,bool inbase)
    {
        posInBase = pos;
        inBase = inbase;
    }
    public int getPosInBase()
    {
        return posInBase;
    }

    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.otherCollider.name);
            if(contact.otherCollider.name=="Cilindro"|| contact.otherCollider.name == "Cubo")
            {
                var clips = Resources.Load("MusicaSonidos/Impact") as AudioClip;
                sound.clip = clips;
                sound.Play();
                var clip2 = Resources.Load("MusicaSonidos/ClickCubo") as AudioClip;
                sound.clip = clip2;
            }
            
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
