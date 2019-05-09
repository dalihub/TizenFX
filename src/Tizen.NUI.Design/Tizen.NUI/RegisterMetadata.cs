using Microsoft.Windows.Design.Metadata;

namespace Tizen.NUI
{
    internal class RegisterMetadata : IProvideAttributeTable
    {
        public AttributeTable AttributeTable => new AttributeTableBuilder().CreateTable();
    }
}
