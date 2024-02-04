using System;

using R5T.T0240;


namespace R5T.L0095.T000
{
    /// <summary>
    /// With a string-typed solution file path.
    /// </summary>
    [WithXMarker]
    public interface IWithSolutionFilePath :
        IHasSolutionFilePath
    {
        new string SolutionFilePath { get; set; }
    }
}
