using System;

using R5T.F0024.T001;
using R5T.T0240;


namespace R5T.L0095.T001
{
    [HasXMarker]
    public interface IHasSolutionFile
    {
        SolutionFile SolutionFile { get; }
    }
}
