using UnityEngine;

namespace Source
{
    public class ColorView : MonoBehaviour,  IView<Color32>
    {
        [SerializeField] private Renderer _renderer;
        private static readonly int Color = Shader.PropertyToID("_Color");

        public void SetValue(Color32 value)
        {
            _renderer.material.SetColor(Color, value);
        }
    }
}