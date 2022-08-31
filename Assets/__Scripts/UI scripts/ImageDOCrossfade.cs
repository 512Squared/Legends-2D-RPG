/** --
 ** Copyright (C) 2019 by Josh van den Heever
 **
 ** Permission is hereby granted, free of charge, to any person obtaining a copy of 
 ** this software and associated documentation files (the "Software"), to deal in 
 ** the Software without restriction, including without limitation the rights to 
 ** use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
 ** of the Software, and to permit persons to whom the Software is furnished to 
 ** do so, subject to the following conditions:
 **
 ** The above copyright notice and this permission notice shall be included in 
 ** all copies or substantial portions of the Software.
 **
 ** THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
 ** INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
 ** IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
 ** WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR 
 ** THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 ** --
***/
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public static class ImageDOCrossfade
{
    private static Image CreateTempChildImage(Image image)
    {
        Image result = null;

        string tempChildName = GetTempChildName(image);
        Transform foundTransform = image.transform.Find(tempChildName);
        GameObject tempGo = foundTransform != null ? foundTransform.gameObject : null;

        if (tempGo == null)
        {
            tempGo = new GameObject("TempCloneChild");
            var rt = image.GetComponent<RectTransform>();

            var rtPrime = tempGo.AddComponent<RectTransform>();
            rtPrime.SetParent(rt);
            rtPrime.localScale = Vector3.one;
            rtPrime.anchorMin = Vector2.zero;
            rtPrime.anchorMax = Vector2.one;
            rtPrime.sizeDelta = Vector2.zero;
            rtPrime.anchoredPosition = Vector2.zero;

            result = tempGo.AddComponent<Image>();
            result.preserveAspect = image.preserveAspect;
        }
        else
        {
            result = tempGo.GetComponent<Image>();
        }

        return result;
    }

    private static string GetTempChildName(Image target) => string.Format("TempCloneChild_{0}", target.GetInstanceID());

    public static float GetAlpha(this Image image) => image.color.a;
    public static void SetAlpha(this Image image, float alpha)
    {
        var color = image.color;
        color.a = alpha;
        image.color = color;
    }


    private static void RemoveTempChildImage(Image childImage)
    {
        if (childImage != null)
        {
            Object.Destroy(childImage.gameObject);
        }
    }

    public static Tweener DOCrossfadeImage(this Image image, Image to, float duration, System.Action OnComplete = null)
    {
        Image childImage = CreateTempChildImage(image);
        float progress = 0f;
        const float finalAlpha = 1f;

        childImage.SetAlpha(0f);
        childImage = to;

        return DOTween.To(
            () => progress,
            (curProgress) =>
            {
                progress = curProgress;

                float childAlpha = finalAlpha * progress;
                float imageAlpha = finalAlpha - childAlpha;
                image.SetAlpha(imageAlpha);
                childImage.SetAlpha(childAlpha);
            },
            1f, duration)
            .OnComplete(() => 
            {
                image = to;
                image.SetAlpha(childImage.GetAlpha());

                RemoveTempChildImage(childImage);

                OnComplete?.Invoke();
            })
            .OnKill(() =>
            {
                //Note: If you expect this tween will cancel and wish to halt the
                //  animation, remove this next line. It will look bad when you 
                //  start another CrossFadeImage animation on this
                RemoveTempChildImage(childImage);
            });
    }
}