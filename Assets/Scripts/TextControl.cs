using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextControl : MonoBehaviour
{
    public TMP_InputField inputField;
    public AudioSource audioSource;

    public AudioClip[] vowels;
    public AudioClip[] constants;
    public AudioClip[] vowels_constants;
    public AudioClip space;

    public float shotInterval = 0.2f;

    private float shotTime = 0;

    private string tmp;
    private bool sleep;
    private int index = 0;
    private int control = 0;
    private List<AudioClip> clipList = new List<AudioClip>();

    void Start()
    {
        sleep = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) )
        {
            sleep = true;
            index = 0;
            control = 0;
            ReadText(inputField.text);

            foreach (AudioClip c in clipList)
            {
                control++;
            }

        }

        if (sleep)
        {
            if ((Time.time - shotTime) > shotInterval)
            {
                Sleep(clipList[index]);
                Debug.Log(clipList[index].name);
                if (index < control - 1)
                    index++;
                else
                {
                    clipList.Clear();
                    sleep = false;
                }
                    
            }
        }
    }

    public void ReadText(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (text.Length == 1)
            {
                if ("aeıioöuüAEIİOÖUÜ".IndexOf(text[0].ToString()) >= 0)
                {
                    for (int j = 0; j < vowels.Length; j++)
                    {
                        if (vowels[j].name[0].ToString() == text[0].ToString())
                        {
                            clipList.Add(vowels[j]);
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < constants.Length; j++)
                    {
                        if (constants[j].name[0].ToString() == text[0].ToString())
                        {
                            clipList.Add(constants[j]);
                        }
                    }
                }
            }
            else if (text.Length > 1)
            {
                if ("aeıioöuüAEIİOÖUÜ".IndexOf(text[i].ToString()) >= 0)
                {
                    Debug.Log("1");
                    for (int j = 0; j < vowels.Length; j++)
                    {
                        if (vowels[j].name[0].ToString() == text[i].ToString())
                        {
                            clipList.Add(vowels[j]);
                        }
                    }
                }
                else if (i == text.Length-1 && "bcçdfghjklmnprsştvyzBCÇDFGHJKLMNPRSŞTVYZ".IndexOf(text[i].ToString()) >= 0)
                {
                    Debug.Log("2");
                    for (int j = 0; j < constants.Length; j++)
                    {
                        if (constants[j].name[0].ToString() == text[i].ToString())
                        {
                            clipList.Add(constants[j]);
                        }
                    }
                }
                else if (i + 1 < text.Length && "bcçdfghjklmnprsştvyzBCÇDFGHJKLMNPRSŞTVYZ".IndexOf(text[i].ToString()) >= 0 && " ".IndexOf(text[i+1].ToString()) >= 0)
                {
                    Debug.Log("3");
                    for (int j = 0; j < constants.Length; j++)
                    {
                        if (constants[j].name[0].ToString() == text[i].ToString())
                        {
                            clipList.Add(constants[j]);
                        }
                    }
                }
                else if (i + 1 < text.Length && "bcçdfghjklmnprsştvyzBCÇDFGHJKLMNPRSŞTVYZ".IndexOf(text[i].ToString()) >= 0 && " ".IndexOf(text[i].ToString()) >= 0)
                {
                    Debug.Log("4");
                    for (int j = 0; j < constants.Length; j++)
                    {
                        if (constants[j].name[0].ToString() == text[i].ToString())
                        {
                            clipList.Add(constants[j]);
                        }
                    }
                }
                else if (i + 1 < text.Length && "aeıioöuüAEIİOÖUÜ".IndexOf(text[i + 1].ToString()) >= 0 && "bcçdfghjklmnprsştvyzBCÇDFGHJKLMNPRSŞTVYZ".IndexOf(text[i].ToString()) >= 0)
                {
                    Debug.Log("5");
                    for (int j = 0; j < vowels_constants.Length; j++)
                    {
                        if (vowels_constants[j].name[0].ToString() == text[i].ToString() && vowels_constants[j].name[1].ToString() == text[i + 1].ToString())
                        {
                            clipList.Add(vowels_constants[j]);
                        }
                    }
                    i++;
                }
                else if (i + 1 < text.Length && "bcçdfghjklmnprsştvyzBCÇDFGHJKLMNPRSŞTVYZ".IndexOf(text[i + 1].ToString()) >= 0 && "bcçdfghjklmnprsştvyzBCÇDFGHJKLMNPRSŞTVYZ".IndexOf(text[i].ToString()) >= 0)
                {
                    Debug.Log("6");
                    for (int j = 0; j < vowels_constants.Length; j++)
                    {
                        if (vowels_constants[j].name[0].ToString() == text[i].ToString() && vowels_constants[j].name[1].ToString() == "ı")
                        {
                            clipList.Add(vowels_constants[j]);
                        }
                    }
                }
                else if (" " == text[i].ToString())
                {
                    Debug.Log("7");
                    clipList.Add(space);
                }
            }
        }
        

    }

    public void Sleep(AudioClip c)
    {
        shotTime = Time.time;
        audioSource.PlayOneShot(c);
    }
}
