using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnEndEdit : MonoBehaviour
{
    public void Execute(){
        HighscoresTable.OnEndEdit(GetComponent<InputField>().text);
    }
}
