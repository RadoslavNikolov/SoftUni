namespace AirConditionerTestingSystem.Models.Interfaces
{
    /// <summary>
    /// Defines public memebers for <see cref="AirConditionerTestingSystem.Models.Report" /> model
    /// </summary>
    public interface IReport
    {
        /// <summary>
        /// Gets or sets the mark.
        /// </summary>
        /// <value>
        /// The mark.
        /// </value>
        int Mark { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        string ToString();
    }
}