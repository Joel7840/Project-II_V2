using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static GameObject _textPanel;
    public static GameObject _textBox;

    
    private static Animator anim;

    private static string _text;
    private static float timer;
    private static float maxTime;
    private static bool active;
    
    // Start is called before the first frame update
    void Start()
    {
        _textPanel = GameObject.Find("TextBackground");        
        _textBox = GameObject.Find("TextBox");
        anim = _textPanel.GetComponent<Animator>();
        active = false;
        timer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
            timer += Time.deltaTime;
        }
        
        if(timer > maxTime)
        {
            active = false;
            timer = 0;
            anim.SetBool("Open", false);
        }
        
    }

    public static void ChangeText(int i, float time, Color c, GameObject panel, GameObject textbox)
    {
        _textPanel = panel;
        _textBox = textbox;
        anim = _textPanel.GetComponent<Animator>();
        _textPanel.GetComponent<Image>().color = c;
        maxTime = time;
        anim.SetBool("Open", true);
        active = true;
        switch (i)
        {
            case 1:
                _text = "Se está liando mucho a fuera, se escuchan gritos que parecen de monstruos y parece que los militares están luchando. Deberia huir y buscar un lugar seguro antes de que entren aqui. Con la lámpara deberia tener suficiente para escapar en sigilo.";
                break;
            case 2:
                _text = "¡ESTO NO ES UN SIMULACRO! Todo aquel que escuche este mensaje que acuda al refugio gubernamental más cercano. Repito, acuda al refugio más cercano.";
                break;
            case 3:
                _text = "Hemos descubierto 2 tipos de demonios, unos siguen el sonido y los otros detectan tu presencia a través de la luz, también parece que pueden oir un poco.";
                break;
            case 4:
                _text = "Bien, tenemos suerte, hay uno cerca. Vayamos por el parque de aqui al lado que es más rápido.";
                break;
            case 5:
                _text = "Estás segura? Que haremos si nos encuentran?.";
                break;
            case 6:
                _text = "Está bien, mientras no nos vean ni nos escuchen no correremos peligro.";
                break;
            case 7:
                _text = "Ok, si tanto confias ve tu delante.";
                break;
            case 8:
                _text = "¡El terremoto ha derrumbado la pared! Aprovechemos el ruido y corramos al metro de delante para que no nos vean.";
                break;
            case 9:
                _text = "No se ve mucho pero con la lámpara deberiamos poder seguir. No hagas ruido.";
                break;
            case 10:
                _text = "¡CORREEEE!";
                break;
            case 11:
                _text = "Escondamonos en el tren.";
                break;
            case 12:
                _text = "Vamos a ver si se van y huimos por el otro lado.";
                break;
            case 13:
                _text = "¡ESTO NO ES UN SIMULACRO! Evacuen ya las casas y diriganse hacia el búnker más cercano. Unanse a los militares de la calle para estar más seguros. Ellos los acompañarán.";
                break;
            case 14:
                _text = "¡DIOS MIO, ESTÁ LLENO DE MUERTOS! Vamos a la iglesia a ver si queda alguien.";
                break;
            case 15:
                _text = "Están peleando. Rápido, juntemonos con los militares para estar a salvo.";
                break;            
            case 16:
                _text = "Casi nos pillan... Queda poco para llegar al refugio, sigamos.";
                break;
            default:
                _text = "";
                break;
        }
        
        _textBox.GetComponent<Text>().text = _text;
        
    }
    
    
    
}
