using System;


namespace R5T.L0095
{
    public class SolutionFileContextOperations : ISolutionFileContextOperations
    {
        #region Infrastructure

        public static ISolutionFileContextOperations Instance { get; } = new SolutionFileContextOperations();


        private SolutionFileContextOperations()
        {
        }

        #endregion
    }
}
