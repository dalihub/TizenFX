using Microsoft.Windows.Design.Metadata;

namespace Tizen.NUI.Design
{
    internal class RegisterMetadata : IProvideAttributeTable
    {
        public AttributeTable AttributeTable => new AttributeTableBuilder().CreateTable();
    }
}
