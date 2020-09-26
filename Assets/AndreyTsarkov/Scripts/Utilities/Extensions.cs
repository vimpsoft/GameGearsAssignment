public static class Extensions
{
    public static Stat Clone(this Stat original)
    {
        var clone = new Stat();
        clone.icon = original.icon;
        clone.id = original.id;
        clone.title = original.title;
        clone.value = original.value;
        return clone;
    }
}
