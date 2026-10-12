using System.Linq.Expressions;
using System.Reflection;

namespace MaquetteMarket.ClientApp;

public static class VisualElementExtensions
{
    public static Task<bool> ColorTo<TElement>(this TElement element, Expression<Func<TElement, Color>> start,
        Color end, uint rate = 16, uint length = 250, Easing easing = null)
        where TElement : IAnimatable
    {
        if (element is null)
        {
            return Task.FromResult(false);
        }

        easing ??= Easing.Linear;

        var member = (MemberExpression)start.Body;
        var property = member.Member as PropertyInfo;

        var animationName = $"color_to_{property.Name}_{element.GetHashCode()}";

        var tcs = new TaskCompletionSource<bool>();

        var elementStartingColor = (Color)property.GetValue(element);

        var transitionAnimation =
            new Animation(d => property.SetValue(element, elementStartingColor.Lerp(end, (float)d)), 0d, 1d, easing);

        try
        {
            element.AbortAnimation(animationName);

            transitionAnimation.Commit(element, animationName, rate, length, finished: (f, a) => tcs.SetResult(a));
        }
        catch (InvalidOperationException)
        {
        }

        return tcs.Task;
    }

    public static Task<bool> TransitionTo<TElement>(this TElement element, Expression<Func<TElement, double>> start,
        double end, uint rate = 16, uint length = 250, Easing easing = null)
        where TElement : IAnimatable
    {
        if (element is null)
        {
            return Task.FromResult(false);
        }

        easing ??= Easing.Linear;

        var member = (MemberExpression)start.Body;
        var property = member.Member as PropertyInfo;

        var animationName = $"transition_to_{property.Name}_{element.GetHashCode()}";

        var tcs = new TaskCompletionSource<bool>();

        var elementStartingPosition = (double)property.GetValue(element);

        var transitionAnimation =
            new Animation(d => property.SetValue(element, d), elementStartingPosition, end, easing);

        try
        {
            element.AbortAnimation(animationName);

            transitionAnimation.Commit(element, animationName, rate, length, finished: (f, a) => tcs.SetResult(a));
        }
        catch (InvalidOperationException)
        {
        }

        return tcs.Task;
    }

    public static Task<bool> TransitionTo<TElement>(this TElement element, Expression<Func<TElement, float>> start,
        float end, uint rate = 16, uint length = 250, Easing easing = null)
        where TElement : IAnimatable
    {
        if (element is null)
        {
            return Task.FromResult(false);
        }

        easing ??= Easing.Linear;

        var member = (MemberExpression)start.Body;
        var property = member.Member as PropertyInfo;

        var animationName = $"transition_to_{property.Name}_{element.GetHashCode()}";

        var tcs = new TaskCompletionSource<bool>();

        var elementStartingPosition = (float)property.GetValue(element);

        var transitionAnimation =
            new Animation(d => property.SetValue(element, d), elementStartingPosition, end, easing);

        try
        {
            element.AbortAnimation(animationName);

            transitionAnimation.Commit(element, animationName, rate, length, finished: (f, a) => tcs.SetResult(a));
        }
        catch (InvalidOperationException)
        {
        }

        return tcs.Task;
    }

    public static Task<bool> TransitionTo<TElement>(this TElement element, Expression<Func<TElement, int>> start,
        int end, uint rate = 16, uint length = 250, Easing easing = null)
        where TElement : IAnimatable
    {
        if (element is null)
        {
            return Task.FromResult(false);
        }

        easing ??= Easing.Linear;

        var member = (MemberExpression)start.Body;
        var property = member.Member as PropertyInfo;

        var animationName = $"transition_to_{property.Name}_{element.GetHashCode()}";

        var tcs = new TaskCompletionSource<bool>();

        var elementStartingPosition = (int)property.GetValue(element);

        var transitionAnimation =
            new Animation(d => property.SetValue(element, (int)d), elementStartingPosition, end, easing);

        try
        {
            element.AbortAnimation(animationName);

            transitionAnimation.Commit(element, animationName, rate, length, finished: (f, a) => tcs.SetResult(a));
        }
        catch (InvalidOperationException)
        {
        }

        return tcs.Task;
    }

    public static Task<bool> TransitionTo<TElement>(this TElement element, Expression<Func<TElement, uint>> start,
        uint end, uint rate = 16, uint length = 250, Easing easing = null)
        where TElement : IAnimatable
    {
        if (element is null)
        {
            return Task.FromResult(false);
        }

        easing ??= Easing.Linear;

        var member = (MemberExpression)start.Body;
        var property = member.Member as PropertyInfo;

        var animationName = $"transition_to_{property.Name}_{element.GetHashCode()}";

        var tcs = new TaskCompletionSource<bool>();

        var elementStartingPosition = (uint)property.GetValue(element);

        var transitionAnimation =
            new Animation(d => property.SetValue(element, (uint)d), elementStartingPosition, end, easing);

        try
        {
            element.AbortAnimation(animationName);

            transitionAnimation.Commit(element, animationName, rate, length, finished: (f, a) => tcs.SetResult(a));
        }
        catch (InvalidOperationException)
        {
        }

        return tcs.Task;
    }

    public static Task<bool> TransitionTo<TElement>(this TElement element, string animationName,
        Action<double> callback, Func<double> start, double end, uint rate = 16, uint length = 250,
        Easing easing = null)
        where TElement : IAnimatable
    {
        if (element is null)
        {
            return Task.FromResult(false);
        }

        easing ??= Easing.Linear;

        var tcs = new TaskCompletionSource<bool>();

        var transitionAnimation = new Animation(callback, start?.Invoke() ?? default(double), end, easing);

        try
        {
            element.AbortAnimation(animationName);

            transitionAnimation.Commit(element, animationName, rate, length, finished: (f, a) => tcs.SetResult(a));
        }
        catch (InvalidOperationException)
        {
        }

        return tcs.Task;
    }

    public static Task<bool> TransitionTo<TElement>(this TElement element, string animationName, Action<float> callback,
        Func<float> start, float end, uint rate = 16, uint length = 250, Easing easing = null)
        where TElement : IAnimatable
    {
        if (element is null)
        {
            return Task.FromResult(false);
        }

        easing ??= Easing.Linear;

        var tcs = new TaskCompletionSource<bool>();

        var transitionAnimation =
            new Animation(x => callback((float)x), start?.Invoke() ?? default(float), end, easing);

        try
        {
            element.AbortAnimation(animationName);

            transitionAnimation.Commit(element, animationName, rate, length, finished: (f, a) => tcs.SetResult(a));
        }
        catch (InvalidOperationException)
        {
        }

        return tcs.Task;
    }

    public static Task<bool> TransitionTo<TElement>(this TElement element, string animationName,
        Action<double> callback, double start, double end, uint rate = 16, uint length = 250, Easing easing = null)
        where TElement : IAnimatable
    {
        if (element is null)
        {
            return Task.FromResult(false);
        }

        easing ??= Easing.Linear;

        var tcs = new TaskCompletionSource<bool>();

        var transitionAnimation = new Animation(callback, start, end, easing);

        try
        {
            element.AbortAnimation(animationName);

            transitionAnimation.Commit(element, animationName, rate, length, finished: (f, a) => tcs.SetResult(a));
        }
        catch (InvalidOperationException)
        {
        }

        return tcs.Task;
    }

    public static Task<bool> TransitionTo<TElement>(this TElement element, string animationName, Action<int> callback,
        Func<int> start, int end, uint rate = 16, uint length = 250, Easing easing = null)
        where TElement : IAnimatable
    {
        if (element is null)
        {
            return Task.FromResult(false);
        }

        easing ??= Easing.Linear;

        var tcs = new TaskCompletionSource<bool>();

        var transitionAnimation = new Animation(x => callback((int)x), start?.Invoke() ?? default(int), end, easing);

        try
        {
            element.AbortAnimation(animationName);

            transitionAnimation.Commit(element, animationName, rate, length, finished: (f, a) => tcs.SetResult(a));
        }
        catch (InvalidOperationException)
        {
        }

        return tcs.Task;
    }

    public static Color Lerp(this Color color, Color to, float amount)
    {
        return
            Color.FromRgba(
                color.Red.Lerp(to.Red, amount),
                color.Green.Lerp(to.Green, amount),
                color.Blue.Lerp(to.Blue, amount),
                color.Alpha.Lerp(to.Alpha, amount));
    }

    public static double Lerp(this double start, double end, double amount)
    {
        var difference = end - start;
        var adjusted = difference * amount;
        return start + adjusted;
    }

    public static float Lerp(this float start, float end, float amount)
    {
        var difference = end - start;
        var adjusted = difference * amount;
        return start + adjusted;
    }

    public static int Lerp(this int start, int end, double amount)
    {
        var difference = end - start;
        var adjusted = (int)(difference * amount);
        return start + adjusted;
    }

    public static byte Lerp(this byte start, byte end, double amount)
    {
        var difference = end - start;
        var adjusted = (int)(difference * amount);

        return (byte)(start + adjusted);
    }
}

