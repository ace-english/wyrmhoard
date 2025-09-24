using UnityEngine;
using UnityEngine.UIElements;

public class CursorManager : MonoBehaviour
{
    private Texture2D DefaultCursor, HoverCursor; 
    private GameObject defaultActivityIndicator;
    private VisualElement defaultActivityIndicatorUI;
    private UnityEngine.UIElements.Label defaultActivityIndicatorLabel;


    
    #region Singleton
    private static CursorManager _instance;
    public static CursorManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CursorManager>();
                if (_instance == null)
                {
                    print("No CursorManager component found. Instantiating new 'CursorManager'");
                    _instance = new GameObject().AddComponent<CursorManager>();
                }
            }
            return _instance;
        }
    }
    #endregion


    

    public void Awake(){
        print("CursorManager awake");
        defaultActivityIndicatorUI = GetComponent<UIDocument>().rootVisualElement;
        defaultActivityIndicatorLabel = defaultActivityIndicatorUI.Q<UnityEngine.UIElements.Label>("default-action-indicator");
    }

    public void Start(){
        print("CursorManager starting");
        ResetToDefaultCursor();
        defaultActivityIndicatorUI.visible = false;
    }

    public virtual void ResetToDefaultCursor(){
        //set the cursor origin to its centre. (default is upper left corner)
        //Vector2 cursorOffset = new Vector2(DefaultCursor.width/2, DefaultCursor.height/2);

        //should probably switch this to UI Toolkit cursor, but idk how rn
        
        UnityEngine.Cursor.SetCursor(DefaultCursor, Vector2.zero, CursorMode.Auto);
        defaultActivityIndicatorUI.visible = false;
    }

    public void SetHoverCursor(){
        UnityEngine.Cursor.SetCursor(HoverCursor, Vector2.zero, CursorMode.Auto);
    }


    public void SetHoverCursor(IInteractable interactable){
        SetHoverCursor();
        defaultActivityIndicatorUI.visible = true;
        Interaction defaultInteraction = interactable.GetDefaultActivity();
        if(defaultInteraction != null){
            SetDefaultActivityIndicator(interactable.GetDefaultActivity().GetLabel() + " " + interactable.GetName());
        }
    }
    
    public void SetDefaultActivityIndicator(string newText){

        //tooltipLabel.text = "<line-height=65%>" + newText + "</line-height>";
        defaultActivityIndicatorLabel.text = newText;
    }

}