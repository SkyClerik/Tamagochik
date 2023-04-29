using UnityEngine;

public static class TextureConverter
{
    public static Texture2D SpriteToTexture(Sprite sprite)
    {
        Rect tRect = sprite.textureRect;
        Texture2D icon = new Texture2D((int)tRect.width, (int)tRect.height);
        Color[] newTexture = sprite.texture.GetPixels((int)tRect.x, (int)tRect.y, (int)tRect.width, (int)tRect.height);
        icon.SetPixels(newTexture);
        icon.Apply();
        return icon;
    }

    public static Texture2D SetGray(Texture2D input)
    {
        Texture2D output = new(input.width, input.height, TextureFormat.ARGB32, false);
        output.SetPixels32(input.GetPixels32());

        for (int j = 0; j < output.height; j++)
        {
            for (int i = 0; i < output.width; i++)
            {
                float R = output.GetPixel(i, j).r;
                float G = output.GetPixel(i, j).g;
                float B = output.GetPixel(i, j).b;
                var nP = (R + G + B) / 3f;
                Color color = new(nP, nP, nP);
                output.SetPixel(i, j, color);
            }
        }
        output.Apply();
        return output;
    }

    public static Texture2D SetSepia(Texture2D input)
    {
        Texture2D output = new(input.width, input.height, TextureFormat.ARGB32, false);
        output.SetPixels32(input.GetPixels32());

        for (int j = 0; j < output.height; j++)
        {
            for (int i = 0; i < output.width; i++)
            {
                float R = output.GetPixel(i, j).r;
                float G = output.GetPixel(i, j).g;
                float B = output.GetPixel(i, j).b;

                R = R * 0.393f + G * 0.769f + B * 0.189f;
                G = R * 0.349f + G * 0.686f + B * 0.168f;
                B = R * 0.272f + G * 0.534f + B * 0.131f;

                Color color = new(R, G, B);
                output.SetPixel(i, j, color);
            }
        }
        output.Apply();
        return output;
    }

    public static Texture2D SetGreen(Texture2D input)
    {
        Texture2D output = new(input.width, input.height, TextureFormat.ARGB32, false);
        output.SetPixels32(input.GetPixels32());

        for (int j = 0; j < output.height; j++)
        {
            for (int i = 0; i < output.width; i++)
            {
                float R = output.GetPixel(i, j).r;
                float G = output.GetPixel(i, j).g;
                float B = output.GetPixel(i, j).b;

                R = R * 0.300f + G * 0.066f + B * 0.300f;
                G = R * 0.500f + G * 0.350f + B * 0.600f;
                B = R * 0.100f + G * 0.000f + B * 0.200f;

                Color color = new(R, G, B);
                output.SetPixel(i, j, color);
            }
        }
        output.Apply();
        return output;
    }
}