#if UNITY_EDITOR

using UnityEditor;
[CustomEditor(typeof(BaseInteract),true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        BaseInteract interactable = (BaseInteract)target;
        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            EditorGUILayout.HelpBox("EventOnlyInteractable can ONLY use UnityEvents", MessageType.Info);

            if (interactable.GetComponent<InteractionEvents>() == null)
            {
                interactable.UseEvents = true;
                interactable.gameObject.AddComponent<InteractionEvents>();
            }
        }

        base.OnInspectorGUI();
        
        if (interactable.UseEvents)
        {
            if(interactable.GetComponent<InteractionEvents>() == null)
                interactable.gameObject.AddComponent<InteractionEvents>();
        }
        else
        {
            if(interactable.GetComponent<InteractionEvents>() != null)
                DestroyImmediate(interactable.GetComponent<InteractionEvents>());
        }
    }
    

}
#endif