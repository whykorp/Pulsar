using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    public Button button;        // Le bouton à survoler
    public Text buttonText;      // Le texte du bouton à changer

    private Color defaultColor = Color.white;
    private Color hoverColor = Color.cyan;

    void Start()
    {
        // Attacher le bouton et définir la couleur par défaut
        if (buttonText != null)
        {
            buttonText.color = defaultColor;
        }
    }

    void Update()
    {
        // Vérifier si la souris est au-dessus du bouton
        if (IsMouseOverButton())
        {
            buttonText.color = hoverColor;   // Change la couleur au survol
        }
        else
        {
            buttonText.color = defaultColor; // Restaure la couleur par défaut
        }
    }

    bool IsMouseOverButton()
    {
        // Vérifier si la souris est sur le bouton en utilisant Raycast
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition, null);
    }
}
