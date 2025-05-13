namespace System.ComponentModel
{
    using System.Diagnostics.CodeAnalysis;

    [AttributeUsage(AttributeTargets.Field)]
    public class IdentificationAttribute : Attribute
    {
        public virtual string Identification => IdentificationValue;

        /// <summary>
        /// Read/Write property that directly modifies the string stored in the identification
        /// attribute.
        /// </summary>
        protected string IdentificationValue { get; set; }

        public IdentificationAttribute(string identification)
        {
            IdentificationValue = identification;
        }

        /// <inheritdoc />
        public override bool Equals([NotNullWhen(true)] object? obj) =>
            obj is IdentificationAttribute other && other.Identification == Identification;

        /// <inheritdoc />
        public override int GetHashCode() => Identification.GetHashCode();
    }
}
