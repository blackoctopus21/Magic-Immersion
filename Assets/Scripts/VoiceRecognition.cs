using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceRecognition : MonoBehaviour
{
    public string[] keywords;
    public ConfidenceLevel confidence = ConfidenceLevel.Low;
    KeywordRecognizer recognizer;

    private Switcher switcher;
    private PositionFixer fixer;
    private void Start()
    {
        recognizer = new KeywordRecognizer(keywords, confidence);
        recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
        recognizer.Start();
        switcher = GameObject.FindWithTag("ParticleSwitcher").GetComponent<Switcher>();
        fixer = GameObject.Find("MonsterTarget").GetComponent<PositionFixer>();
    }
    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        if (args.text.Equals("fix"))
        {
            fixer.fixPosition();
        }
        switcher.Switch(args.text);
    }
    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
