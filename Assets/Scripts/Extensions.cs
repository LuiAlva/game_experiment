using TMPro;

namespace CustomExtensions
{
    public static class Extensions
    {
        public static void LabeledText(this TMP_Text uiText, string label, string message)
        {
            if (label == null && message == null) { return; }
            if (label.Equals(null)) { label = ""; }
            if (message.Equals(null)) { message = "Error"; }
            if (label.Equals("")) { uiText.text = message; return; }
            label += $" ~>  {message}";
            uiText.text = label;
        }
    }
}

