using System;
using UnityEngine;

namespace Source
{
    [Serializable]
    public struct SerializableColor
    {
        public float r; 
        public float g; 
        public float b; 
        
        public SerializableColor(Color color)
        {
            r = color.r;
            g = color.g;
            b = color.b;
        }

        public Color ToUnityColor()
        {
            return new Color(r, g, b);
        }
    }
}