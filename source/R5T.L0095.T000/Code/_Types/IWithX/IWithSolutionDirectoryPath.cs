using System;

using R5T.T0240;


namespace R5T.L0095.T000
{
    [WithXMarker]
    public interface IWithSolutionDirectoryPath :
        IHasSolutionDirectoryPath
    {
        new string SolutionDirectoryPath { get; set; }
    }
}
