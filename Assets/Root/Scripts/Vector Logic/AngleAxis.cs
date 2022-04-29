using UnityEngine;
using Ardalis.SmartEnum;

public abstract class AngleAxis : SmartEnum<AngleAxis>
{
    public static readonly AngleAxis x = new X();
    public static readonly AngleAxis y = new Y();
    public static readonly AngleAxis z = new Z();

    public abstract MyVector3 axis { get; }

    public AngleAxis(string name, int value) : base(name, value)
    {
    }

    private class X : AngleAxis
    {
        public override MyVector3 axis => _axis;

        private readonly MyVector3 _axis = new MyVector3(1, 0, 0);

        public X() : base("X", 0) { }
    }

    private class Y : AngleAxis
    {
        public override MyVector3 axis => _axis;

        private readonly MyVector3 _axis = new MyVector3(0, 1, 0);

        public Y() : base("Y", 1) { }
    }

    private class Z : AngleAxis
    {
        public override MyVector3 axis => _axis;

        private readonly MyVector3 _axis = new MyVector3(0, 0, 1);

        public Z() : base("Z", 2) { }
    }
}
