using System;

using R5T.T0240;


namespace R5T.L0095.T000
{
    /// <summary>
    /// Has a string-typed solution file path.
    /// </summary>
    [HasXMarker]
    public interface IHasSolutionFilePath
    {
        string SolutionFilePath { get; }
    }
}
