using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryNode : MonoBehaviour
{
    public delegate void EmotionEvents();
    public static event EmotionEvents BobHype;
    public static event EmotionEvents BobSad;
    public static event EmotionEvents BobShy;
    public static event EmotionEvents KidSmile;
    public static event EmotionEvents KidHappy;

    [SerializeField] protected Character character;
    [SerializeField] protected List<Emotion> emotions;
    public Character Character { get { return character; } }
    public virtual bool HasOptions()
    {
        return false;
    }

    public void CallForEmotions()
    {
        foreach (Emotion emotion in emotions)
        {
            switch (emotion)
            {
                case Emotion.None:
                    break;
                case Emotion.Bob_Hype:
                    BobHype();
                    break;
                case Emotion.Bob_Sad:
                    BobSad();
                    break;
                case Emotion.Bob_Shy:
                    BobShy();
                    break;
                case Emotion.Robbie_Happy:
                    KidHappy();
                    break;
                case Emotion.Robbie_Smiley:
                    KidSmile();
                    break;
                default:
                    break;
            }
        }
    }
}
