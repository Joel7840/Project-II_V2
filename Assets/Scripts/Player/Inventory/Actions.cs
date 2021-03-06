using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TreeEditor;
using UnityEngine;

public class Actions : MonoBehaviour
{

    private InventorySystem _inventory;
    private PlayersManager PM;

    private GameObject _item;
    private GameObject _itemSelected;
    private GameObject _lighter;
    private GameObject _radio;    
    private bool lighter;
    private bool blueLight;

    private int first;
    public int _slot;
    public float timer;
    private bool changed;
    private bool moreMesages;
    private bool time;

    public GameObject piedraPrefab;
    public GameObject flashPrefab;

    public GameObject radioMesage;

    public AudioSource SFXlinterna;
    public AudioSource SFXradio;
    public AudioSource SFXcristal;

    void Awake()
    {
        _slot = 0;
        _inventory = GetComponent<InventorySystem>();
        PM = GameObject.Find("PlayersManager").GetComponent<PlayersManager>();


    }

    private void Start()
    {
        moreMesages = false;
        first = 0;
        blueLight = true;
        lighter = true;
        changed = false;
    }


    void Update()
    {
        if(time)
        {
            timer += Time.deltaTime;
        }
        Debug.Log(timer);
        if(timer > 6 && changed)
        {
            DialogueManager.ChangeText(3, 4, Color.white, GameObject.Find("TextBackground"), GameObject.Find("TextBox"));
            
            
            if(moreMesages)
            {
                if (timer > 10 && timer < 13) { DialogueManager.ChangeText(4, 3, Color.white, GameObject.Find("TextBackground"), GameObject.Find("TextBox")); }
                else if (timer > 13 && timer < 16) { DialogueManager.ChangeText(5, 3, Color.grey, GameObject.Find("TextBackground"), GameObject.Find("TextBox")); }
                else if (timer > 16 && timer < 19) { DialogueManager.ChangeText(6, 3, Color.white, GameObject.Find("TextBackground"), GameObject.Find("TextBox")); }
                else if (timer > 19 && timer < 22) { DialogueManager.ChangeText(7, 3, Color.grey, GameObject.Find("TextBackground"), GameObject.Find("TextBox")); moreMesages = false; changed = false; }
                
                
            }
            else
            {
                time = false;
                changed = false;
            }
        }
        

        //TIRAR OBJETO 
        if (Input.GetKeyDown("q"))
        {
            _inventory.DropItem(_slot);

        }
        //USAR OBJETO 
        if (Input.GetMouseButtonDown(0))
        {
            
            _itemSelected = _inventory.CheckItems(_inventory.strSlots[_slot]);
            //USARLO
            if (_itemSelected != null)
            {
                int i = _itemSelected.GetComponent<ItemControler>().Type;
                if (i >= 2)
                {
                    if(i == 2)
                    {
                        Instantiate(piedraPrefab, PM.Players[0].transform.position, PM.Players[0].transform.rotation);
                    }
                    if(i == 4)
                    {
                        for(int j = 0; j < PM.Enemies.Count; j++)
                        {
                            Instantiate(flashPrefab, PM.Players[0].transform.position, PM.Players[0].transform.rotation);
                            AudioManager.PlaySFX("piedra_luz", SFXcristal);
                            var dist = (PM.Enemies[j].transform.position - PM.Players[0].transform.position).magnitude;
                            if (dist >= 6 && dist < 10)
                            {
                                PM.Enemies[j].GetComponent<Animator>().SetBool("Attract", true);
                            }

                            if (dist < 6)
                            {
                                PM.Enemies[j].GetComponent<Animator>().SetBool("Distract", true);
                            }
                        }
                    }
                    _inventory.RemoveItem(_slot);
                }
                if(i == 0)
                {
                    _lighter = PM.Players[0].transform.Find("Linterna(Clone)").gameObject;                                                
                    
                    if(_lighter.activeSelf == false)
                    {                        
                        AudioManager.PlaySFX("linterna", SFXlinterna);
                    }
                    else
                    {
                        AudioManager.PlaySFX("linterna2", SFXlinterna);                        
                    }
                    _lighter.SetActive(lighter);
                    lighter = !lighter;
                }

                if(i == 1)
                {
                    _radio = PM.Players[0].transform.Find("Radio(Clone)").gameObject;
                    _radio.GetComponent<Radio>().On = !_radio.GetComponent<Radio>().On;
                    if(_radio.GetComponent<Radio>().On == true)
                    {
                        AudioManager.PlaySFX("radio", SFXradio);
                        if(PM.Players[0].transform.position.magnitude < radioMesage.transform.position.magnitude)
                        {
                            DialogueManager.ChangeText(2, 6, Color.white, GameObject.Find("TextBackground"), GameObject.Find("TextBox"));
                            if(first == 0)
                            {
                                moreMesages = true;
                            }
                            first++;
                            time = true;
                            timer = 0;
                            changed = true;                            
                        }
                        else
                        {
                            DialogueManager.ChangeText(13, 6, Color.white, GameObject.Find("TextBackground"), GameObject.Find("TextBox"));
                        }
                    }
                    else
                    {
                        SFXradio.Stop();
                    }
                }
                
            }
            Debug.Log(blueLight);
        }

        if (Input.GetMouseButtonDown(1))
        {

            _itemSelected = _inventory.CheckItems(_inventory.strSlots[_slot]);
            //USARLO
            if (_itemSelected != null)
            {
                int i = _itemSelected.GetComponent<ItemControler>().Type;
                
                if (i == 0 && lighter == false)
                {
                    ChangeColor(blueLight);
                    _lighter.transform.GetChild(0).gameObject.SetActive(blueLight);                    
                    blueLight = !blueLight;
                }

                

            }
            Debug.Log(blueLight);
        }

        //MOVER SLOT 
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (_slot > 0)
            {
                _slot--;
                _inventory.HighlightSlot(_slot);
            }
        }
        

        //MOVER SLOT 
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (_slot < _inventory.slots.Length - 1)
            {
                _slot++;
                _inventory.HighlightSlot(_slot);
            }
        }
        

       

    }
    private void ChangeColor(bool blueLightOn)
    {
        if(blueLightOn)
        {
            GameObject.Find("Luz de Linterna").GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().color = Color.blue;
        }

        else
        {
            GameObject.Find("Luz de Linterna").GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().color = Color.yellow;
        }
        
    }

    
}

