using System.ComponentModel.Composition;
using Tekla.Structures.Model;
using Tekla.Structures.CustomPropertyPlugin;

namespace CustomPropertyTest
{
    /// <summary>The test plugin for father component name or number.</summary>
    [Export(typeof(ICustomPropertyPlugin))]
    [ExportMetadata("CustomProperty", "CUSTOM.FATHERCOMPONENT")]
    public class CustomPropertyTest : ICustomPropertyPlugin
    {
        private readonly Model model = new Model();
        /// <summary>Returns custom property int value for object.</summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The <see cref="int"/>.</returns>
        public int GetIntegerProperty(int objectId) => SelectFatherComponent(objectId)?.Number ?? 0;

        /// <summary>Returns custom property string value for object.</summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public string GetStringProperty(int objectId) => SelectFatherComponent(objectId)?.Name ?? string.Empty;

        /// <summary>Returns custom property double value for object.</summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public double GetDoubleProperty(int objectId) => SelectFatherComponent(objectId)?.Number ?? 0.0;

        private BaseComponent SelectFatherComponent(int objectId) => model.SelectModelObject(new Tekla.Structures.Identifier(objectId))?.GetFatherComponent() ?? null;
    }
}
