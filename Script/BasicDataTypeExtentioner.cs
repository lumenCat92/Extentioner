using UnityEngine;

namespace LumenCat92.Extentioner
{
    public static class BasicDataTypeExtentioner
    {
        public static float Round_Float(this float value, int digits)
        {
            float mult = Mathf.Pow(10.0f, (float)digits);
            return Mathf.Round(value * mult) / mult;
        }

        public static int Round_Int(this float value)
        {
            float mult = 10f;
            return (int)(Mathf.Round(value * mult) / mult);
        }
    }
}
