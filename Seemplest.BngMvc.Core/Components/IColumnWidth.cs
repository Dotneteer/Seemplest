namespace Seemplest.BngMvc.Core.Components
{
    /// <summary>
    /// This interface defines the column width properties
    /// </summary>
    public interface IColumnWidth
    {
        /// <summary>
        /// Gets the width of an extra small column
        /// </summary>
        int? XsWidth { get; }

        /// <summary>
        /// Gets the width of a small column
        /// </summary>
        int? SmWidth { get; }

        /// <summary>
        /// Gets the width of a medium column
        /// </summary>
        int? MdWidth { get; }

        /// <summary>
        /// Gets the width of a large column
        /// </summary>
        int? LgWidth { get; }
    }
}